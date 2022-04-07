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
     

        

        /// <summary>
        /// Retourne la liste des SousFamilles de la base de donnée
        /// </summary>
        /// <param name="DatabasePath"></param>
        /// <returns></returns>
        public static List<SousFamille> GetSousFamilles(string DatabasePath)
        {
            List<SousFamille> SousFamilles = new List<SousFamille>();

            using (SQLiteConnection DataBase = new SQLiteConnection("Data Source =" + DatabasePath))
            {
                DataBase.Open();
                SQLiteCommand SelectCommand = new SQLiteCommand("SELECT * from SousFamilles", DataBase);

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
                DataBase.Close();
            }

            return SousFamilles;
        }


        /// <summary>
        /// Retourne la liste des Familles de la base de donnée
        /// </summary>
        /// <param name="DatabasePath"></param>
        /// <returns></returns>
        public static List<Famille> GetFamilles(string DatabasePath)
        {
            List<Famille> Familles = new List<Famille>();

            using (SQLiteConnection DataBase = new SQLiteConnection("Data Source =" + DatabasePath))
            {
                DataBase.Open();
                SQLiteCommand SelectCommand = new SQLiteCommand("SELECT * from Familles", DataBase);

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
                DataBase.Close();
            }

            return Familles;
        }
        /// <summary>
        /// Retourne la liste des Articles de la base de donnée
        /// </summary>
        /// <param name="DatabasePath"></param>
        /// <returns></returns>
        public static List<Article> GetArticles(string DatabasePath)
        {
            List<Article> Articles = new List<Article>();

            using (SQLiteConnection DataBase = new SQLiteConnection("Data Source =" + DatabasePath))
            {
                DataBase.Open();
                SQLiteCommand SelectCommand = new SQLiteCommand("SELECT * from Articles", DataBase);

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
                DataBase.Close();
            }

            return Articles;
        }


        /// <summary>
        /// Retourne la liste des Marques de la base de donnée
        /// </summary>
        /// <param name="DatabasePath"></param>
        /// <returns></returns>
        public static List<Marque> GetMarques(string DatabasePath)
        {
            List<Marque> Marques = new List<Marque>();

            using (SQLiteConnection DataBase = new SQLiteConnection("Data Source =" + DatabasePath))
            {
                
                DataBase.Open();
                SQLiteCommand SelectCommand = new SQLiteCommand("SELECT * from Marques", DataBase);

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
                DataBase.Close();
            }

            return Marques;
        }
        /*
        public static List<String> GetData(string DatabasePath)
        {
            List<String> entries = new List<string>();

            string dbpath = Path.Combine(DatabasePath);
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }
        */



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
