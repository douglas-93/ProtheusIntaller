using System.IO.Compression;
using System.Windows.Forms;

namespace ProtheusIntaller
{
    public partial class MainWindow : Form
    {
        private static readonly string TEMP_DIR = Path.GetTempPath();
        private static readonly string DESTINATION_COPY_FILE = Path.Combine(TEMP_DIR, "smartclient.zip");
        private static readonly string TARGET_LINK_PATH = @"C:\smartclient\Protheus.lnk";
        private static readonly string PUBLIC_DESKTOP_PATH = @"C:\Users\Public\Desktop\Protheus.lnk";

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            tBoxOrigem.Enabled = false;
            tBoxDestino.Enabled = false;
            btnIniciar.Enabled = false;

            try
            {
                await Task.Run(() => CopyFileWithProgress(tBoxOrigem.Text, DESTINATION_COPY_FILE));
                await Task.Run(() => UnzipFileWithProgress(DESTINATION_COPY_FILE, tBoxDestino.Text));
                CreateShortcut();
                AppendLog("Limpando arquivos desnecess�rios ...");
                File.Delete(DESTINATION_COPY_FILE);
                AppendLog("Instala��o conclu�da com sucesso!");
                MessageBox.Show("Instala��o realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a execu��o: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tBoxOrigem.Enabled = true;
                tBoxDestino.Enabled = true;
                btnIniciar.Enabled = true;
            }
        }

        private void btnSelectOrigem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Sele��o do arquivo de Origem"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tBoxOrigem.Text = ofd.FileName;
            }
        }

        private void btnSelectDestino_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tBoxDestino.Text = dialog.SelectedPath;
            }
        }

        private void CopyFileWithProgress(string source, string destination)
        {
            AppendLog("Copiando arquivo do servidor ...");

            using var sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read);
            using var destinationStream = new FileStream(destination, FileMode.Create, FileAccess.Write);
            int totalSize = (int)sourceStream.Length;
            int copiedSize = 0;
            byte[] buffer = new byte[1024 * 1024]; // 1MB
            int bytesRead;

            Invoke(() =>
            {
                progressBar.Maximum = totalSize;
                progressBar.Value = 0;
            });

            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destinationStream.Write(buffer, 0, bytesRead);
                copiedSize += bytesRead;

                Invoke(() =>
                {
                    progressBar.Value = copiedSize;
                });
            }
        }

        private void UnzipFileWithProgress(string zipFilePath, string destinationDir)
        {
            AppendLog("Iniciando descompacta��o do arquivo copiado ...");

            using var zip = ZipFile.OpenRead(zipFilePath);
            int totalFiles = zip.Entries.Count;
            int index = 0;

            Invoke(() =>
            {
                progressBar.Maximum = totalFiles;
                progressBar.Value = 0;
            });

            foreach (var entry in zip.Entries)
            {
                string destinationPath = Path.Combine(destinationDir, entry.FullName);
                if (string.IsNullOrWhiteSpace(entry.Name)) // Diret�rio
                {
                    Directory.CreateDirectory(destinationPath);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath) ?? throw new InvalidOperationException());
                    entry.ExtractToFile(destinationPath, overwrite: true);
                }

                index++;
                Invoke(() =>
                {
                    progressBar.Value = index;
                });
            }
        }

        private void CreateShortcut()
        {
            AppendLog("Criando atalho na �rea de trabalho p�blica ...");

            if (File.Exists(TARGET_LINK_PATH))
            {
                File.Copy(TARGET_LINK_PATH, PUBLIC_DESKTOP_PATH, overwrite: true);
            }
            else
            {
                MessageBox.Show("Arquivo de atalho n�o encontrado para mover. Ele dever� ser criado manualmente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog("FALHA AO CRIAR ATALHO, ELE DEVE SER CRIADO MANUALMENTE!");
            }
        }

        private void AppendLog(string message)
        {
            Invoke(() =>
            {
                listBox.Items.Add(message);
            });
        }
    }
}
