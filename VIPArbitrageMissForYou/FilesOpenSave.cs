using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VIPArbitrageMissForYou
{
    public class FilesOpenSave
    {
        static string con = "";
        UpgradeMessageBox box = new UpgradeMessageBox(con);

        public void CreateTXTDoc(ObservableCollection<double> _arbres1, ObservableCollection<double> _arbres2, ObservableCollection<string> _arbres3, ObservableCollection<string> _arbres4)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "DocumentResult"; // Default file name
                dlg.DefaultExt = ".txt"; // Default file extension
                dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
                                                            // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();
                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;
                string text ="~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Results~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
                for (int j = 1; _arbres1.Count >= j; j++)
                {
                    text += _arbres4[j - 1].ToString()+"\t|";
                    text += _arbres3[j - 1].ToString() + "\t|";
                    text += _arbres2[j - 1].ToString() + "\t|";
                    text += _arbres1[j - 1].ToString() + "\n";
                }
                text += "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

                File.WriteAllText(dlg.FileName, text);
                }
            }
            catch (Exception ex) {
                con = ex.Message;
                box = new UpgradeMessageBox(con);
                box.Show();
            }
        }
        public string FilesOpen(string name)
        {
            string readfile = "";
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = name; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "All files (*.*)|*.*"; // Filter files by extension

            try
            {
                // Show open file dialog box
                bool? result = dialog.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    readfile = dialog.FileName;
                }
                //Read file
                readfile = File.ReadAllText(dialog.FileName);
                return readfile.ToString();
            }
            catch(Exception ex) {
                con = ex.Message;
                box = new UpgradeMessageBox(con);
                box.Show();
            }
            return "";
        }
    }
}
