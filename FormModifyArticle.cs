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

        List<Marque> LocalMarques;
        List<Famille> LocalFamilles;
        List<SousFamille> LocalSousFamilles;




        public FormModifyArticle()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructeur pour un article en particulier
        /// </summary>
        /// <param name="Article"></param>
        /// <param name="Marques"></param>
        /// <param name="SousFamilles"></param>
        public FormModifyArticle(Article Article, List<Marque> Marques, List<Famille> Familles, List<SousFamille> SousFamilles)
        {
            InitializeComponent();

            TextBoxDescription.Text = Article.Description;

            //Marque
            foreach(Marque Marque in Marques)
            {
                ComboBoxMarque.Items.Add(Marque.Nom);
            }
            ComboBoxMarque.Text = Marques.Find(x => x.RefMarque == Article.RefMarque).Nom;

            //Famille
            foreach(Famille Famille in Familles)
            {
                ComboBoxFamille.Items.Add(Famille.Nom);
            }
            int RefFamille = SousFamilles.Find(x => x.RefSousFamille == Article.RefSousFamille).RefFamille;
            Famille CurrentFamille = Familles.Find(x => x.RefFamille == RefFamille);
            ComboBoxFamille.Text = CurrentFamille.Nom;

            //SousFamille
            List<SousFamille> possibleSousFamilles = SousFamilles.FindAll(x => x.RefFamille == CurrentFamille.RefFamille);
            foreach (SousFamille SousFamille in possibleSousFamilles)
            {
                ComboBoxSousFamille.Items.Add(SousFamille.Nom);
            }
            ComboBoxSousFamille.Text = SousFamilles.Find(x => x.RefSousFamille == Article.RefSousFamille).Nom;


            CurrentArticle = Article;
            LocalMarques = Marques;
            LocalFamilles = Familles;
            LocalSousFamilles = SousFamilles;

        }
        

        private void ComboBoxMarque_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// On clic sur le bouton annuler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Check if each box is ok
        /// </summary>
        /// <returns></returns>
        private bool CheckBoxes()
        {
            if (TextBoxDescription.Text.Length == 0)
                return false;
            return true;
        }

        /// <summary>
        /// On clic sur le bouton appliquer, on applique les changement à la base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (CheckBoxes() == true)
            {
                //Changer les valeurs de l'article
                CurrentArticle.Description = TextBoxDescription.Text;

            }
            //requete sql pour appliquer le changement
            ShowResult();
        }

        private void ShowResult()
        {

            DialogResult Result = MessageBox.Show("Modifications appliquées avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //L'utilisateur a dit ok
            if (Result == DialogResult.OK)
            {
                this.Close();
            }
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
        /// <summary>
        /// On a choisi une nouvelle famille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxFamille_SelectedIndexChanged(object sender, EventArgs e)
        {
            //On actualise les valeurs possible de la combobox sous famille
            string CurrentNomFamille = ComboBoxFamille.Text;
            int CurrentRefFamille = LocalFamilles.Find(x => x.Nom == CurrentNomFamille).RefFamille;


            List<SousFamille> possibleSousFamilles = LocalSousFamilles.FindAll(x => x.RefFamille == CurrentRefFamille);
            foreach (SousFamille SousFamille in possibleSousFamilles)
            {
                ComboBoxSousFamille.Items.Add(SousFamille.Nom);
            }
            ComboBoxSousFamille.SelectedIndex = 0;
        }
    }
}
