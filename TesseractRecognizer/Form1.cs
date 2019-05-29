using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace TesseractRecognizer
{
    public partial class Form1 : Form
    {
        private List<string> _lsFiles = new List<string>();
        private readonly string _tessDataPath = Path.Combine(Application.StartupPath, "tessdata");//Caminho com as configuracoes de ocr e fonte do pdf

        public Form1()
        {
            InitializeComponent();
            txbDirSaida.Text = Application.StartupPath;
        }

        private void btnDirSaida_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog() { Description = "Seleciona o Diretório de Saída" };
            if (folder.ShowDialog() == DialogResult.OK)
                txbDirSaida.Text = folder.SelectedPath;
        }

        private void btnArquivos_Click(object sender, EventArgs e)
        {
            FileDialog file = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "TIFF |*.tif;*.tiff"
            };
            _lsFiles = file.ShowDialog() == DialogResult.OK ? file.FileNames.ToList() : new List<string>();
            lsbFiles.Items.Clear();
            _lsFiles.ForEach(filePath => lsbFiles.Items.Add(Path.GetFileName(filePath)));
        }

        private void btnOcrPorArquivo_Click(object sender, EventArgs e)
        {
            List<Task> lstRunningTaks = new List<Task>();
            foreach (string file in _lsFiles)
                lstRunningTaks.Add(Task.Factory.StartNew(() => ProcessByFile(file)));

            Task.WaitAll(lstRunningTaks.ToArray());
            MessageBox.Show("Pdf's gerados com sucesso!");
        }

        private void btnOcrPorPagina_Click(object sender, EventArgs e)
        {
            /*List<Task> lstRunningTaks = new List<Task>();
            foreach (string file in _lsFiles)
                lstRunningTaks.Add(Task.Factory.StartNew(() => ProcessByPage(file)));

            Task.WaitAll(lstRunningTaks.ToArray());
            MessageBox.Show("Pdf's gerados com sucesso!");*/
        }

        private void btnAbrirDirSaida_Click(object sender, EventArgs e)
        {
            Process.Start(txbDirSaida.Text);
        }

        private void ProcessByFile(string pFilePath)
        {
            using (TesseractEngine tesseract = new TesseractEngine(_tessDataPath, "por")) //Caminho da pasta com arquivos de config/ idioma do OCR
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pFilePath);
                string caminhoPdf = Path.Combine(txbDirSaida.Text, fileNameWithoutExtension);//Caminho onde ira salvar o pdf com OCR sem informar extensao
                using (IResultRenderer render = ResultRenderer.CreatePdfRenderer(caminhoPdf, _tessDataPath)) //Caminho pdf e caminho para a fonte do pdf
                using (PixArray pages = PixArray.LoadMultiPageTiffFromFile(pFilePath)) //Carrega todas as páginas do tiff
                using (render.BeginDocument(fileNameWithoutExtension)) //Cria o pdf
                {
                    foreach (Pix page in pages)
                        using (page)
                        using (Page processedPage = tesseract.Process(page, Path.GetFileNameWithoutExtension(fileNameWithoutExtension))) //Processa o arquivo podendo retirar as informacoes de OCR etc.
                            render.AddPage(processedPage); //Adiciona a pagina 
                }
            }
        }

        private void ProcessByPage(string pFilePath)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pFilePath);
            string caminhoPdf = Path.Combine(txbDirSaida.Text, fileNameWithoutExtension);//Caminho onde ira salvar o pdf com OCR sem informar extensao
            using (IResultRenderer render = ResultRenderer.CreatePdfRenderer(caminhoPdf, _tessDataPath)) //Caminho pdf e caminho para a fonte do pdf
            using (PixArray pages = PixArray.LoadMultiPageTiffFromFile(pFilePath)) //Carrega todas as páginas do tiff
            using (render.BeginDocument(fileNameWithoutExtension)) //Cria o pdf
            {
                List<Task> lstTasksRunning = new List<Task>();
                SortedList<int, Page> lstProcessedPages = new SortedList<int, Page>();
                int currentPage = 0;
                foreach (Pix page in pages)
                {
                    int pageIndex = currentPage;
                    lstTasksRunning.Add(Task.Factory.StartNew(() =>
                    {
                        using (TesseractEngine tesseract = new TesseractEngine(_tessDataPath, "por")) //Caminho da pasta com arquivos de config/ idioma do OCR
                        {
                            Page pagina = tesseract.Process(page, Path.GetFileNameWithoutExtension(fileNameWithoutExtension));
                            lstProcessedPages.Add(pageIndex, pagina); //Processa o arquivo podendo retirar as informacoes de OCR etc.
                        }
                    }));
                    currentPage++;
                }

                Task.WaitAll(lstTasksRunning.ToArray());
                foreach (var pageKeyValue in lstProcessedPages)
                    render.AddPage(pageKeyValue.Value); //Adiciona a pagina 

            }
        }


    }
}
