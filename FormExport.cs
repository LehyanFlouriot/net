using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Hector
{
    public partial class FormExport : Form
    {

        private string ExportFolderPath = null;


        public FormExport()
        {
            InitializeComponent();
        }

        private void FormExport_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Creer une message box qui affiche les resultats de l'export
        /// </summary>
        private void ShowExportResult()
        {

            DialogResult Result = MessageBox.Show("Données exportées avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //L'utilisateur a dit ok
            if (Result == DialogResult.OK)
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


        private void TextBoxDescription_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Parcours les dossier pour choisir un dossier d'export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            var FolderPath = string.Empty;

            using (FolderBrowserDialog openFolderDialog = new FolderBrowserDialog())
            {

                
                

                if (openFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    FolderPath = openFolderDialog.SelectedPath;



                }

                this.FolderPath.Text = FolderPath;
                ExportFolderPath = this.FolderPath.Text;
            }
        }
        /// <summary>
        /// Exporte la base de données dans un fichier csv export.csv au chemin spécifié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExport_Click(object sender, EventArgs e)
        {
            //pas specifié de chemin
            if(ExportFolderPath == null)
            {
                InvalidPath();
                return;
            }

            SQLiteCommand Command = new SQLiteCommand("Select Description, RefArticle, Marques.Nom, Familles.Nom, SousFamilles.Nom, PrixHT from Articles inner join Marques on Articles.RefMarque = Marques.RefMarque inner join SousFamilles on Articles.RefSousFamille = SousFamilles.RefSousFamille inner join Familles on SousFamilles.RefFamille = Familles.RefFamille", DataBase.Conn);
            SQLiteDataReader Reader = Command.ExecuteReader();

            

            
            using (StreamWriter sw = File.CreateText(ExportFolderPath + "\\export.csv"))
            {
                try
                {

                    sw.WriteLine("Description; Ref; Marque; Famille; Sous - Famille; Prix H.T.");
                    



                    while (Reader.Read())
                    {
                        string Description = Reader.GetString(0);
                        string Ref = Reader.GetString(1);
                        string Marque = Reader.GetString(2);
                        string Famille = Reader.GetString(3);
                        string SousFamille = Reader.GetString(4);
                        string PrixHT = Reader.GetString(5);

                        sw.WriteLine(Description + ";" + Ref + ";" + Marque + ";" + Famille + ";" + SousFamille + ";" + PrixHT);
                        Console.WriteLine(Description + ";" + Ref + ";" + Marque + ";" + Famille + ";" + SousFamille + ";" + PrixHT);

                        
                    }
                    sw.Close();
                }
                catch (Exception er)
                {
                    Console.WriteLine("Exception: " + er.Message);
                }
            }

            ShowExportResult();
        }
    }
}
