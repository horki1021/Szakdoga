namespace SzamitogepNyilvantarto.UI.MenuControls.Reports
{
    partial class SzamitogepHibakForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxSzamitogep = new System.Windows.Forms.ListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Számítógép";
            // 
            // listBoxSzamitogep
            // 
            this.listBoxSzamitogep.FormattingEnabled = true;
            this.listBoxSzamitogep.ItemHeight = 20;
            this.listBoxSzamitogep.Location = new System.Drawing.Point(23, 74);
            this.listBoxSzamitogep.Name = "listBoxSzamitogep";
            this.listBoxSzamitogep.Size = new System.Drawing.Size(289, 104);
            this.listBoxSzamitogep.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(42, 205);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(238, 29);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnOKClick);
            // 
            // SzamitogepHibakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 264);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxSzamitogep);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(342, 311);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 311);
            this.Name = "SzamitogepHibakForm";
            this.Text = "Gépek meghibásodásai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ListBox listBoxSzamitogep;
        private Button buttonOK;
    }
}