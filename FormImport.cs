using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hector
{
    public partial class FormImport : Form
    {


        private string ImportFilePath = null; 
        
        public FormImport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Lors du clic sur Parcourir, nous ouvrons une openFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
              
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    FilePath = openFileDialog.FileName;

                   

                }
                
                this.FilePath.Text = FilePath;
                ImportFilePath = this.FilePath.Text;
            }
        }
        /// <summary>
        /// lance l’intégration en mode ajout (L’import met à jour les éléments divergents et ajoute les nouveaux).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if(ImportFilePath == null)
            {
                InvalidPath();
                return;
            }
            DataBase.ReadCsv(ImportFilePath, this.ProgressBar);
            ShowImportResult();
        }
        /// <summary>
        /// Clic sur le boutton ecraser, ecrase la base de donnée actuelle et la remplie avec les nouvelles données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOverwrite_Click(object sender, EventArgs e)
        {
            if (ImportFilePath == null)
            {
                InvalidPath();
                return;
            }
            DataBase.RemoveAll();
            DataBase.ReadCsv(ImportFilePath, this.ProgressBar);
            ShowImportResult();
        }
        /// <summary>
        /// Creer une message box qui affiche les resultats de l'import
        /// </summary>
        private void ShowImportResult()
        {
            
            DialogResult Result = MessageBox.Show("Données ajoutées avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //L'utilisateur a dit ok
            if(Result == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Aucun chemin spécifié
        /// </summary>
        private void InvalidPath()
        {
            DialogResult Result = MessageBox.Show("Veuillez saisir un chemin", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void FormImport_Load(object sender, EventArgs e)
        {

        }

        private void FilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxDescription_Click(object sender, EventArgs e)
        {

        }
    }
}
