
namespace Hector
{
    partial class FormModifyArticle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonApply = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.LabelDescription = new System.Windows.Forms.Label();
            this.LabelMarque = new System.Windows.Forms.Label();
            this.LabelFamille = new System.Windows.Forms.Label();
            this.ComboBoxMarque = new System.Windows.Forms.ComboBox();
            this.ComboBoxFamille = new System.Windows.Forms.ComboBox();
            this.ComboBoxSousFamille = new System.Windows.Forms.ComboBox();
            this.LabelSousFamille = new System.Windows.Forms.Label();
            this.LabelPrix = new System.Windows.Forms.Label();
            this.TextBoxPrix = new System.Windows.Forms.TextBox();
            this.LabelRef = new System.Windows.Forms.Label();
            this.TextBoxRef = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonApply
            // 
            this.ButtonApply.Location = new System.Drawing.Point(35, 312);
            this.ButtonApply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 23);
            this.ButtonApply.TabIndex = 4;
            this.ButtonApply.Text = "Appliquer";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(152, 312);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Annuler";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Location = new System.Drawing.Point(102, 87);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(148, 20);
            this.TextBoxDescription.TabIndex = 0;
            this.TextBoxDescription.TextChanged += new System.EventHandler(this.TextBoxDescription_TextChanged);
            // 
            // LabelDescription
            // 
            this.LabelDescription.AutoSize = true;
            this.LabelDescription.Location = new System.Drawing.Point(28, 90);
            this.LabelDescription.Name = "LabelDescription";
            this.LabelDescription.Size = new System.Drawing.Size(60, 13);
            this.LabelDescription.TabIndex = 7;
            this.LabelDescription.Text = "Description";
            this.LabelDescription.Click += new System.EventHandler(this.LabelDescription_Click);
            // 
            // LabelMarque
            // 
            this.LabelMarque.AutoSize = true;
            this.LabelMarque.Location = new System.Drawing.Point(45, 128);
            this.LabelMarque.Name = "LabelMarque";
            this.LabelMarque.Size = new System.Drawing.Size(43, 13);
            this.LabelMarque.TabIndex = 0;
            this.LabelMarque.Text = "Marque";
            this.LabelMarque.Click += new System.EventHandler(this.LabelMarque_Click);
            // 
            // LabelFamille
            // 
            this.LabelFamille.AutoSize = true;
            this.LabelFamille.Location = new System.Drawing.Point(49, 165);
            this.LabelFamille.Name = "LabelFamille";
            this.LabelFamille.Size = new System.Drawing.Size(39, 13);
            this.LabelFamille.TabIndex = 9;
            this.LabelFamille.Text = "Famille";
            // 
            // ComboBoxMarque
            // 
            this.ComboBoxMarque.FormattingEnabled = true;
            this.ComboBoxMarque.Location = new System.Drawing.Point(102, 125);
            this.ComboBoxMarque.Name = "ComboBoxMarque";
            this.ComboBoxMarque.Size = new System.Drawing.Size(148, 21);
            this.ComboBoxMarque.TabIndex = 1;
            this.ComboBoxMarque.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMarque_SelectedIndexChanged);
            // 
            // ComboBoxFamille
            // 
            this.ComboBoxFamille.FormattingEnabled = true;
            this.ComboBoxFamille.Location = new System.Drawing.Point(102, 162);
            this.ComboBoxFamille.Name = "ComboBoxFamille";
            this.ComboBoxFamille.Size = new System.Drawing.Size(148, 21);
            this.ComboBoxFamille.TabIndex = 2;
            this.ComboBoxFamille.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFamille_SelectedIndexChanged);
            // 
            // ComboBoxSousFamille
            // 
            this.ComboBoxSousFamille.FormattingEnabled = true;
            this.ComboBoxSousFamille.Location = new System.Drawing.Point(102, 202);
            this.ComboBoxSousFamille.Name = "ComboBoxSousFamille";
            this.ComboBoxSousFamille.Size = new System.Drawing.Size(148, 21);
            this.ComboBoxSousFamille.TabIndex = 3;
            // 
            // LabelSousFamille
            // 
            this.LabelSousFamille.AutoSize = true;
            this.LabelSousFamille.Location = new System.Drawing.Point(22, 205);
            this.LabelSousFamille.Name = "LabelSousFamille";
            this.LabelSousFamille.Size = new System.Drawing.Size(66, 13);
            this.LabelSousFamille.TabIndex = 8;
            this.LabelSousFamille.Text = "Sous Famille";
            // 
            // LabelPrix
            // 
            this.LabelPrix.AutoSize = true;
            this.LabelPrix.Location = new System.Drawing.Point(49, 243);
            this.LabelPrix.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPrix.Name = "LabelPrix";
            this.LabelPrix.Size = new System.Drawing.Size(39, 13);
            this.LabelPrix.TabIndex = 15;
            this.LabelPrix.Text = "PrixHT";
            // 
            // TextBoxPrix
            // 
            this.TextBoxPrix.Location = new System.Drawing.Point(102, 240);
            this.TextBoxPrix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBoxPrix.Name = "TextBoxPrix";
            this.TextBoxPrix.Size = new System.Drawing.Size(148, 20);
            this.TextBoxPrix.TabIndex = 16;
            // 
            // LabelRef
            // 
            this.LabelRef.AutoSize = true;
            this.LabelRef.Enabled = false;
            this.LabelRef.Location = new System.Drawing.Point(28, 48);
            this.LabelRef.Name = "LabelRef";
            this.LabelRef.Size = new System.Drawing.Size(57, 13);
            this.LabelRef.TabIndex = 18;
            this.LabelRef.Text = "Reference";
            this.LabelRef.Click += new System.EventHandler(this.label1_Click);
            // 
            // TextBoxRef
            // 
            this.TextBoxRef.Enabled = false;
            this.TextBoxRef.Location = new System.Drawing.Point(102, 45);
            this.TextBoxRef.Name = "TextBoxRef";
            this.TextBoxRef.Size = new System.Drawing.Size(148, 20);
            this.TextBoxRef.TabIndex = 17;
            this.TextBoxRef.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FormModifyArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.LabelRef);
            this.Controls.Add(this.TextBoxRef);
            this.Controls.Add(this.TextBoxPrix);
            this.Controls.Add(this.LabelPrix);
            this.Controls.Add(this.ComboBoxSousFamille);
            this.Controls.Add(this.LabelSousFamille);
            this.Controls.Add(this.ComboBoxFamille);
            this.Controls.Add(this.ComboBoxMarque);
            this.Controls.Add(this.LabelFamille);
            this.Controls.Add(this.LabelMarque);
            this.Controls.Add(this.LabelDescription);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonApply);
            this.Name = "FormModifyArticle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormModifyArticle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonApply;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.Label LabelDescription;
        private System.Windows.Forms.Label LabelMarque;
        private System.Windows.Forms.Label LabelFamille;
        private System.Windows.Forms.ComboBox ComboBoxMarque;
        private System.Windows.Forms.ComboBox ComboBoxFamille;
        private System.Windows.Forms.ComboBox ComboBoxSousFamille;
        private System.Windows.Forms.Label LabelSousFamille;
        private System.Windows.Forms.Label LabelPrix;
        private System.Windows.Forms.TextBox TextBoxPrix;
        private System.Windows.Forms.Label LabelRef;
        private System.Windows.Forms.TextBox TextBoxRef;
    }
}