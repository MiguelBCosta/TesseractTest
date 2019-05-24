using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tesseract;

namespace TesseractRecognizer
{
    public partial class Form1 : Form
    {
        public List<string> _arquivo = new List<string>();
        private static string _caminhoTessData = Path.Combine(Application.StartupPath, "tessdata");//Caminho com as configuracoes de ocr e fonte do pdf

        public Form1()
        {
            InitializeComponent();
            txbDirSaida.Text = Application.StartupPath;
        }

        private void btnDirSaida_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog()
            {
                Description = "Seleciona o Diretório de Saída"
            };
            if (folder.ShowDialog() == DialogResult.OK)
                txbDirSaida.Text = folder.SelectedPath;
        }

        private void btnArquivos_Click(object sender, EventArgs e)
        {
            FileDialog file = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff"
            };
            _arquivo = file.ShowDialog() == DialogResult.OK ? file.FileNames.ToList() : new List<string>();
            _arquivo.ForEach(filePath => lsbFiles.Items.Add(Path.GetFileName(filePath)));
        }

        private void btnAplicaOcr_Click(object sender, EventArgs e)
        {
            using (TesseractEngine tesseract = new TesseractEngine(_caminhoTessData, "por"))//Caminho da pasta com arquivos de config/ idioma do OCR
                foreach (string file in _arquivo)
                {
                    string caminhoPdf = Path.Combine(txbDirSaida.Text, Path.GetFileNameWithoutExtension(file));//Caminho onde ira salvar o pdf com OCR sem informar extensao
                    using (var render = ResultRenderer.CreatePdfRenderer(caminhoPdf, _caminhoTessData))//Caminho pdf e caminho para a fonte do pdf
                    using (var image = Pix.LoadFromFile(file))//Carrega o arquivo em um formato que o OCR entende 
                    using (render.BeginDocument(Path.GetFileNameWithoutExtension(caminhoPdf))) //Cria o pdf
                    {
                        Page pagina = tesseract.Process(image, Path.GetFileName(file));//Processa o arquivo podendo retirar as informacoes de OCR etc.
                        render.AddPage(pagina); //Adiciona a pagina 
                    }
                }

            MessageBox.Show("Pdf's gerados com sucesso!");
        }

        private void btnAbrirDirSaida_Click(object sender, EventArgs e)
        {
            Process.Start(txbDirSaida.Text);
        }



    }
}
