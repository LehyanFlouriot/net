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
    public partial class FormModify : Form
    {

        Marque CurrentMarque = null;
        Famille CurrentFamille = null;
        SousFamille CurrentSousFamille = null;

        public FormModify()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructeur pour Marque
        /// </summary>
        /// <param name="Marque"></param>
        public FormModify(Marque Marque)
        {
            InitializeComponent();
            TextBoxDescription.Text = Marque.Nom;
            CurrentMarque = Marque;
        }
        /// <summary>
        /// Constructeur pour Famille
        /// </summary>
        /// <param name="Famille"></param>
        public FormModify(Famille Famille)
        {
            InitializeComponent();
            TextBoxDescription.Text = Famille.Nom;
            CurrentFamille = Famille;
        }
        /// <summary>
        /// Constructeur pour SousFamille
        /// </summary>
        /// <param name="SousFamille"></param>
        public FormModify(SousFamille SousFamille)
        {
            InitializeComponent();
            TextBoxDescription.Text = SousFamille.Nom;
            CurrentSousFamille = SousFamille;
        }
        /// <summary>
        /// Clic sur lae bouton annuler
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
                if(CurrentMarque != null)
                {
                    
                    CurrentMarque.Nom = TextBoxDescription.Text;
                    //Reload dans la base ou jsp quoi
                    //Requete sql pour le changer
                    if (Marque.Existe(CurrentMarque.Nom) != -1) //CA EXISTE
                    {
                        DataBase.ModifyMarque(CurrentMarque.RefMarque, CurrentMarque.Nom);
                    }
                    else
                    {
                        Marque.InsererMarque(CurrentMarque.Nom);
                    }
                    
                }
                if (CurrentFamille != null)
                {
                    CurrentFamille.Nom = TextBoxDescription.Text;
                    //Reload dans la base ou jsp quoi
                    //Requete sql pour le changer
                    if (Famille.Existe(CurrentFamille.Nom) != -1)
                    {
                        DataBase.ModifyFamille(CurrentFamille.RefFamille, CurrentFamille.Nom);
                    }
                    else
                    {
                        Famille.InsererFamille(CurrentFamille.Nom);
                    }
                }
                if (CurrentSousFamille != null)
                {
                    CurrentSousFamille.Nom = TextBoxDescription.Text;
                    //Reload dans la base ou jsp quoi
                    //Requete sql pour le changer
                    if (SousFamille.Existe(CurrentSousFamille.Nom) != -1)
                    {
                        DataBase.ModifySousFamille(CurrentSousFamille.RefSousFamille, CurrentSousFamille.RefFamille, CurrentSousFamille.Nom);
                    }
                    else
                    {
                        SousFamille.InsererSousFamille(CurrentSousFamille.RefFamille, CurrentSousFamille.Nom);
                    }
                }
            }

            ShowResult();
            return;
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

        private void FormModify_Load(object sender, EventArgs e)
        {

        }
    }
}
