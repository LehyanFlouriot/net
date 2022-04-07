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
    }
}
