using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using Timer = System.Windows.Forms.Timer;

namespace CompressorK
{
    public partial class mainForm : Form
    {
        public string currentEnv = Environment.CurrentDirectory;
        public bool isUsingPercentage = false;
        private VideoCompressor? compressor;
        private string inputPath;

        public mainForm()
        {
            InitializeComponent();
        }

        private void openSourceDir(string filePath)
        {
            try
            {
                Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            catch (Exception ex) { }
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            optionsPanel.BringToFront();

            if (Properties.Settings.Default.firstLaunch)
            {
                warningNotice.Visible = true;
                Properties.Settings.Default.firstLaunch = false;
                Properties.Settings.Default.Save();
            }
        }

        private void optionsPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files == null) return;
                if (files[0] == null) return;

                string[] validExtensions = { ".mp4", ".avi", ".mov", ".mkv", ".wmv", ".flv", ".webm" };
                string ext = Path.GetExtension(files[0]).ToLower();

                if (validExtensions.Contains(ext))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void optionsPanel_DragLeave(object sender, EventArgs e)
        {
        }

        private async void optionsPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files == null) return;
                if (files.Length > 0)
                {
                    string filePath = files[0];
                    currentVideoFile.Tag = filePath;
                    await fetchVideo(filePath);
                }
            }
        }

        private async Task fetchVideo(string filePath)
        {
            bool doesFileExist = File.Exists(filePath);
            if (!doesFileExist) return;

            if (compressor == null) compressor = new VideoCompressor();
            compressor.ProgressChanged += Compressor_ProgressChanged;

            var info = await compressor.GetVideoInfo(filePath);
            int maximumFileSize = (int)info.FileSizeMB;
            string fullFileName = info.FileName;
            string fileExtension = Path.GetExtension(info.FilePath);
            string trimmedFileName = Path.GetFileNameWithoutExtension(info.FilePath);

            currentVideoFile.Text = fullFileName;
            suffixFileName.Text = fileExtension;
            // suffixFileName.Text = fileExtension;
            // valueFileName.Text = trimmedFileName;

            valueTargetFileSize.Maximum = maximumFileSize;
            valueTargetFileSize.Minimum = 1;
            valueTargetFileSize.Value = valueTargetFileSize.Maximum / 2;

            valueTargetPercentage.Value = 50;
            suffixTargetPercentage.Text = valueTargetPercentage.Value.ToString();

            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string downloads = Path.Join(userProfile, "Downloads");
            valueOutputFolder.Text = downloads;

            dropPanel.BringToFront();
            btnCompressVideo.Focus();
        }

        private void chkToggleOption_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseFileSize.Checked)
            {
                chkUseFileSize.Text = "Use size percentage";
                isUsingPercentage = true;
                valueTargetFileSize.Enabled = false;
                valueTargetPercentage.Enabled = true;
                suffixTargetPercentage.Enabled = true;
            }
            else
            {
                chkUseFileSize.Text = "Use file size";
                isUsingPercentage = false;
                valueTargetFileSize.Enabled = true;
                valueTargetPercentage.Enabled = false;
                suffixTargetPercentage.Enabled = false;
                suffixTargetPercentage.Text = valueTargetPercentage.Value.ToString();
            }
        }

        private void valueTargetPercentage_Scroll(object sender, EventArgs e)
        {
            int currentValue = valueTargetPercentage.Value;
            int snapIncrement = 10;

            int snappedValue = (int)Math.Round((double)currentValue / snapIncrement) * snapIncrement;

            if (snappedValue < valueTargetPercentage.Minimum)
                snappedValue = valueTargetPercentage.Minimum;
            else if (snappedValue > valueTargetPercentage.Maximum)
                snappedValue = valueTargetPercentage.Maximum;

            valueTargetPercentage.Value = snappedValue;
            suffixTargetPercentage.Text = valueTargetPercentage.Value.ToString();
        }

        private void currentVideoFile_MouseEnter(object sender, EventArgs e)
        {
            currentVideoFile.ForeColor = Color.DodgerBlue;
        }

        private void currentVideoFile_MouseLeave(object sender, EventArgs e)
        {
            currentVideoFile.ForeColor = SystemColors.ControlText;
        }

        private void currentVideoFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentVideoFile.Tag == null) return;
            string? filePath = currentVideoFile.Tag?.ToString();

            if (filePath == null) return;

            try
            {
                Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            catch (Exception ex) { }
        }

        private void btnQuitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCompressVideo_Click(object sender, EventArgs e)
        {
            if (valueFileName.Text.Length >= 1)
            {
                string trimmedFileName = string.Empty;

                if (chkIncludeTimestamp.Checked)
                {
                    trimmedFileName = lblTimestampFormat.Text.Replace("Format: ", string.Empty);
                }
                else
                {
                    trimmedFileName = valueFileName.Text + suffixFileName.Text;
                }

                string content = "Compress \"" + currentVideoFile.Text + $"\"" +
                    Environment.NewLine +
                    Environment.NewLine +
                    "into" +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"\"{trimmedFileName}\"?";

                if (MessageBox.Show(content, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (currentVideoFile.Tag == null) return;
                    string? tag = currentVideoFile.Tag?.ToString();
                    if (tag == null)
                    {
                        string warning = "We were unable to find a valid path for the source file, please try again.";
                        MessageBox.Show(warning, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    compressSize(tag);
                }
            }
            else
            {
                string content = "Compress " + currentVideoFile.Text + $"?";

                if (MessageBox.Show(content, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (currentVideoFile.Tag == null) return;
                    string? tag = currentVideoFile.Tag?.ToString();
                    if (tag == null)
                    {
                        string warning = "We were unable to find a valid path for the source file, please try again.";
                        MessageBox.Show(warning, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    compressSize(tag);
                }
            }
        }

        private async void compressSize(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");

            bool doesFolderExist = Directory.Exists(Path.GetDirectoryName(filePath));
            if (!doesFolderExist)
            {
                string content = $"We were unable to find the folder for -> {filePath}, did the folder get deleted?";
                MessageBox.Show(content, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string outputPath = string.Empty;

            if (chkUseSourceDir.Checked)
            {
                string outputFolder = Path.GetDirectoryName(filePath) ?? string.Empty;

                if (!string.IsNullOrEmpty(valueFileName.Text))
                {
                    if (chkIncludeTimestamp.Checked)
                    {
                        outputPath = Path.Join(
                            outputFolder,
                            $"{valueFileName.Text}-{timestamp}{Path.GetExtension(filePath)}");
                    }
                    else
                    {
                        outputPath = Path.Join(
                            outputFolder,
                            $"{valueFileName.Text}{Path.GetExtension(filePath)}");
                    }
                }
                else
                {
                    outputPath = Path.Join(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(filePath) + $"_compressed-{timestamp}{Path.GetExtension(filePath)}");
                }
            }
            else
            {
                string outputFolder = valueOutputFolder.Text ?? string.Empty;

                if (!string.IsNullOrEmpty(valueFileName.Text))
                {
                    if (chkIncludeTimestamp.Checked)
                    {
                        outputPath = Path.Join(
                            outputFolder,
                            $"{valueFileName.Text}-{timestamp}{Path.GetExtension(filePath)}");
                    }
                    else
                    {
                        outputPath = Path.Join(
                            outputFolder,
                            $"{valueFileName.Text}{Path.GetExtension(filePath)}");
                    }
                }
                else
                {
                    outputPath = Path.Join(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(filePath) + $"_compressed-{timestamp}{Path.GetExtension(filePath)}");
                }
            }


            if (isUsingPercentage)
            {
                int targetPercentage = (int)valueTargetPercentage.Value;

                await CompressVideo(() => compressor.CompressToPercentage(filePath, outputPath, targetPercentage), outputPath);
                return;
            }

            if (!int.TryParse(valueTargetFileSize.Text, out int targetSizeInMB))
            {
                string content = $"We were unable to detect valid numbers in -> Target file size: \"{valueTargetFileSize.Text}\", please insert only valid numbers.";
                MessageBox.Show(content, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await CompressVideo(() => compressor.CompressToTargetSize(filePath, outputPath, targetSizeInMB), outputPath);
            return;
        }

        private async Task CompressVideo(Func<Task> compressionTask, string outputPath)
        {
            btnQuitApp.Enabled = false;
            btnReset.Enabled = false;
            btnCompressVideo.Enabled = false;

            btnCompressVideo.Text = "Compressing...";

            try
            {
                await compressionTask();

                btnCompressVideo.Text = "✔️ Compress video";
                topPanel.BackColor = Color.MediumSpringGreen;

                Timer tmr = new Timer();
                tmr.Interval = 3000;

                tmr.Tick += (_,_) =>
                {
                    topPanel.BackColor = SystemColors.ScrollBar;
                };

                btnCompressVideo.Enabled = true;
                btnQuitApp.Enabled = true;
                btnReset.Enabled = true;

                if (chkOpenSourceDir.Checked)
                {
                    openSourceDir(outputPath);
                }

                await Task.Delay(3000);
            }
            catch (Exception ex)
            {
                btnCompressVideo.Text = "Compression failed, see logs.txt";
            }
        }

        private void Compressor_ProgressChanged(object sender, int percent)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    btnCompressVideo.Text = $"{percent}%";
                }));
            }
        }

        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the folder to save the compressed video to";
            fbd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = fbd.SelectedPath;
                if (string.IsNullOrEmpty(selectedPath)) return;

                if (!Directory.Exists(selectedPath))
                {
                    string content = "The selected folder does not exist, please try with a different folder.";
                    MessageBox.Show(content, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                valueOutputFolder.Text = selectedPath;
                btnCompressVideo.Focus();
            }
        }

        private void chkUseSourceDir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseSourceDir.Checked)
            {
                valueOutputFolder.Enabled = false;
                btnBrowseOutputFolder.Enabled = false;
            }
            else
            {
                valueOutputFolder.Enabled = true;
                btnBrowseOutputFolder.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string content = "Reset and start over?";
            if (MessageBox.Show(content, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                currentVideoFile.Text = string.Empty;
                currentVideoFile.Tag = null;

                valueFileName.Text = string.Empty;
                suffixFileName.Text = "->";

                valueTargetFileSize.Maximum = 10;
                valueTargetFileSize.Value = valueTargetFileSize.Maximum;
                valueTargetFileSize.Enabled = false;

                valueTargetPercentage.Value = 50;
                suffixTargetPercentage.Text = valueTargetPercentage.Value.ToString();

                chkUseFileSize.Checked = true;
                chkUseSourceDir.Checked = true;
                chkIncludeTimestamp.Checked = false;
                chkOpenSourceDir.Checked = false;

                valueOutputFolder.Text = string.Empty;
                btnCompressVideo.Text = "✔️ Compress video"; ;

                compressor = null;
                optionsPanel.BringToFront();
            }
        }

        private void valueFileName_TextChanged(object sender, EventArgs e)
        {
            if (valueFileName.Text.Length == 0)
            {
                chkIncludeTimestamp.Checked = false;
                chkIncludeTimestamp.Enabled = false;
                if (lblTimestampFormat.Visible)
                {
                    lblTimestampFormat.Visible = false;
                    lblTimestampFormat.Text = $"Format: N/A";
                }
            }
            else
            {
                chkIncludeTimestamp.Enabled = true;
                if (chkIncludeTimestamp.Checked)
                {
                    lblTimestampFormat.Visible = true;
                    lblTimestampFormat.Text = $"Format: {valueFileName.Text}-{DateTime.Now:yyyy-MM-dd-HH_mm_ss}{suffixFileName.Text}";
                }
                else
                {
                    lblTimestampFormat.Visible = false;
                    lblTimestampFormat.Text = $"Format: N/A";
                }
            }
        }

        private void valueTargetPercentage_ValueChanged(object sender, EventArgs e)
        {
            // int rawValue = (int)valueTargetPercentage.Value;
            // int invertedPercentage = 101 - rawValue;

            // suffixTargetPercentage.Text = invertedPercentage.ToString();
        }

        private void btnFetchFileName_Click(object sender, EventArgs e)
        {
            string fullFileName = currentVideoFile.Text;
            if (string.IsNullOrEmpty(fullFileName)) return;

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullFileName);
            string fileExtension = Path.GetExtension(fullFileName);
            valueFileName.Text = fileNameWithoutExtension;
            suffixFileName.Text = fileExtension;
        }

        private void chkIncludeTimestamp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncludeTimestamp.Checked)
            {
                lblTimestampFormat.Visible = true;
                lblTimestampFormat.Text = $"Format: {valueFileName.Text}-{DateTime.Now:yyyy-MM-dd-HH_mm_ss}{suffixFileName.Text}";
            }
            else
            {
                lblTimestampFormat.Visible = false;
                lblTimestampFormat.Text = $"Format: N/A";
            }
        }

        private void currentVideoFile_Click(object sender, EventArgs e)
        {
        }

        private async void optionsPanel_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            fbd.Title = "Browse for a video file";
            fbd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = fbd.FileName;
                if (string.IsNullOrEmpty(selectedPath)) return;

                if (!File.Exists(selectedPath))
                {
                    string content = "The selected folder does not exist, please try with a different folder.";
                    MessageBox.Show(content, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                currentVideoFile.Text = Path.GetFileName(selectedPath);
                currentVideoFile.Tag = selectedPath;
                await fetchVideo(selectedPath);
            }
        }

        private void warningNotice_MouseEnter(object sender, EventArgs e)
        {
            warningNotice.Font = new Font(warningNotice.Font, FontStyle.Underline);
        }

        private void warningNotice_MouseLeave(object sender, EventArgs e)
        {
            warningNotice.Font = new Font(warningNotice.Font, FontStyle.Regular);
        }

        private void btnResetWarning_Click(object sender, EventArgs e)
        {
            string content = "Reset warning notice? It will show once on restart.";
            if (MessageBox.Show(content, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.firstLaunch = true;
                Properties.Settings.Default.Save();
            }
        }

        private void warningNotice_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.ffmpeg.org/download.html");
        }

        private void valueTargetPercentage_MouseDown(object sender, MouseEventArgs e)
        {
            int trackWidth = valueTargetPercentage.Width;
            int max = valueTargetPercentage.Maximum;
            int min = valueTargetPercentage.Minimum;

            double estimatedValue = (double)(e.X) / trackWidth * (max - min) + min;
            int snapIncrement = 10;

            int snappedValue = (int)Math.Round(estimatedValue / snapIncrement) * snapIncrement;

            if (snappedValue < min)
                snappedValue = min;
            else if (snappedValue > max)
                snappedValue = max;

            valueTargetPercentage.Value = snappedValue;
            suffixTargetPercentage.Text = snappedValue.ToString();
        }
    }
}
