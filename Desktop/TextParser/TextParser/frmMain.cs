using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextParser
{
    public partial class FrmMain : Form
    {
        private string SourceFolder = "";
        private string DestinationFolder = "";
        private string Header = Program._HeaderSymbol; // "->";

        private List<Fragment> AllThatStuff = new List<Fragment>();

        public FrmMain()
        {
            InitializeComponent();
            lblSourceError.Text = "";
            lblDestError.Text = "";
        }

        private void btnFolderSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SrcDlg = new FolderBrowserDialog();
            SrcDlg.ShowNewFolderButton = true;
            SrcDlg.Description = "Seleziona la cartella di origine dei file da scansionare";
            SrcDlg.RootFolder = Environment.SpecialFolder.Desktop;
            SrcDlg.SelectedPath = Program._RootPath;

            if (DialogResult.OK == SrcDlg.ShowDialog())
            {
                if (Directory.Exists(SrcDlg.SelectedPath))
                {
                    SourceFolder = SrcDlg.SelectedPath;
                    txtFolderSource.Text = SrcDlg.SelectedPath;
                    EnableScan(true);
                    lblSourceError.Text = "";
                }
                else
                {
                    lblSourceError.Text = "Il percorso selezionato non esiste.";
                    SourceFolder = "";
                    txtFolderSource.Text = "";
                    EnableScan(false);
                    EnableGenerate(false);
                }
            }
            else
            {
                EnableScan(false);
                EnableGenerate(false);
            }
        }

        private void btnFolderDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DestDlg = new FolderBrowserDialog();
            DestDlg.ShowNewFolderButton = true;
            DestDlg.Description = "Seleziona la cartella radice di destinazione dei file da generare";
            DestDlg.RootFolder = Environment.SpecialFolder.Desktop;
            DestDlg.SelectedPath = Program._RootPath;
            if (DialogResult.OK == DestDlg.ShowDialog())
            {
                if (Directory.Exists(DestDlg.SelectedPath))
                {
                    if (CheckDirectoryAccess(DestDlg.SelectedPath))
                    {
                        DestinationFolder = DestDlg.SelectedPath;
                        txtFolderDestination.Text = DestDlg.SelectedPath;
                        EnableGenerate(true);
                        lblDestError.Text = "";
                    }
                    else
                    {
                        lblDestError.Text = "L'utente corrente non ha tutti i permessi di scrittura (directory e file) sul percorso selezionato.";
                        DestinationFolder = "";
                        txtFolderDestination.Text = "";
                        EnableGenerate(false);
                    }
                }
                else
                {
                    lblDestError.Text = "Il percorso selezionato non esiste.";
                    DestinationFolder = "";
                    txtFolderDestination.Text = "";
                    EnableGenerate(false);
                }
            }
            else
                EnableGenerate(false);


        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            this.dgvFragments.Rows.Clear();
            AllThatStuff.Clear();


            string[] arrFiles = Directory.GetFiles(SourceFolder);
            foreach (string f in arrFiles)
            {
                if (File.Exists(f) && !IsBinary(f, 1))
                {
                    int RowIndex = 0;
                    int CurrentFragmentStartingRowIndex = 0;
                    string[] lines = File.ReadAllLines(f);
                    string Identifier = "";
                    string CurrentFragment = "";
                    bool HeaderFound = false;
                    foreach (string line in lines)
                    {
                        RowIndex++;
                        if (line.StartsWith(Header))
                        {

                            //nuovo simbolo di inizio frammento:
                            if (HeaderFound)
                            {
                                string filename = Path.GetFileName(f);
                                //avevo un frammento in corso, lo chiudo e lo memorizzo
                                AllThatStuff.Add(new Fragment(SourceFolder, filename, CurrentFragmentStartingRowIndex, Identifier, CurrentFragment));

                                //reset
                                HeaderFound = true;
                                Identifier = "";
                                CurrentFragment = "";
                                CurrentFragmentStartingRowIndex = RowIndex;

                                //inizio nuovo frammento
                                ParseLine(line, ref Identifier, ref CurrentFragment);
                                

                            }
                            else
                            {
                                //reset
                                HeaderFound = true;
                                Identifier = "";
                                CurrentFragment = "";
                                CurrentFragmentStartingRowIndex = RowIndex;

                                ParseLine(line, ref Identifier, ref CurrentFragment);
                            }
                        }
                        else
                        {
                            if (HeaderFound)
                            {
                                //ho un frammento in corso, concateno la riga al testo
                                CurrentFragment += Environment.NewLine + line;
                                
                            }
                        }

                        if (RowIndex == lines.Count())
                            AllThatStuff.Add(new Fragment(SourceFolder, Path.GetFileName(f), CurrentFragmentStartingRowIndex, Identifier, CurrentFragment));
                    }

                }
            }

            //inserisco nella griglia i frammenti trovati
            foreach (Fragment f in AllThatStuff)
            {
                this.dgvFragments.Rows.Add(f.Filename, f.Row.ToString(), f.Identifier, f.Text.Length > 50 ? f.Text.Substring(0, 50) + " [cut]" : f.Text);
            }

            if (AllThatStuff.Count > 0)
                EnableGenerate(true);
            else
                EnableGenerate(false);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
            string error = "";
            foreach (Fragment f in AllThatStuff)
            {
                rtbLog.AppendText("Identificativo: " + f.Identifier);
                f.Save(DestinationFolder, ref error);
                if (!string.IsNullOrEmpty(error))
                    rtbLog.AppendText(" ERRORE: " + error + Environment.NewLine);
                else
                    rtbLog.AppendText(" File " + f.Filename + " creato in " + DestinationFolder + Environment.NewLine);
            }
        }

        #region PRIVATE MTD

        private void EnableScan(bool enable)
        {
            btnScan.Enabled = false;

            if (Directory.Exists(SourceFolder))
                btnScan.Enabled = enable;
        }

        private void EnableGenerate(bool enable)
        {
            btnGenerate.Enabled = false;

            if (Directory.Exists(DestinationFolder)
                && CheckDirectoryAccess(DestinationFolder))
                btnGenerate.Enabled = enable;
        }

        private bool CheckDirectoryAccess(string directory)
        {
            bool success = false;
            string tmpFile = Path.Combine(directory, DateTime.Now.ToLongDateString().Replace("/", "") + DateTime.Now.ToLongTimeString().Replace(":", "") + ".txt");
            string tmpDir = Path.Combine(directory, "tmp");

            if (Directory.Exists(directory))
            {
                try
                {
                    using (FileStream fs = new FileStream(tmpFile, FileMode.CreateNew, FileAccess.Write))
                    {
                        fs.WriteByte(0xff);
                    }

                    if (File.Exists(tmpFile))
                    {
                        File.Delete(tmpFile);
                        if (!Directory.Exists(tmpDir))
                        {
                            Directory.CreateDirectory(tmpDir);
                            if (Directory.Exists(tmpDir))
                            {
                                Directory.Delete(tmpDir, true);
                                success = true;
                            }    
                        }
                    }

                    
                }
                catch (Exception)
                {
                    success = false;
                }
            }

            return success;
        }

        public bool IsBinary(string filePath, int requiredConsecutiveNul = 1)
        {
            const int charsToCheck = 8000;
            const char nulChar = '\0';

            int nulCount = 0;

            using (var streamReader = new StreamReader(filePath))
            {
                for (var i = 0; i < charsToCheck; i++)
                {
                    if (streamReader.EndOfStream)
                        return false;

                    if ((char)streamReader.Read() == nulChar)
                    {
                        nulCount++;

                        if (nulCount >= requiredConsecutiveNul)
                            return true;
                    }
                    else
                    {
                        nulCount = 0;
                    }
                }
            }

            return false;
        }


        private void ParseLine(string line, ref string identifier, ref string current_fragment)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\r', '\n' };
            string line1 = line.Substring(Header.Length);
            line1 = line1.Trim();
            string[] arrline1 = line1.Split(delimiterChars, 2, StringSplitOptions.RemoveEmptyEntries);
            identifier = arrline1[0];
            string line2 = line1.Substring(identifier.Length);
            line2 = line2.Trim();
            current_fragment = line2;
        }
        #endregion

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfig cfg = new FrmConfig();
            cfg.ShowDialog();
        }
    }

    public class Fragment
    {
        #region Variabili interne


        #endregion


        #region Costruttori
        public Fragment()
        {
        }

        public Fragment(string rootPath, string filename, int row, string identifier, string text)
        {
            RootPath = rootPath;
            Filename = filename;
            Row = row;
            Identifier = identifier;
            Text = text;
        }

        #endregion

        #region Proprietà

        public string RootPath { get; set; } = String.Empty;
        public string Filename { get; set; } = String.Empty;
        public int Row { get; set; } = 0;
        public string Identifier { get; set; } = String.Empty;
        public string Text { get; set; } = String.Empty;

        #endregion

        #region Metodi

        public bool Save(string DestinationFolder, ref string error)
        {
            bool res = false;

            if (!Directory.Exists(Path.Combine(DestinationFolder, Identifier)))
                Directory.CreateDirectory(Path.Combine(DestinationFolder, Identifier));

            if (!File.Exists(Path.Combine(DestinationFolder, Identifier, Filename)))
            {
                try
                {
                    using (FileStream fs = File.Create(Path.Combine(DestinationFolder, Identifier, Filename)))
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes(Text);
                        fs.Write(txt, 0, txt.Length);
                    }
                    res = true;
                }
                catch (System.Exception ex)
                {
                    error = ex.Message;
                    res = false;
                }
            }
            else
            {
                error = "File " + Path.Combine(DestinationFolder, Identifier, Filename) + " esistente.";
                res = false;
            }

            return res;
        }
        #endregion
    }
}
