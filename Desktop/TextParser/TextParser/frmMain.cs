using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextParser
{
    public partial class frmMain : Form
    {
        private string SourceFolder = "";
        private string DestinationFolder = "";
        private string Header = "->";

        private List<Fragment> AllThatStuff = new List<Fragment>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFolderSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SrcDlg = new FolderBrowserDialog();
            SrcDlg.ShowNewFolderButton = true;
            SrcDlg.Description = "Seleziona la cartella di origine dei file da scansionare";
            SrcDlg.RootFolder = Environment.SpecialFolder.Desktop;

            if (DialogResult.OK == SrcDlg.ShowDialog())
            {
                if (Directory.Exists(SrcDlg.SelectedPath))
                {
                    SourceFolder = SrcDlg.SelectedPath;
                    txtFolderSource.Text = SrcDlg.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Il percorso selezionato non esiste.", "Errore", MessageBoxButtons.OK);
                    SourceFolder = "";
                    txtFolderSource.Text = "";
                }
            }

            EnableButtons();
        }

        private void btnFolderDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DestDlg = new FolderBrowserDialog();
            DestDlg.ShowNewFolderButton = true;
            DestDlg.Description = "Seleziona la cartella radice di destinazione dei file da generare";
            DestDlg.RootFolder = Environment.SpecialFolder.Desktop;
            if (DialogResult.OK == DestDlg.ShowDialog())
            {
                if (Directory.Exists(DestDlg.SelectedPath))
                {
                    if (CheckDirectoryAccess(DestDlg.SelectedPath))
                    {
                        DestinationFolder = DestDlg.SelectedPath;
                        txtFolderDestination.Text = DestDlg.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("L'utente corrente non ha tutti i permessi di scrittura (directory e file) sul percorso selezionato.", "Errore", MessageBoxButtons.OK);
                        DestinationFolder = "";
                        txtFolderDestination.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Il percorso selezionato non esiste.", "Errore", MessageBoxButtons.OK);
                    DestinationFolder = "";
                    txtFolderDestination.Text = "";
                }
            }

            EnableButtons();
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
                    string[] lines = File.ReadAllLines(f);
                    string identifier = "";
                    string current_fragment = "";
                    bool HeaderFound = false;
                    foreach (string line in lines)
                    {
                        RowIndex++;
                        if (line.StartsWith(Header))
                        {
                            //nuovo simbolo di inizio frammento:
                            if (HeaderFound)
                            {
                                //avevo un frammento in corso, lo chiudo e lo memorizzo
                                AllThatStuff.Add(new Fragment(SourceFolder, f, RowIndex, identifier, current_fragment));

                                //reset
                                HeaderFound = true;
                                identifier = "";
                                current_fragment = "";

                                //inizio nuovo frammento
                                ParseLine(line, ref identifier, ref current_fragment);
                                

                            }
                            else
                            {
                                //reset
                                HeaderFound = true;
                                identifier = "";
                                current_fragment = "";

                                ParseLine(line, ref identifier, ref current_fragment);
                            }
                        }
                        else
                        {
                            if (HeaderFound)
                            {
                                //concateno il frammento corrente
                                current_fragment += Environment.NewLine + line;
                            }
                        }
                    }

                    //inserisco nella griglia i frammenti trovati
                    foreach (Fragment fff in AllThatStuff)
                    {
                        this.dgvFragments.Rows.Add(fff.Filename, fff.Row.ToString(), fff.Identifier, fff.Text.Length > 50 ? fff.Text.Substring(0, 50) + " [cut]" : fff.Text);
                    }



                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
            string error = "";
            foreach (Fragment fff in AllThatStuff)
            {
                rtbLog.AppendText("Identificativo: " + fff.Identifier + Environment.NewLine);
                fff.Save(ref error);
                if (!string.IsNullOrEmpty(error))
                {
                    rtbLog.AppendText(error + Environment.NewLine);
                }
            }
        }

        #region PRIVATE MTD

        private void EnableButtons()
        {
            if (Directory.Exists(SourceFolder)
                && Directory.Exists(DestinationFolder)
                && CheckDirectoryAccess(DestinationFolder))
            {
                btnScan.Enabled = true;
                btnGenerate.Enabled = true;
            }
            else
            {
                btnScan.Enabled = false;
                btnGenerate.Enabled = false;
            }

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
            int pos1 = line.IndexOf(Header) + Header.Length;
            int pos2 = line.IndexOf(" ", pos1);
            int pos3 = line.IndexOf(" ", pos2 + 1);
            identifier = line.Substring(pos2 + 1, pos3 - 3);
            current_fragment = line.Substring(pos3 + 1);
        }
        #endregion

    }

    public class Fragment
    {
        #region Variabili membro
        private string mFilename = String.Empty;
        private int mRow = 0;
        private string mIdentifier = String.Empty;
        private string mText = String.Empty;

        private string mRootPath = string.Empty;
        #endregion


        #region Costruttori
        public Fragment()
        {
        }

        public Fragment(string rootPath, string filename, int row, string identifier, string text)
        {
            mRootPath = rootPath;
            mFilename = filename;
            mRow = row;
            mIdentifier = identifier;
            mText = text;
        }

        #endregion

        #region Proprietà

        public string RootPath
        {
            get { return mRootPath; }
            set { mRootPath = value; }
        }

        public string Filename
        {
            get { return mFilename; }
            set { mFilename = value; }
        }

        public int Row
        {
            get { return mRow; }
            set { mRow = value; }
        }


        public string Identifier
        {
            get { return mIdentifier; }
            set { mIdentifier = value; }
        }

        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }

        #endregion

        #region Metodi

        public bool Save(ref string error)
        {
            bool res = false;

            if (!Directory.Exists(Path.Combine(mRootPath, Identifier)))
                Directory.CreateDirectory(Path.Combine(mRootPath, Identifier));

            if (!File.Exists(Path.Combine(mRootPath, mIdentifier, mFilename)))
            {
                try
                {
                    using (FileStream fs = File.Create(Path.Combine(mRootPath, mIdentifier, mFilename)))
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes(mText);
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
                error = "File " + Path.Combine(mRootPath, mIdentifier, mFilename) + " esistente.";
                res = false;
            }

            return res;
        }
        #endregion
    }
}
