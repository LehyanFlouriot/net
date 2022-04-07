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

namespace Hector
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            string path = "Hector.SQLite";
            try
            {
                
                DataBase.CreateConnection(path);
            }
            catch(Exception ex)
            {

            }
            DataBase.InitializeList(this.treeView1);
            
        }

      
        /// <summary>
        /// Creer une nouvelle fenetre modale d'importation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport FormImport = new FormImport();
            FormImport.ShowDialog();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExport FormExport = new FormExport();
            FormExport.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBase.InitializeList(this.treeView1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.listView1.Clear();

            listView1.GridLines = true;
            listView1.FullRowSelect = true;


            string Text = e.Node.Text;
            string Name = e.Node.Name;
            if (Text== "Tous les articles")
            {
                this.listView1.Columns.Add("Description", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Familles", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Sous-Familles", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Marques", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Quantite", -2, HorizontalAlignment.Left);
                SQLiteCommand Command = new SQLiteCommand("Select Description, Marques.Nom, Familles.Nom, SousFamilles.Nom, Quantite from Articles inner join Marques on Articles.RefMarque = Marques.RefMarque inner join SousFamilles on Articles.RefSousFamille = SousFamilles.RefSousFamille inner join Familles on SousFamilles.RefFamille = Familles.RefFamille", DataBase.Conn);
                SQLiteDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    string Description = Reader.GetString(0);
                    string Marque = Reader.GetString(1);
                    string Famille = Reader.GetString(2);
                    string SousFamille = Reader.GetString(3);
                    int Quantite = Reader.GetInt32(4);
                    ListViewItem Item = new ListViewItem(Description);
                    Item.SubItems.Add(Famille);
                    Item.SubItems.Add(SousFamille);
                    Item.SubItems.Add(Marque);
                    Item.SubItems.Add(Quantite.ToString());
                    this.listView1.Items.Add(Item);
                }

            }
            else if (Text == "Familles")
            {

            }else if(Text == "Marques")
            {

            }else if (Name.Contains("Famille"))
            {

            }else if (Name.Contains("SousFamille"))
            {

            }else if (Name.Contains("Marque"))
            {

            }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
