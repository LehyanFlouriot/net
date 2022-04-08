using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace Hector
{
    public class Famille
    {
        public int RefFamille { get; set; }
        public string Nom { get; set; }

        public Famille(int RefFamille, string Nom)
        {
            this.RefFamille = RefFamille;
            this.Nom = Nom;
        }
        public Famille(string Nom)
        {
            this.Nom = Nom;
        }

        public static Famille InsererFamille(string Nom)
        {
            var Command = new SQLiteCommand("INSERT INTO familles (Nom) VALUES ('" + Nom + "')", DataBase.Conn);
            Command.ExecuteNonQuery();
            var Command2 = new SQLiteCommand("Select RefFamille from Familles ORDER BY RefFamille DESC LIMIT 0, 1", DataBase.Conn);
            SQLiteDataReader Reader = Command2.ExecuteReader();
            Reader.Read();
            int RefFamille = Reader.GetInt32(0);
            return new Famille(RefFamille,Nom);
        }

        internal static int Existe(string NomFamille)
        {
            int Ex = -1;
            var Command = new SQLiteCommand("SELECT RefFamille from familles where nom like '"+NomFamille+"'", DataBase.Conn);
            SQLiteDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                Ex = Reader.GetInt32(0);
            }
            return Ex;
        }
    }
}
