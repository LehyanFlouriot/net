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
            DataBase.ReadCsv(ImportFilePath, this.ProgressBar);
        }
        /// <summary>
        /// Clic sur le boutton ecraser, ecrase la base de donnée actuelle et la remplie avec les nouvelles données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOverwrite_Click(object sender, EventArgs e)
        {
            DataBase.RemoveAll();
            DataBase.ReadCsv(ImportFilePath, this.ProgressBar);
        }
        /// <summary>
        /// Creer une message box qui affiche les resultats de l'import
        /// </summary>
        private void ShowImportResult()
        {

        }


        /// <summary>
        /// Insere les données du fichier csv selectionné dans la base de donnée (Hector)
        /// </summary>
        /// <param name="conn"></param>
        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand SqliteCmd;
            /*
            SqliteCmd = conn.CreateCommand();
            
            SqliteCmd.CommandText = "INSERT INTO SampleTable1(Col1, Col2) VALUES('Test3 Text3 ', 3); ";
            SqliteCmd.ExecuteNonQuery();
            */
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
