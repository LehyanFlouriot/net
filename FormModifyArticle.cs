using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hector
{
    public partial class FormModifyArticle : Form
    {
        
        private Article CurrentArticle = null;
        //Voir si on met en static dans le formMain

        private List<Marque> Marques;
        //private List<Famille> Familles; a voir
        private List<SousFamille> SousFamilles;
        

        public FormModifyArticle()
        {
            InitializeComponent();
        }

        public FormModifyArticle(Article Article, List<Marque> Marques, List<SousFamille> SousFamilles)
        {
            InitializeComponent();

            TextBoxDescription.Text = Article.Description;
            ComboBoxMarque.Items.AddRange(Marques.ToArray());
            
            ComboBoxSousFamille.Items.AddRange(SousFamilles.ToArray());

            CurrentArticle = Article;
            this.Marques = Marques;
            
            this.SousFamilles = SousFamilles;
        }
        

        private void ComboBoxMarque_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            //Changer les valeurs de l'article
            CurrentArticle.Description = TextBoxDescription.Text;
            CurrentArticle.RefMarque = Marques[ComboBoxMarque.SelectedIndex].RefMarque;
            CurrentArticle.RefSousFamille = Marques[ComboBoxSousFamille.SelectedIndex].RefMarque;
            //GERER LE CAS OU IL n'Y A PAS DE SOUS FAMILLE
        }

        private void LabelDescription_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void LabelMarque_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxSousFamille_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
