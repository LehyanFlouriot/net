
namespace Hector
{
    partial class FormImport
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
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonOverwrite = new System.Windows.Forms.Button();
            this.TextBoxDescription = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBrowse.Location = new System.Drawing.Point(468, 49);
            this.ButtonBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(95, 27);
            this.ButtonBrowse.TabIndex = 0;
            this.ButtonBrowse.Text = "Parcourir";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // FilePath
            // 
            this.FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePath.Location = new System.Drawing.Point(152, 53);
            this.FilePath.Margin = new System.Windows.Forms.Padding(2);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(298, 23);
            this.FilePath.TabIndex = 1;
            this.FilePath.TextChanged += new System.EventHandler(this.FilePath_TextChanged);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAdd.Location = new System.Drawing.Point(171, 116);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(73, 33);
            this.ButtonAdd.TabIndex = 2;
            this.ButtonAdd.Text = "Ajouter";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonOverwrite
            // 
            this.ButtonOverwrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOverwrite.Location = new System.Drawing.Point(318, 116);
            this.ButtonOverwrite.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonOverwrite.Name = "ButtonOverwrite";
            this.ButtonOverwrite.Size = new System.Drawing.Size(73, 33);
            this.ButtonOverwrite.TabIndex = 3;
            this.ButtonOverwrite.Text = "Ecraser";
            this.ButtonOverwrite.UseVisualStyleBackColor = true;
            this.ButtonOverwrite.Click += new System.EventHandler(this.ButtonOverwrite_Click);
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.AutoSize = true;
            this.TextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDescription.Location = new System.Drawing.Point(22, 55);
            this.TextBoxDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(125, 17);
            this.TextBoxDescription.TabIndex = 4;
            this.TextBoxDescription.Text = "Chemin du fichier :";
            this.TextBoxDescription.Click += new System.EventHandler(this.TextBoxDescription_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(31, 200);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(516, 35);
            this.ProgressBar.Step = 100;
            this.ProgressBar.TabIndex = 5;
            this.ProgressBar.Click += new System.EventHandler(this.ProgressBar_Click);
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.ButtonOverwrite);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.ButtonBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormImport";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormImport";
            this.Load += new System.EventHandler(this.FormImport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonOverwrite;
        private System.Windows.Forms.Label TextBoxDescription;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}