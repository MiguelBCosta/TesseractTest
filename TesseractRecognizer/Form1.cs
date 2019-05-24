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
            _arquivo = new List<string>();
            FileDialog file = new OpenFileDialog() { Multiselect = true };
            if (file.ShowDialog() == DialogResult.OK)
                _arquivo = file.FileNames.ToList();
            _arquivo.ForEach(filePath => lsbFiles.Items.Add(Path.GetFileName(filePath)));
        }

        private void btnAplicaOcr_Click(object sender, EventArgs e)
        {

            string caminho = Path.Combine(Application.StartupPath, "tessdata");
            using (TesseractEngine tesseract = new TesseractEngine(caminho, "por"))
                foreach (string file in _arquivo)
                    using (var render = ResultRenderer.CreatePdfRenderer(Path.Combine(txbDirSaida.Text, Path.GetFileNameWithoutExtension(file)), Path.Combine(caminho, caminho)))
                    using (var image = Pix.LoadFromFile(file))
                    using (render.BeginDocument(Path.GetFileNameWithoutExtension(file)))
                        render.AddPage(tesseract.Process(image, Path.GetFileName(file)));
        }

        private void btnAbrirDirSaida_Click(object sender, EventArgs e)
        {
            Process.Start(txbDirSaida.Text);
        }



    }
}
