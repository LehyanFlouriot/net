using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace Hector
{
    public class Marque
    {
        public int RefMarque { get; set; }
        public string Nom { get; set; }
        public Marque(int refMarque, string nom)
        {
            RefMarque = refMarque;
            Nom = nom;
        }

        public Marque(string nom)
        {

            Nom = nom;
        }

        internal static int Existe(string NomMarque)
        {
            int Ex = -1;
            var Command = new SQLiteCommand("Select RefMarque from Marques where nom like '" + NomMarque + "'", DataBase.Conn);
            SQLiteDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                Ex = Reader.GetInt32(0);
            }
            return Ex;
        }

        internal static Marque InsererMarque(string NomMarque)
        {
            var Command = new SQLiteCommand("INSERT INTO Marques (Nom) VALUES ('" + NomMarque + "')", DataBase.Conn);
            Command.ExecuteNonQuery();
            var Command2 = new SQLiteCommand("Select RefMarque from Marques ORDER BY RefMarque DESC LIMIT 0, 1", DataBase.Conn);
            SQLiteDataReader Reader = Command2.ExecuteReader();
            Reader.Read();
            int RefMarque = Reader.GetInt32(0);
            return new Marque(RefMarque, NomMarque);
        }
    }
}
