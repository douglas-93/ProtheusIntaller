namespace ProtheusIntaller
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            label1 = new Label();
            label2 = new Label();
            tBoxOrigem = new TextBox();
            btnSelectOrigem = new Button();
            btnSelectDestino = new Button();
            tBoxDestino = new TextBox();
            progressBar = new ProgressBar();
            btnIniciar = new Button();
            listBox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 16);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Origem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 45);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Destino";
            // 
            // tBoxOrigem
            // 
            tBoxOrigem.Location = new Point(64, 12);
            tBoxOrigem.Name = "tBoxOrigem";
            tBoxOrigem.Size = new Size(370, 23);
            tBoxOrigem.TabIndex = 2;
            tBoxOrigem.Text = "\\\\192.168.100.30\\Instalaveis\\smartclient 03.06\\smartclient.zip";
            // 
            // btnSelectOrigem
            // 
            btnSelectOrigem.Location = new Point(440, 12);
            btnSelectOrigem.Name = "btnSelectOrigem";
            btnSelectOrigem.Size = new Size(31, 23);
            btnSelectOrigem.TabIndex = 3;
            btnSelectOrigem.Text = "...";
            btnSelectOrigem.UseVisualStyleBackColor = true;
            btnSelectOrigem.Click += btnSelectOrigem_Click;
            // 
            // btnSelectDestino
            // 
            btnSelectDestino.Location = new Point(440, 41);
            btnSelectDestino.Name = "btnSelectDestino";
            btnSelectDestino.Size = new Size(31, 23);
            btnSelectDestino.TabIndex = 5;
            btnSelectDestino.Text = "...";
            btnSelectDestino.UseVisualStyleBackColor = true;
            btnSelectDestino.Click += btnSelectDestino_Click;
            // 
            // tBoxDestino
            // 
            tBoxDestino.Location = new Point(64, 41);
            tBoxDestino.Name = "tBoxDestino";
            tBoxDestino.Size = new Size(370, 23);
            tBoxDestino.TabIndex = 4;
            tBoxDestino.Text = "C:\\";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(11, 240);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(460, 23);
            progressBar.TabIndex = 6;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(396, 269);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(75, 23);
            btnIniciar.TabIndex = 7;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(12, 70);
            listBox.Name = "listBox";
            listBox.Size = new Size(456, 154);
            listBox.TabIndex = 8;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 299);
            Controls.Add(listBox);
            Controls.Add(btnIniciar);
            Controls.Add(progressBar);
            Controls.Add(btnSelectDestino);
            Controls.Add(tBoxDestino);
            Controls.Add(btnSelectOrigem);
            Controls.Add(tBoxOrigem);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Instalador SmartClient Protheus";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tBoxOrigem;
        private Button btnSelectOrigem;
        private Button btnSelectDestino;
        private TextBox tBoxDestino;
        private ProgressBar progressBar;
        private Button btnIniciar;
        private ListBox listBox;
    }
}
