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
        private ListViewColumnSorter ColumnSorter;
        private enum Etat
        {
            ARTICLE,
            MARQUE,
            FAMILLE,
            SOUSFAMILLE
        };
        private Etat EtatSelection;

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
                Console.WriteLine(ex.StackTrace);
            }
            DataBase.InitializeList(this.treeView1);
            ColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = ColumnSorter;
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
            ColumnSorter.SortColumn = 0;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;


            string Text = e.Node.Text;
            string Name = e.Node.Name;
            if (Text == "Tous les articles")
            {
                this.listView1.Columns.Add("Description", 300, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Familles", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Sous-Familles", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Marques", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Quantite", -2, HorizontalAlignment.Left);
                SQLiteCommand Command = new SQLiteCommand("Select Description, Marques.Nom, Familles.Nom, SousFamilles.Nom, Quantite, RefArticle from Articles inner join Marques on Articles.RefMarque = Marques.RefMarque inner join SousFamilles on Articles.RefSousFamille = SousFamilles.RefSousFamille inner join Familles on SousFamilles.RefFamille = Familles.RefFamille", DataBase.Conn);
                SQLiteDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    string Description = Reader.GetString(0);
                    string Marque = Reader.GetString(1);
                    string Famille = Reader.GetString(2);
                    string SousFamille = Reader.GetString(3);
                    int Quantite = Reader.GetInt32(4);
                    string RefArticle = Reader.GetString(5);
                    ListViewItem Item = new ListViewItem(Description);
                    Item.SubItems.Add(Famille);
                    Item.SubItems.Add(SousFamille);
                    Item.SubItems.Add(Marque);
                    Item.SubItems.Add(Quantite.ToString());
                    Item.Tag = RefArticle;
                    this.listView1.Items.Add(Item);
                }
                EtatSelection = Etat.ARTICLE;

            }
            else if (Text == "Familles")
            {
                this.listView1.Columns.Add("Description", -2, HorizontalAlignment.Left);
                List<Famille> Familles = DataBase.GetFamilles();
                foreach(Famille Famille in Familles)
                {
                    ListViewItem Item = new ListViewItem(Famille.Nom);
                    Item.Tag = Famille;
                    this.listView1.Items.Add(Item);
                    
                }
                EtatSelection = Etat.FAMILLE;
            }
            else if (Text == "Marques")
            {
                this.listView1.Columns.Add("Description", -2, HorizontalAlignment.Left);
                List<Marque> Marques = DataBase.GetMarques();
                foreach (Marque Marque in Marques)
                {
                    ListViewItem Item = new ListViewItem(Marque.Nom);
                    Item.Tag = Marque;
                    this.listView1.Items.Add(Item);
                }
                EtatSelection = Etat.MARQUE;
            }
            else if (Name.Contains("Familles"))
            {
                string RefFamille = Name.Substring(8);
                List<SousFamille> SousFamilles = DataBase.GetSousFamillesOf(Int32.Parse(RefFamille));
                this.listView1.Columns.Add("Description", -2, HorizontalAlignment.Left);
                foreach (SousFamille SousFamille in SousFamilles)
                {
                    ListViewItem Item = new ListViewItem(SousFamille.Nom);
                    Item.Tag = SousFamille;
                    this.listView1.Items.Add(Item);
                }
                EtatSelection = Etat.FAMILLE;
            }
            else if (Name.Contains("SousFamille"))
            {
                string RefSousFamille = Name.Substring(11);
                this.listView1.Columns.Add("Description", 300, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Familles", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Sous-Familles", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Marques", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Quantite", -2, HorizontalAlignment.Left);
                SQLiteCommand Command = new SQLiteCommand("Select Description, Marques.Nom, Familles.Nom, SousFamilles.Nom, Quantite, RefArticle from Articles inner join Marques on Articles.RefMarque = Marques.RefMarque inner join SousFamilles on Articles.RefSousFamille = SousFamilles.RefSousFamille inner join Familles on SousFamilles.RefFamille = Familles.RefFamille where SousFamilles.RefSousFamille=" + Int32.Parse(RefSousFamille), DataBase.Conn);
                SQLiteDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    string Description = Reader.GetString(0);
                    string Marque = Reader.GetString(1);
                    string Famille = Reader.GetString(2);
                    
                    CurrentFamilleRef = DataBase.GetFamilles().Find(x => x.Nom == Famille).RefFamille;
                    string SousFamille = Reader.GetString(3);
                    int Quantite = Reader.GetInt32(4);
                    string RefArticle = Reader.GetString(5);
                    ListViewItem Item = new ListViewItem(Description);
                    Item.SubItems.Add(Famille);
                    Item.SubItems.Add(SousFamille);
                    Item.SubItems.Add(Marque);
                    Item.SubItems.Add(Quantite.ToString());
                    Item.Tag = RefArticle;
                    this.listView1.Items.Add(Item);
                }
                EtatSelection = Etat.SOUSFAMILLE;
            }
            else if (Name.Contains("Marque"))
            {
                string RefMarque = Name.Substring(6);
                this.listView1.Columns.Add("Description", 300, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Familles", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Sous-Familles", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Marques", -2, HorizontalAlignment.Left);
                this.listView1.Columns.Add("Quantite", -2, HorizontalAlignment.Left);
                SQLiteCommand Command = new SQLiteCommand("Select Description, Marques.Nom, Familles.Nom, SousFamilles.Nom, Quantite, RefArticle from Articles inner join Marques on Articles.RefMarque = Marques.RefMarque inner join SousFamilles on Articles.RefSousFamille = SousFamilles.RefSousFamille inner join Familles on SousFamilles.RefFamille = Familles.RefFamille where Marques.RefMarque=" + Int32.Parse(RefMarque), DataBase.Conn);
                SQLiteDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    string Description = Reader.GetString(0);
                    string Marque = Reader.GetString(1);
                    string Famille = Reader.GetString(2);
                    string SousFamille = Reader.GetString(3);
                    int Quantite = Reader.GetInt32(4);
                    string RefArticle = Reader.GetString(5);
                    ListViewItem Item = new ListViewItem(Description);
                    Item.SubItems.Add(Famille);
                    Item.SubItems.Add(SousFamille);
                    Item.SubItems.Add(Marque);
                    Item.SubItems.Add(Quantite.ToString());
                    Item.Tag = RefArticle;
                    this.listView1.Items.Add(Item);
                }
                EtatSelection = Etat.MARQUE;
            }
            

            ColumnSorter.Order = SortOrder.Ascending;
            listView1.Sort();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            if (listView1.SelectedItems[0].Tag.GetType() == typeof(Marque))
            {
                FormModify FormModify = new FormModify((Marque)listView1.SelectedItems[0].Tag);
                FormModify.ShowDialog();
                return;
            }
            else if (listView1.SelectedItems[0].Tag.GetType() == typeof(Famille))
            {
                FormModify FormModify = new FormModify((Famille)listView1.SelectedItems[0].Tag);
                FormModify.ShowDialog();
                return;
            }
            else if (listView1.SelectedItems[0].Tag.GetType() == typeof(SousFamille))
            {
                FormModify FormModify = new FormModify((SousFamille)listView1.SelectedItems[0].Tag);
                FormModify.ShowDialog();
                return;
            }
            else
            {
                FormModifyArticle FormModifyArticle = new FormModifyArticle(DataBase.GetArticleWithRef(listView1.SelectedItems[0].Tag.ToString()), DataBase.GetMarques(), DataBase.GetFamilles(), DataBase.GetSousFamilles()); ;

                FormModifyArticle.ShowDialog();
                return;
                //ListView.SelectedListViewItemCollection selectedItem = listView1.SelectedItems; //Recup la ligne selectionnée
                //Console.WriteLine("Double clic sur : " + selectedItem[0]);
            }
        }

        public void DeleteItem()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //il ya un item selectionné
                if (EtatSelection == Etat.ARTICLE)
                {
                    DataBase.DeleteArticle(listView1.SelectedItems[0].Tag.ToString()); //le tag est la ref de l'article
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
                else
                {
                    List<Article> Articles = DataBase.GetArticles();
                    if (EtatSelection == Etat.MARQUE)
                    {
                        Marque Marque = (Marque)listView1.SelectedItems[0].Tag;
                        if (Articles.FindAll(x => x.RefMarque == Marque.RefMarque).Count <= 0)
                        {
                            DataBase.DeleteMarque(Marque.RefMarque);
                            listView1.Items.Remove(listView1.SelectedItems[0]);
                        }
                    }
                    else if (EtatSelection == Etat.MARQUE)
                    {
                        SousFamille SousFamille = (SousFamille)listView1.SelectedItems[0].Tag;
                        if (Articles.FindAll(x => x.RefSousFamille == SousFamille.RefSousFamille).Count <= 0)
                        {
                            DataBase.DeleteSousFamille(SousFamille.RefSousFamille);
                            listView1.Items.Remove(listView1.SelectedItems[0]);
                        }
                    }
                    else if (EtatSelection == Etat.FAMILLE)
                    {
                        Famille Famille = (Famille)listView1.SelectedItems[0].Tag;

                        List<SousFamille> SousFamilles = DataBase.GetSousFamilles();
                        List<SousFamille> CaFaitBeaucoupDeSousFamilles = SousFamilles.FindAll(x => x.RefFamille == Famille.RefFamille);
                        

                        foreach(SousFamille SousFamille in CaFaitBeaucoupDeSousFamilles)
                        {
                            if(Articles.FindAll(x => x.RefSousFamille == SousFamille.RefSousFamille).Count > 0)
                            {
                                
                                return;
                            }
                        }
                        foreach (SousFamille SousFamille in CaFaitBeaucoupDeSousFamilles)
                        {
                            DataBase.DeleteSousFamille(SousFamille.RefSousFamille);
                        }
                        DataBase.DeleteFamille(Famille.RefFamille);
                        listView1.Items.Remove(listView1.SelectedItems[0]);
                        return;

                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool Handled = false;
            if(keyData == Keys.F5)
            {
                DataBase.InitializeList(this.treeView1);
                Handled = true;
            }
            if (keyData == Keys.Delete)
            {
                DeleteItem();
                Handled = true;
            }
            return Handled;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == ColumnSorter.SortColumn)
            {
                // Inversion du tri
                if (ColumnSorter.Order == SortOrder.Ascending)
                {
                    ColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    ColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Changement de colonne de tri
                ColumnSorter.SortColumn = e.Column;
                ColumnSorter.Order = SortOrder.Ascending;
            }

            // Lance le tri
            this.listView1.Sort();
        }

        public static int CurrentFamilleRef;

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (EtatSelection == Etat.MARQUE)
            {
                Marque NewMarque = new Marque("");
                FormModify FormModify = new FormModify(NewMarque);
                FormModify.ShowDialog();
            }
            else if (EtatSelection == Etat.FAMILLE)
            {
                Famille NewFamille = new Famille("");
                FormModify FormModify = new FormModify(NewFamille);
                FormModify.ShowDialog();
            }
            else if (EtatSelection == Etat.SOUSFAMILLE)
            {
                SousFamille NewSousFamille = new SousFamille(CurrentFamilleRef, "");
                FormModify FormModify = new FormModify(NewSousFamille);
                FormModify.ShowDialog();
            }
            
            else if (listView1.SelectedItems[0].Tag.GetType() == typeof(Marque))
            {
                Marque NewMarque = new Marque("");
                FormModify FormModify = new FormModify(NewMarque);
                FormModify.ShowDialog();
            }
            else if (listView1.SelectedItems[0].Tag.GetType() == typeof(Famille))
            {
                Famille NewFamille = new Famille("");
                FormModify FormModify = new FormModify(NewFamille);
                FormModify.ShowDialog();
            }
            else if (listView1.SelectedItems[0].Tag.GetType() == typeof(SousFamille))
            {
                SousFamille NewSousFamille = new SousFamille(CurrentFamilleRef, "");
                FormModify FormModify = new FormModify(NewSousFamille);
                FormModify.ShowDialog();
            }
            else
            {
                Article NewArticle = new Article("");
                FormModifyArticle FormModifyArticle = new FormModifyArticle(NewArticle, DataBase.GetMarques(), DataBase.GetFamilles(), DataBase.GetSousFamilles(), true);
                FormModifyArticle.ShowDialog();
            }
            return;
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].Tag.GetType() == typeof(Marque))
            {
                FormModify FormModify = new FormModify((Marque)listView1.SelectedItems[0].Tag);
                FormModify.ShowDialog();
               
            }
            else if (listView1.SelectedItems[0].Tag.GetType() == typeof(Famille))
            {
                FormModify FormModify = new FormModify((Famille)listView1.SelectedItems[0].Tag);
                FormModify.ShowDialog();
               
            }
            else if (listView1.SelectedItems[0].Tag.GetType() == typeof(SousFamille))
            {
                FormModify FormModify = new FormModify((SousFamille)listView1.SelectedItems[0].Tag);
                FormModify.ShowDialog();
              
            }
            else
            {
                FormModifyArticle FormModifyArticle = new FormModifyArticle(DataBase.GetArticleWithRef(listView1.SelectedItems[0].Tag.ToString()), DataBase.GetMarques(), DataBase.GetFamilles(), DataBase.GetSousFamilles()); ;

                FormModifyArticle.ShowDialog();
            
            }
            return;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(listView1.SelectedItems.Count <= 0)
            {
                ContextMenuStrip.Items[1].Enabled = false;
                ContextMenuStrip.Items[2].Enabled = false;
            }
            else
            {
                ContextMenuStrip.Items[1].Enabled = true;
                ContextMenuStrip.Items[2].Enabled = true;
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }
    }
}
