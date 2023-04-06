namespace SzamitogepNyilvantarto.UI.MenuControls
{
    partial class BejelentkezesForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelFehasznaloNev = new System.Windows.Forms.Label();
            this.textBoxFelhsznaloNev = new System.Windows.Forms.TextBox();
            this.textBoxJelszo = new System.Windows.Forms.TextBox();
            this.labelJelszo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(82, 121);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(118, 29);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Bejelentkezés";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnOKClick);
            // 
            // labelFehasznaloNev
            // 
            this.labelFehasznaloNev.AutoSize = true;
            this.labelFehasznaloNev.Location = new System.Drawing.Point(12, 9);
            this.labelFehasznaloNev.Name = "labelFehasznaloNev";
            this.labelFehasznaloNev.Size = new System.Drawing.Size(109, 20);
            this.labelFehasznaloNev.TabIndex = 1;
            this.labelFehasznaloNev.Text = "Felhasználónév";
            // 
            // textBoxFelhsznaloNev
            // 
            this.textBoxFelhsznaloNev.Location = new System.Drawing.Point(163, 6);
            this.textBoxFelhsznaloNev.Name = "textBoxFelhsznaloNev";
            this.textBoxFelhsznaloNev.Size = new System.Drawing.Size(125, 27);
            this.textBoxFelhsznaloNev.TabIndex = 2;
            // 
            // textBoxJelszo
            // 
            this.textBoxJelszo.Location = new System.Drawing.Point(163, 65);
            this.textBoxJelszo.Name = "textBoxJelszo";
            this.textBoxJelszo.PasswordChar = '*';
            this.textBoxJelszo.Size = new System.Drawing.Size(125, 27);
            this.textBoxJelszo.TabIndex = 4;
            // 
            // labelJelszo
            // 
            this.labelJelszo.AutoSize = true;
            this.labelJelszo.Location = new System.Drawing.Point(12, 68);
            this.labelJelszo.Name = "labelJelszo";
            this.labelJelszo.Size = new System.Drawing.Size(48, 20);
            this.labelJelszo.TabIndex = 3;
            this.labelJelszo.Text = "Jelszó";
            // 
            // BejelentkezesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 177);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxJelszo);
            this.Controls.Add(this.labelJelszo);
            this.Controls.Add(this.textBoxFelhsznaloNev);
            this.Controls.Add(this.labelFehasznaloNev);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(373, 224);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(373, 224);
            this.Name = "BejelentkezesForm";
            this.Text = "Bejelentkezes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonOK;
        private Label labelFehasznaloNev;
        private TextBox textBoxFelhsznaloNev;
        private TextBox textBoxJelszo;
        private Label labelJelszo;
    }
}