using System;
using System.IO;
using System.Windows.Forms;

namespace TextParser
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();

            txtHeaderSymbol.Text = Program._HeaderSymbol;
            txtRootPath.Text = Program._RootPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program._HeaderSymbol = txtHeaderSymbol.Text;
            Program._RootPath = txtRootPath.Text;
            this.Close();
        }

        private void btnFolderDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SrcDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Seleziona la directory di radice di lavoro",
                RootFolder = Environment.SpecialFolder.Desktop,
                SelectedPath = Program._RootPath
            };

            if (DialogResult.OK == SrcDlg.ShowDialog())
            {
                if (Directory.Exists(SrcDlg.SelectedPath))
                {
                    txtRootPath.Text = SrcDlg.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Il percorso selezionato non esiste.", "Errore", MessageBoxButtons.OK);
                    txtRootPath.Text = "";
                }
            }
        }
    }
}
