namespace TesseractRecognizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnArquivos = new System.Windows.Forms.Button();
            this.lsbFiles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDirSaida = new System.Windows.Forms.TextBox();
            this.btnDirSaida = new System.Windows.Forms.Button();
            this.btnOcrPorArquivo = new System.Windows.Forms.Button();
            this.btnAbrirDirSaida = new System.Windows.Forms.Button();
            this.btnOcrPorPagina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnArquivos
            // 
            this.btnArquivos.Location = new System.Drawing.Point(15, 74);
            this.btnArquivos.Name = "btnArquivos";
            this.btnArquivos.Size = new System.Drawing.Size(220, 23);
            this.btnArquivos.TabIndex = 1;
            this.btnArquivos.Text = "Selecionar Arquivo";
            this.btnArquivos.UseVisualStyleBackColor = true;
            this.btnArquivos.Click += new System.EventHandler(this.btnArquivos_Click);
            // 
            // lsbFiles
            // 
            this.lsbFiles.Enabled = false;
            this.lsbFiles.FormattingEnabled = true;
            this.lsbFiles.Location = new System.Drawing.Point(15, 103);
            this.lsbFiles.Name = "lsbFiles";
            this.lsbFiles.Size = new System.Drawing.Size(220, 121);
            this.lsbFiles.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Diretório de Saída:";
            // 
            // txbDirSaida
            // 
            this.txbDirSaida.Enabled = false;
            this.txbDirSaida.Location = new System.Drawing.Point(15, 48);
            this.txbDirSaida.Name = "txbDirSaida";
            this.txbDirSaida.Size = new System.Drawing.Size(335, 20);
            this.txbDirSaida.TabIndex = 5;
            // 
            // btnDirSaida
            // 
            this.btnDirSaida.Location = new System.Drawing.Point(356, 48);
            this.btnDirSaida.Name = "btnDirSaida";
            this.btnDirSaida.Size = new System.Drawing.Size(26, 20);
            this.btnDirSaida.TabIndex = 6;
            this.btnDirSaida.Text = "...";
            this.btnDirSaida.UseVisualStyleBackColor = true;
            this.btnDirSaida.Click += new System.EventHandler(this.btnDirSaida_Click);
            // 
            // btnOcrPorArquivo
            // 
            this.btnOcrPorArquivo.Location = new System.Drawing.Point(241, 103);
            this.btnOcrPorArquivo.Name = "btnOcrPorArquivo";
            this.btnOcrPorArquivo.Size = new System.Drawing.Size(141, 36);
            this.btnOcrPorArquivo.TabIndex = 7;
            this.btnOcrPorArquivo.Text = "Aplicar OCR \r\nThread Por Arquivo";
            this.btnOcrPorArquivo.UseVisualStyleBackColor = true;
            this.btnOcrPorArquivo.Click += new System.EventHandler(this.btnOcrPorArquivo_Click);
            // 
            // btnAbrirDirSaida
            // 
            this.btnAbrirDirSaida.Location = new System.Drawing.Point(241, 187);
            this.btnAbrirDirSaida.Name = "btnAbrirDirSaida";
            this.btnAbrirDirSaida.Size = new System.Drawing.Size(141, 39);
            this.btnAbrirDirSaida.TabIndex = 8;
            this.btnAbrirDirSaida.Text = "Abrir Diretorio de Saida";
            this.btnAbrirDirSaida.UseVisualStyleBackColor = true;
            this.btnAbrirDirSaida.Click += new System.EventHandler(this.btnAbrirDirSaida_Click);
            // 
            // btnOcrPorPagina
            // 
            this.btnOcrPorPagina.Location = new System.Drawing.Point(241, 145);
            this.btnOcrPorPagina.Name = "btnOcrPorPagina";
            this.btnOcrPorPagina.Size = new System.Drawing.Size(141, 36);
            this.btnOcrPorPagina.TabIndex = 9;
            this.btnOcrPorPagina.Text = "Aplicar OCR \r\nThread Por Página";
            this.btnOcrPorPagina.UseVisualStyleBackColor = true;
            this.btnOcrPorPagina.Click += new System.EventHandler(this.btnOcrPorPagina_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 261);
            this.Controls.Add(this.btnOcrPorPagina);
            this.Controls.Add(this.btnAbrirDirSaida);
            this.Controls.Add(this.btnOcrPorArquivo);
            this.Controls.Add(this.btnDirSaida);
            this.Controls.Add(this.txbDirSaida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsbFiles);
            this.Controls.Add(this.btnArquivos);
            this.MaximumSize = new System.Drawing.Size(410, 300);
            this.MinimumSize = new System.Drawing.Size(410, 300);
            this.Name = "Form1";
            this.Text = "Tesseract Recognize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnArquivos;
        private System.Windows.Forms.ListBox lsbFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDirSaida;
        private System.Windows.Forms.Button btnDirSaida;
        private System.Windows.Forms.Button btnOcrPorArquivo;
        private System.Windows.Forms.Button btnAbrirDirSaida;
        private System.Windows.Forms.Button btnOcrPorPagina;
    }
}

