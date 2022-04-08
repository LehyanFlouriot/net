using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace Hector
{
    public class Article
    {


        public Article(string RefArticle, string Description, int RefSousFamille, int RefMarque, float PrixHT, int Quantite)
        {
            this.RefArticle = RefArticle;
            this.Description = Description;
            this.RefSousFamille = RefSousFamille;
            this.RefMarque = RefMarque;
            this.PrixHT = PrixHT;
            this.Quantite = Quantite;
        }

        public Article(string Description)
        {
            this.Description = Description;
        }


        public string RefArticle { get; set; }
        public string Description { get; set; }
        public int RefSousFamille { get; set; }
        
        public int RefMarque { get; set; }
       
        public float PrixHT { get; set; }
        public int Quantite { get; set; }
        internal static int Existe(string RefArticle)
        {
            int Ex = -1;
            var Command = new SQLiteCommand("SELECT RefArticle from Articles where nom RefArticle '" + RefArticle + "'", DataBase.Conn);
            SQLiteDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                Ex = 1;
            }
            return Ex;
        }

        internal static Article InsererArticle(string @Ref, string Description, int RefSousFamille, int RefMarque, float Prix, int Quantite)
        {
            var Command = new SQLiteCommand("INSERT INTO Articles(RefArticle,Description,RefSousFamille,RefMarque,PrixHT,Quantite) values('" + Ref + "','" + Description + "','" + RefSousFamille + "','" + RefMarque + "','" + Prix + "','" + Quantite + "') ON CONFLICT(RefArticle) DO UPDATE SET Quantite=Quantite+1", DataBase.Conn);
            Command.ExecuteNonQuery();
            return new Article(Ref, Description, RefSousFamille, RefMarque, Prix, Quantite);
        }
    }
}
