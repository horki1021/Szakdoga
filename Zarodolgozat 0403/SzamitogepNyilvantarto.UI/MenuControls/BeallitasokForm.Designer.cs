namespace SzamitogepNyilvantarto.UI.MenuControls
{
    partial class BeallitasokForm
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageDokumentum = new System.Windows.Forms.TabPage();
			this.buttonDokumentumOK = new System.Windows.Forms.Button();
			this.radioButtonDocx = new System.Windows.Forms.RadioButton();
			this.radioButtonPdf = new System.Windows.Forms.RadioButton();
			this.label = new System.Windows.Forms.Label();
			this.tabPageJelszo = new System.Windows.Forms.TabPage();
			this.buttonJelszoOK = new System.Windows.Forms.Button();
			this.textBoxMégegyszer = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxUj = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxRegi = new System.Windows.Forms.TextBox();
			this.labelRegiJelszó = new System.Windows.Forms.Label();
			this.tabControl.SuspendLayout();
			this.tabPageDokumentum.SuspendLayout();
			this.tabPageJelszo.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageDokumentum);
			this.tabControl.Controls.Add(this.tabPageJelszo);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(254, 209);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageDokumentum
			// 
			this.tabPageDokumentum.Controls.Add(this.buttonDokumentumOK);
			this.tabPageDokumentum.Controls.Add(this.radioButtonDocx);
			this.tabPageDokumentum.Controls.Add(this.radioButtonPdf);
			this.tabPageDokumentum.Controls.Add(this.label);
			this.tabPageDokumentum.Location = new System.Drawing.Point(4, 24);
			this.tabPageDokumentum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageDokumentum.Name = "tabPageDokumentum";
			this.tabPageDokumentum.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageDokumentum.Size = new System.Drawing.Size(246, 181);
			this.tabPageDokumentum.TabIndex = 2;
			this.tabPageDokumentum.Text = "Dokumentum";
			this.tabPageDokumentum.UseVisualStyleBackColor = true;
			// 
			// buttonDokumentumOK
			// 
			this.buttonDokumentumOK.Location = new System.Drawing.Point(50, 143);
			this.buttonDokumentumOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonDokumentumOK.Name = "buttonDokumentumOK";
			this.buttonDokumentumOK.Size = new System.Drawing.Size(149, 22);
			this.buttonDokumentumOK.TabIndex = 3;
			this.buttonDokumentumOK.Text = "OK";
			this.buttonDokumentumOK.UseVisualStyleBackColor = true;
			this.buttonDokumentumOK.Click += new System.EventHandler(this.OnDokumentumOKClick);
			// 
			// radioButtonDocx
			// 
			this.radioButtonDocx.AutoSize = true;
			this.radioButtonDocx.Location = new System.Drawing.Point(50, 91);
			this.radioButtonDocx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.radioButtonDocx.Name = "radioButtonDocx";
			this.radioButtonDocx.Size = new System.Drawing.Size(57, 19);
			this.radioButtonDocx.TabIndex = 2;
			this.radioButtonDocx.TabStop = true;
			this.radioButtonDocx.Text = "DOCX";
			this.radioButtonDocx.UseVisualStyleBackColor = true;
			// 
			// radioButtonPdf
			// 
			this.radioButtonPdf.AutoSize = true;
			this.radioButtonPdf.Location = new System.Drawing.Point(50, 68);
			this.radioButtonPdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.radioButtonPdf.Name = "radioButtonPdf";
			this.radioButtonPdf.Size = new System.Drawing.Size(46, 19);
			this.radioButtonPdf.TabIndex = 1;
			this.radioButtonPdf.TabStop = true;
			this.radioButtonPdf.Text = "PDF";
			this.radioButtonPdf.UseVisualStyleBackColor = true;
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Location = new System.Drawing.Point(26, 42);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(190, 15);
			this.label.TabIndex = 0;
			this.label.Text = "Generált dokumentum formátuma";
			// 
			// tabPageJelszo
			// 
			this.tabPageJelszo.Controls.Add(this.buttonJelszoOK);
			this.tabPageJelszo.Controls.Add(this.textBoxMégegyszer);
			this.tabPageJelszo.Controls.Add(this.label2);
			this.tabPageJelszo.Controls.Add(this.textBoxUj);
			this.tabPageJelszo.Controls.Add(this.label1);
			this.tabPageJelszo.Controls.Add(this.textBoxRegi);
			this.tabPageJelszo.Controls.Add(this.labelRegiJelszó);
			this.tabPageJelszo.Location = new System.Drawing.Point(4, 24);
			this.tabPageJelszo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageJelszo.Name = "tabPageJelszo";
			this.tabPageJelszo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageJelszo.Size = new System.Drawing.Size(246, 181);
			this.tabPageJelszo.TabIndex = 1;
			this.tabPageJelszo.Text = "Jelszó";
			this.tabPageJelszo.UseVisualStyleBackColor = true;
			// 
			// buttonJelszoOK
			// 
			this.buttonJelszoOK.Location = new System.Drawing.Point(36, 157);
			this.buttonJelszoOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonJelszoOK.Name = "buttonJelszoOK";
			this.buttonJelszoOK.Size = new System.Drawing.Size(157, 22);
			this.buttonJelszoOK.TabIndex = 6;
			this.buttonJelszoOK.Text = "OK";
			this.buttonJelszoOK.UseVisualStyleBackColor = true;
			this.buttonJelszoOK.Click += new System.EventHandler(this.OnJelszoOKClick);
			// 
			// textBoxMégegyszer
			// 
			this.textBoxMégegyszer.Location = new System.Drawing.Point(36, 119);
			this.textBoxMégegyszer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxMégegyszer.Name = "textBoxMégegyszer";
			this.textBoxMégegyszer.PasswordChar = '*';
			this.textBoxMégegyszer.Size = new System.Drawing.Size(191, 23);
			this.textBoxMégegyszer.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 15);
			this.label2.TabIndex = 4;
			this.label2.Text = "Jelszó még egyszer";
			// 
			// textBoxUj
			// 
			this.textBoxUj.Location = new System.Drawing.Point(36, 80);
			this.textBoxUj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxUj.Name = "textBoxUj";
			this.textBoxUj.PasswordChar = '*';
			this.textBoxUj.Size = new System.Drawing.Size(191, 23);
			this.textBoxUj.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Új jelszó";
			// 
			// textBoxRegi
			// 
			this.textBoxRegi.Location = new System.Drawing.Point(36, 27);
			this.textBoxRegi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxRegi.Name = "textBoxRegi";
			this.textBoxRegi.PasswordChar = '*';
			this.textBoxRegi.Size = new System.Drawing.Size(191, 23);
			this.textBoxRegi.TabIndex = 1;
			// 
			// labelRegiJelszó
			// 
			this.labelRegiJelszó.AutoSize = true;
			this.labelRegiJelszó.Location = new System.Drawing.Point(15, 10);
			this.labelRegiJelszó.Name = "labelRegiJelszó";
			this.labelRegiJelszó.Size = new System.Drawing.Size(63, 15);
			this.labelRegiJelszó.TabIndex = 0;
			this.labelRegiJelszó.Text = "Régi Jelszó";
			// 
			// BeallitasokForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(254, 209);
			this.Controls.Add(this.tabControl);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(270, 248);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(270, 248);
			this.Name = "BeallitasokForm";
			this.Text = "Beallítások";
			this.tabControl.ResumeLayout(false);
			this.tabPageDokumentum.ResumeLayout(false);
			this.tabPageDokumentum.PerformLayout();
			this.tabPageJelszo.ResumeLayout(false);
			this.tabPageJelszo.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPageDokumentum;
        private RadioButton radioButtonDocx;
        private RadioButton radioButtonPdf;
        private Label label;
        private TabPage tabPageJelszo;
        private TextBox textBoxMégegyszer;
        private Label label2;
        private TextBox textBoxUj;
        private Label label1;
        private TextBox textBoxRegi;
        private Label labelRegiJelszó;
        private Button buttonDokumentumOK;
        private Button buttonJelszoOK;
    }
}