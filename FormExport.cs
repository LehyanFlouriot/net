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

        private void TextBoxDescription_Click(object sender, EventArgs e)
        {

        }

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

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            /*
            List<Marque> Marques = DataBase.GetMarques("Hector.SQLite");
            Console.WriteLine(Marques.Count);
            List<Famille> Familles = DataBase.GetFamilles("Hector.SQLite");
            Console.WriteLine(Familles.Count);
            List<SousFamille> SousFamilles = DataBase.GetSousFamilles("Hector.SQLite");
            Console.WriteLine(SousFamilles.Count);
            List<Article> Articles = DataBase.GetArticles("Hector.SQLite");
            Console.WriteLine(Articles.Count);
            foreach (Article Article in Articles)
            {
                //On trouve la marque associée
                Marque Marque = Marques.Find(x => x.RefMarque == Article.RefMarque);
                string NomMarque = Marque.Nom;
                
                //On trouve la sousfamille associée
                SousFamille SousFamille = SousFamilles.Find(x => x.RefSousFamille == Article.RefSousFamille);
                string NomSousFamille = SousFamille.Nom;
                
                //On trouve la sousfamille associée
                Famille Famille = Familles.Find(x => x.RefFamille == SousFamille.RefFamille);
                string NomFamille = Famille.Nom;


                Console.WriteLine("Article Desc : "+Article.Description+" Ref : " + Article.RefArticle + " Marque : " + NomMarque + " Famille : " + NomFamille + " Sous famille : " + NomSousFamille+ " Prix : " + Article.PrixHT);

            }
            */
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
        }
    }
}
