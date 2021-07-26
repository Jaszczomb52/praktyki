using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Wymówki
{
    class Files
    {
        public string DirectoryPath { get; set; }
        public DateTime LastFileMod { get; private set; }
        public DateTime LastFileCreat { get; private set; }
        public string Name { get; private set; }
        public string Text { get; private set; }
        public string Result { get; private set; }
        public DialogResult GetDirectory()
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult res = dialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    DirectoryPath = dialog.SelectedPath;
                    return res;
                }
                else
                {
                    return res;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd podczas pobierania ścieżki");
                return DialogResult.None;
            }
        }

        public void SaveFile(string text, string result, DateTime time)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    InitialDirectory = DirectoryPath,
                    Filter = "Pliki tekstowe (*.txt) | *.txt",
                    DefaultExt = ".txt"
                };
                dialog.ShowDialog();
                if (dialog.CheckFileExists)
                {
                    File.Delete(dialog.FileName);
                }
                using (StreamWriter writer = new StreamWriter(dialog.FileName))
                {
                    writer.WriteLine(text);
                    writer.WriteLine(result);
                    writer.WriteLine(time);
                    writer.Flush();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bład podczas zapisywania pliku");
            }
        }

        public void LoadFile()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    InitialDirectory = DirectoryPath,
                    Filter = "Pliki tekstowe (*.txt) | *.txt"
                };
                dialog.ShowDialog();
                if (dialog.FileName.Length != 0)
                {
                    using (StreamReader reader = new StreamReader(dialog.FileName))
                    {
                        Text = reader.ReadLine();
                        Result = reader.ReadLine();
                        LastFileCreat = File.GetCreationTime(dialog.FileName);
                        LastFileMod = DateTime.Parse(reader.ReadLine());
                        Name = dialog.SafeFileName;
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd podczas ładowania pliku");
            }
        }

        public void LoadRandomFile()
        {
            try
            {
                Random rand = new Random();
                List<string> files = Directory.GetFiles(DirectoryPath).ToList();
                string file = files[rand.Next(files.Count)];
                using (StreamReader reader = new StreamReader(file))
                {
                    Text = reader.ReadLine();
                    Result = reader.ReadLine();
                    LastFileCreat = File.GetCreationTime(file);
                    LastFileMod = DateTime.Parse(reader.ReadLine());
                    Name = file.Substring(DirectoryPath.Length+1, file.Length - DirectoryPath.Length-1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd podczas ładowania losowego pliku");
            }
        }
    }
}