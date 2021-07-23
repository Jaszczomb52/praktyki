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
        public DialogResult GetDirectory()
        {
            try
            {
                var dialog = new FolderBrowserDialog();
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
            catch(Exception)
            {
                MessageBox.Show("Błąd podczas pobierania ścieżki");
                return DialogResult.None;
            }
        }

        public void SaveFile(string text, string result, DateTime time)
        {
            try
            {
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = DirectoryPath;
                dialog.Filter = "Pliki tekstowe (*.txt) | *.txt";
                dialog.DefaultExt = ".txt";
                dialog.ShowDialog();
                StreamWriter writer = new StreamWriter(dialog.FileName);
                writer.WriteLine(text);
                writer.WriteLine(result);
                writer.Flush();
                writer.Close();
                File.SetLastWriteTime(dialog.FileName, time);
            }
            catch(Exception)
            {
                MessageBox.Show("Bład podczas zapisywania pliku");
            }
        }

        public string LoadFile()
        {
            try
            {
                var dialog = new OpenFileDialog();
                dialog.InitialDirectory = DirectoryPath;
                dialog.Filter = "Pliki tekstowe (*.txt) | *.txt";
                dialog.ShowDialog();
                if (dialog.FileName.Length != 0)
                {
                    FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(fs);
                    LastFileCreat = File.GetCreationTime(dialog.FileName);
                    LastFileMod = File.GetLastWriteTime(dialog.FileName);
                    return reader.ReadLine() + "*;&&;*" + reader.ReadLine();
                }
                else
                {
                    return "no_file";
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd podczas ładowania pliku");
                return "no_file";
            }
        }

        public string LoadRandomFile()
        {
            try
            {
                List<string> files = Directory.GetFiles(DirectoryPath).ToList();
                Random rand = new Random();
                string file = files[rand.Next(files.Count)];
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                LastFileCreat = File.GetCreationTime(file);
                LastFileMod = File.GetLastWriteTime(file);
                return reader.ReadLine() + "*;&&;*" + reader.ReadLine();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd podczas ładowania losowego pliku");
                return "no_file";
            }
        }


        }
    }
