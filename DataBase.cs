using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Hector
{
    public abstract class DataBase
    {
        public static SQLiteConnection Conn;
        private static List<Famille> Familles;
        private static List<SousFamille> SousFamilles;
        private static List<Marque> Marques;
        private static List<Article> Articles;
     
        
        public static Article GetArticleWithRef(string Ref)
        {
            //requete sql et remplir les champs du coup
            
            string RefArticle;
            string Description;
            int RefSousFamille;
            int RefMarque;
            float PrixHT;
            int Quantite;

            return new Article(RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite);
         
        }
        
        public static List<SousFamille> GetSousFamillesOf(int FamilleRefFamille)
        {
            List<SousFamille> SousFamilles = new List<SousFamille>();
            SQLiteCommand SelectCommand = new SQLiteCommand("SELECT RefSousFamille,RefFamille,Nom from SousFamilles where RefFamille = " + FamilleRefFamille, DataBase.Conn);

            SQLiteDataReader Reader = SelectCommand.ExecuteReader();

            
            while (Reader.Read())
            {
                int RefSousFamille = Reader.GetInt32(0);

                int RefFamille = Reader.GetInt32(1);

                string Nom = Reader.GetString(2);

                //Creation de l'objet sous famille
                SousFamille NewSousFamille = new SousFamille(RefSousFamille, RefFamille, Nom);
                //ajout au tableau de sous familles
                SousFamilles.Add(NewSousFamille);
            }

            return SousFamilles;
        }

        internal static void InitializeList(TreeView TreeView1)
        {
            TreeView1.Nodes.Clear();
            TreeNode MainNode = new TreeNode();
            MainNode.Name = "AllArticles";
            MainNode.Text = "Tous les articles";
            TreeView1.Nodes.Add(MainNode);
            TreeNode FamilleNode = new TreeNode();
            FamilleNode.Name = "Familles";
            FamilleNode.Text = "Familles";
            TreeView1.Nodes.Add(FamilleNode);
            TreeNode MarquesNode = new TreeNode();
            MarquesNode.Name = "Marques";
            MarquesNode.Text = "Marques";
            TreeView1.Nodes.Add(MarquesNode);
            
            List<Marque> Marques = DataBase.GetMarques();
            List<Famille> Familles = DataBase.GetFamilles();
            for (int i = 0; i < Familles.Count; i++)
            {
                TreeNode FamilleXNode = new TreeNode();
                FamilleXNode.Name = "Familles" + Familles[i].RefFamille;
                FamilleXNode.Text = Familles[i].Nom;
                FamilleNode.Nodes.Add(FamilleXNode);
                List<SousFamille> SousFamilles = DataBase.GetSousFamillesOf(Familles[i].RefFamille);
                for (int j = 0; j < SousFamilles.Count; j++)
                {
                    TreeNode SousFamilleXNode = new TreeNode();
                    SousFamilleXNode.Name = "SousFamille" + SousFamilles[j].RefSousFamille;
                    SousFamilleXNode.Text = SousFamilles[j].Nom;
                    FamilleXNode.Nodes.Add(SousFamilleXNode);
                }
            }
            for (int i = 0; i < Marques.Count; i++)
            {
                TreeNode MarqueXNode = new TreeNode();
                MarqueXNode.Name = "Marque" + Marques[i].RefMarque;
                MarqueXNode.Text = Marques[i].Nom;
                MarquesNode.Nodes.Add(MarqueXNode);
            }
        }
        /// <summary>
        /// Retourne la liste des SousFamilles de la base de donnée
        /// </summary>
        /// <param name="DatabasePath"></param>
        /// <returns></returns>
        public static List<SousFamille> GetSousFamilles()
        {
            List<SousFamille> SousFamilles = new List<SousFamille>();

                SQLiteCommand SelectCommand = new SQLiteCommand("SELECT RefSousFamille,RefFamille,Nom from SousFamilles", Conn);

                SQLiteDataReader Reader = SelectCommand.ExecuteReader();

                //Tant que il y a une marque
                while (Reader.Read())
                {


                    /*
                     * VERSION AVEC OBJECT[]
                     * 
                    object[] values = new object[Reader.FieldCount];

                    Reader.GetValues(values);

                    foreach(object o in values)
                    {
                        Console.WriteLine(o);
                    }
                   */
                    int RefSousFamille = Reader.GetInt32(0);

                    int RefFamille = Reader.GetInt32(1);

                    string Nom = Reader.GetString(2);

                    //Creation de l'objet marque
                    SousFamille NewSousFamille = new SousFamille(RefSousFamille, RefFamille, Nom);
                    //ajout au tableau de marques
                    SousFamilles.Add(NewSousFamille);
                }

            return SousFamilles;
        }

        internal static void RemoveAll()
        {
            var Command = new SQLiteCommand("Delete from Articles", DataBase.Conn);
            Command.ExecuteNonQuery();
            Command = new SQLiteCommand("Delete from SousFamilles", DataBase.Conn);
            Command.ExecuteNonQuery();
            Command = new SQLiteCommand("Delete from Familles", DataBase.Conn);
            Command.ExecuteNonQuery();
            Command = new SQLiteCommand("Delete from Marques", DataBase.Conn);
            Command.ExecuteNonQuery();
        }


        /// <summary>
        /// Retourne la liste des Familles de la base de donnée
        /// </summary>
        /// <param name="DatabasePath"></param>
        /// <returns></returns>
        public static List<Famille> GetFamilles()
        {
            List<Famille> Familles = new List<Famille>();

                SQLiteCommand SelectCommand = new SQLiteCommand("SELECT RefFamille,Nom from Familles", Conn);

                SQLiteDataReader Reader = SelectCommand.ExecuteReader();

                //Tant que il y a une marque
                while (Reader.Read())
                {


                    /*
                     * VERSION AVEC OBJECT[]
                     * 
                    object[] values = new object[Reader.FieldCount];

                    Reader.GetValues(values);

                    foreach(object o in values)
                    {
                        Console.WriteLine(o);
                    }
                   */

                    int RefFamille = Reader.GetInt32(0);
                    string Nom = Reader.GetString(1);

                    //Creation de l'objet marque
                    Famille NewFamille = new Famille(RefFamille, Nom);
                    //ajout au tableau de marques
                    Familles.Add(NewFamille);
                }

            return Familles;
        }
        /// <summary>
        /// Retourne la liste des Articles de la base de donnée
        /// </summary>
        /// <param name="DatabasePath"></param>
        /// <returns></returns>
        public static List<Article> GetArticles()
        {
            List<Article> Articles = new List<Article>();

                SQLiteCommand SelectCommand = new SQLiteCommand("SELECT RefArticle,Description,RefSousFamille,RefMarque,PrixHT,Quantite from Articles", Conn);

                SQLiteDataReader Reader = SelectCommand.ExecuteReader();

                //Tant que il y a un article
                while (Reader.Read())
                {


                    /*
                     * VERSION AVEC OBJECT[]
                     * 
                    object[] values = new object[Reader.FieldCount];

                    Reader.GetValues(values);

                    foreach(object o in values)
                    {
                        Console.WriteLine(o);
                    }
                   */

                    string RefArticle = Reader.GetString(0);
                    string Description = Reader.GetString(1);
                    int RefSousFamille = Reader.GetInt32(2);
                    int RefMarque = Reader.GetInt32(3);
                    float PrixHT = Reader.GetFloat(4);
                    int Quantite = Reader.GetInt32(5);

                    //Creation de l'objet marque
                    Article NewArticle = new Article(RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite);
                    //ajout au tableau de marques
                    Articles.Add(NewArticle);
                }

            return Articles;
        }


        /// <summary>
        /// Retourne la liste des Marques de la base de donnée
        /// </summary>
        /// <param name="DatabasePath"></param>
        /// <returns></returns>
        public static List<Marque> GetMarques()
        {
            List<Marque> Marques = new List<Marque>();

                SQLiteCommand SelectCommand = new SQLiteCommand("SELECT RefMarque,Nom from Marques", Conn);

                SQLiteDataReader Reader = SelectCommand.ExecuteReader();

                //Tant que il y a une marque
                while (Reader.Read())
                {

                    
                    /*
                     * VERSION AVEC OBJECT[]
                     * 
                    object[] values = new object[Reader.FieldCount];

                    Reader.GetValues(values);

                    foreach(object o in values)
                    {
                        Console.WriteLine(o);
                    }
                   */

                    int RefMarque = Reader.GetInt32(0);
                    string Nom = Reader.GetString(1);

                    //Creation de l'objet marque
                    Marque NewMarque = new Marque(RefMarque, Nom);
                    //ajout au tableau de marques
                    Marques.Add(NewMarque);
                }
            

            return Marques;
        }


        /// <summary>
        /// Read a csv file and create a dataset with the information in it, then we will fill the databse with these data
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static void ReadCsv(string FilePath, ProgressBar ProgressBar)
        {
            try
            {
                Familles = new List<Famille>();
                SousFamilles = new List<SousFamille>();
                Marques = new List<Marque>();
                Articles = new List<Article>();
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader Sr = new StreamReader(FilePath))
                {
                    //The number of lines in the file
                    int LineCount = File.ReadLines(FilePath).Count() - 1;
                    string Line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    int Iterator = 0; // To skip the first line
                    while ((Line = Sr.ReadLine()) != null)
                    {
                        if (Iterator != 0)
                        {
                            
                            string[] SplittedLine = Line.Split(';');
                            string Description = SplittedLine[0];
                            string Ref = SplittedLine[1];
                            string NomMarque = SplittedLine[2];
                            string NomFamille = SplittedLine[3];
                            string NomSousFamille = SplittedLine[4];
                            float Prix = float.Parse(SplittedLine[5]);

                            int RefFamille = Famille.Existe(NomFamille);
                            if(RefFamille == -1)
                            {
                                Famille NewFam = Famille.InsererFamille(NomFamille);
                                Familles.Add(NewFam);
                                RefFamille = NewFam.RefFamille;
                            }

                            int RefSousFamille = SousFamille.Existe(NomSousFamille);
                            if (RefSousFamille == -1)
                            {
                                SousFamille NewSousFam = SousFamille.InsererSousFamille(RefFamille, NomSousFamille);
                                SousFamilles.Add(NewSousFam);
                                RefSousFamille = NewSousFam.RefSousFamille;
                            }

                            int RefMarque = Marque.Existe(NomMarque);
                            if(RefMarque == -1)
                            {
                                Marque NewMarque = Marque.InsererMarque(NomMarque);
                                Marques.Add(NewMarque);
                                RefMarque = NewMarque.RefMarque;
                            }
                            Article NewArticle = Article.InsererArticle(Ref, Description, RefSousFamille, RefMarque, Prix, 1);
                            Articles.Add(NewArticle);
                         

                        }
                        Iterator++;
                        ProgressBar.Value = ((Iterator-1) / LineCount) * ProgressBar.Maximum; // Fill the progresBar
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                
            }
            
        }


        /// <summary>
        /// Creer une connexion avec la base de donnée passé en parametre
        /// </summary>
        /// <param name="PathBdd"></param>
        /// <returns></returns>
        public static void CreateConnection(string PathBdd)
        {
            // Create a new database connection:
            Conn = new SQLiteConnection(new SQLiteConnection("Data Source =" + PathBdd));
            // Open the connection:
            try
            {
                Conn.Open();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
