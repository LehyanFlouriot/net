using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace Hector
{
    public class SousFamille
    {
        public int RefSousFamille { get; set; }
        public int RefFamille { get; set; }

        public string Nom { get; set; }
        public SousFamille(int RefSF, int RefF, string nom)
        {
            RefSousFamille = RefSF;
            RefFamille = RefF;
            
            Nom = nom;
        }
        

        internal static int Existe(string NomSousFamille)
        {
            int Ex = -1;
            var Command = new SQLiteCommand("Select RefSousFamille from SousFamilles where nom like '" + NomSousFamille + "'", DataBase.Conn);
            SQLiteDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                Ex = Reader.GetInt32(0);
            }
            return Ex;
        }

        internal static SousFamille InsererSousFamille(int RefFamille, string NomSousFamille)
        {
            var Command = new SQLiteCommand("INSERT INTO sousfamilles(RefFamille,Nom) values('" + RefFamille + "','" + NomSousFamille + "')", DataBase.Conn);
            Command.ExecuteNonQuery();
            var Command2 = new SQLiteCommand("Select RefSousFamille from SousFamilles ORDER BY RefSousFamille DESC LIMIT 0, 1", DataBase.Conn);
            SQLiteDataReader Reader = Command2.ExecuteReader();
            Reader.Read();
            int RefSousFamille = Reader.GetInt32(0);
            return new SousFamille(RefSousFamille,RefFamille, NomSousFamille);
        }
    }
}
