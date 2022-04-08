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

            CurrentArticle = Article;
            LocalMarques = Marques;
            LocalFamilles = Familles;
            LocalSousFamilles = SousFamilles;


            TextBoxDescription.Text = Article.Description;
            TextBoxPrix.Text = Article.PrixHT.ToString();

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

            
            

        }

        public FormModifyArticle(Article Article, List<Marque> Marques, List<Famille> Familles, List<SousFamille> SousFamilles, bool add)
        {
            InitializeComponent();

            CurrentArticle = Article;
            
            LocalMarques = Marques;
            LocalFamilles = Familles;
            LocalSousFamilles = SousFamilles;


            TextBoxDescription.Text = CurrentArticle.Description;
            TextBoxPrix.Text = CurrentArticle.PrixHT.ToString();

            //Marque
            foreach (Marque Marque in Marques)
            {
                ComboBoxMarque.Items.Add(Marque.Nom);
            }
            string MarqueNom = ComboBoxMarque.Items[0].ToString();
            CurrentArticle.RefMarque = Marques.Find(x => x.Nom == MarqueNom).RefMarque;
            ComboBoxMarque.Text = Marques.Find(x => x.RefMarque == CurrentArticle.RefMarque).Nom;

            //Famille
            foreach (Famille Famille in Familles)
            {
                ComboBoxFamille.Items.Add(Famille.Nom);
            }
            string TempFamilleNom = ComboBoxFamille.Items[0].ToString();
            int TempRefFamille = Familles.Find(x => x.Nom == TempFamilleNom).RefFamille;
            CurrentArticle.RefSousFamille = SousFamilles.Find(x => x.RefFamille == TempRefFamille).RefFamille;

            int RefFamille = SousFamilles.Find(x => x.RefSousFamille == CurrentArticle.RefSousFamille).RefFamille;
            Famille CurrentFamille = Familles.Find(x => x.RefFamille == RefFamille);
            ComboBoxFamille.Text = CurrentFamille.Nom;

            //SousFamille
            List<SousFamille> possibleSousFamilles = SousFamilles.FindAll(x => x.RefFamille == CurrentFamille.RefFamille);
            foreach (SousFamille SousFamille in possibleSousFamilles)
            {
                ComboBoxSousFamille.Items.Add(SousFamille.Nom);
            }
            ComboBoxSousFamille.Text = SousFamilles.Find(x => x.RefSousFamille == CurrentArticle.RefSousFamille).Nom;





        }


        private void ComboBoxMarque_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Marque changed");
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
            if (TextBoxDescription.Text.Length <= 0 && TextBoxPrix.Text.Length <= 0)
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



                CurrentArticle.RefMarque = LocalMarques.Find(x => x.Nom == ComboBoxMarque.Text).RefMarque;
                
                CurrentArticle.RefSousFamille = LocalSousFamilles.Find(x => x.Nom == ComboBoxSousFamille.Text).RefSousFamille;
                //Console.WriteLine(ComboBoxMarque.Text);
                try{
                    CurrentArticle.PrixHT = float.Parse(TextBoxPrix.Text);
                }
                catch(Exception ex)
                {
                    DialogResult MsgBox = MessageBox.Show("Mettez un prix entier ou à VIRGULE");
                    return;
                }
            }
            //requete sql pour appliquer le changement
            if (Article.Existe(CurrentArticle.RefArticle) != -1)
            {
                DataBase.ModifyArticle(CurrentArticle.RefArticle, CurrentArticle.Description, CurrentArticle.RefSousFamille, CurrentArticle.RefMarque, CurrentArticle.PrixHT);
            }
            else
            {
                Article.InsererArticle(CurrentArticle.RefArticle, CurrentArticle.Description, CurrentArticle.RefSousFamille, CurrentArticle.RefMarque, CurrentArticle.PrixHT, 1);
            }
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
            //Console.WriteLine(ComboBoxFamille.Text);


            int CurrentRefFamille = LocalFamilles.Find(x => x.Nom == CurrentNomFamille).RefFamille;


            List<SousFamille> possibleSousFamilles = LocalSousFamilles.FindAll(x => x.RefFamille == CurrentRefFamille);
            ComboBoxSousFamille.Items.Clear();
            foreach (SousFamille SousFamille in possibleSousFamilles)
            {

                ComboBoxSousFamille.Items.Add(SousFamille.Nom);
            }
            ComboBoxSousFamille.SelectedIndex = 0;
        }


    }
}
