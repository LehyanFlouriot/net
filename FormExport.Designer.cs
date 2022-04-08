
namespace Hector
{
    partial class FormExport
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
            this.TextBoxDescription = new System.Windows.Forms.Label();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.ButtonExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.AutoSize = true;
            this.TextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDescription.Location = new System.Drawing.Point(11, 44);
            this.TextBoxDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(133, 17);
            this.TextBoxDescription.TabIndex = 8;
            this.TextBoxDescription.Text = "Chemin du dossier :";
            this.TextBoxDescription.Click += new System.EventHandler(this.TextBoxDescription_Click);
            // 
            // FolderPath
            // 
            this.FolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderPath.Location = new System.Drawing.Point(152, 41);
            this.FolderPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(298, 23);
            this.FolderPath.TabIndex = 2;
            this.FolderPath.TabStop = false;
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBrowse.Location = new System.Drawing.Point(468, 37);
            this.ButtonBrowse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(95, 27);
            this.ButtonBrowse.TabIndex = 0;
            this.ButtonBrowse.Text = "Parcourir";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // ButtonExport
            // 
            this.ButtonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExport.Location = new System.Drawing.Point(243, 97);
            this.ButtonExport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.Size = new System.Drawing.Size(95, 27);
            this.ButtonExport.TabIndex = 1;
            this.ButtonExport.Text = "Exporter";
            this.ButtonExport.UseVisualStyleBackColor = true;
            this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 161);
            this.Controls.Add(this.ButtonExport);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.ButtonBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormExport";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormExport";
            this.Load += new System.EventHandler(this.FormExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TextBoxDescription;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.Button ButtonExport;
    }
}