namespace SzamitogepNyilvantarto.UI
{
    partial class MainForm
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
			this.menu = new System.Windows.Forms.MenuStrip();
			this.szamitogepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hibakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dokumentumGenerálásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.számítógépÖsszesMeghibásodásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.időszakMeghibásogásaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// menu
			// 
			this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.szamitogepToolStripMenuItem,
            this.hibakToolStripMenuItem,
            this.dokumentumGenerálásToolStripMenuItem,
            this.beállításokToolStripMenuItem});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
			this.menu.Size = new System.Drawing.Size(800, 30);
			this.menu.TabIndex = 0;
			this.menu.Text = "menuStrip1";
			// 
			// szamitogepToolStripMenuItem
			// 
			this.szamitogepToolStripMenuItem.Name = "szamitogepToolStripMenuItem";
			this.szamitogepToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
			this.szamitogepToolStripMenuItem.Text = "Számítógépek";
			this.szamitogepToolStripMenuItem.Click += new System.EventHandler(this.LoadSzamitogepControl);
			// 
			// hibakToolStripMenuItem
			// 
			this.hibakToolStripMenuItem.Name = "hibakToolStripMenuItem";
			this.hibakToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
			this.hibakToolStripMenuItem.Text = "Hibák";
			this.hibakToolStripMenuItem.Click += new System.EventHandler(this.LoadHibaControl);
			// 
			// dokumentumGenerálásToolStripMenuItem
			// 
			this.dokumentumGenerálásToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.számítógépÖsszesMeghibásodásaToolStripMenuItem,
            this.időszakMeghibásogásaiToolStripMenuItem});
			this.dokumentumGenerálásToolStripMenuItem.Name = "dokumentumGenerálásToolStripMenuItem";
			this.dokumentumGenerálásToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
			this.dokumentumGenerálásToolStripMenuItem.Text = "Dokumentum generálás";
			// 
			// számítógépÖsszesMeghibásodásaToolStripMenuItem
			// 
			this.számítógépÖsszesMeghibásodásaToolStripMenuItem.Name = "számítógépÖsszesMeghibásodásaToolStripMenuItem";
			this.számítógépÖsszesMeghibásodásaToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
			this.számítógépÖsszesMeghibásodásaToolStripMenuItem.Text = "Számítógép meghibásodásai";
			this.számítógépÖsszesMeghibásodásaToolStripMenuItem.Click += new System.EventHandler(this.LoadSzamitogepHibak);
			// 
			// időszakMeghibásogásaiToolStripMenuItem
			// 
			this.időszakMeghibásogásaiToolStripMenuItem.Name = "időszakMeghibásogásaiToolStripMenuItem";
			this.időszakMeghibásogásaiToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
			this.időszakMeghibásogásaiToolStripMenuItem.Text = "Időszak meghibásogásai";
			this.időszakMeghibásogásaiToolStripMenuItem.Click += new System.EventHandler(this.LoadIdoszakHibak);
			// 
			// beállításokToolStripMenuItem
			// 
			this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
			this.beállításokToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
			this.beállításokToolStripMenuItem.Text = "Beállítások";
			this.beállításokToolStripMenuItem.Click += new System.EventHandler(this.LoadBeallitasok);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 451);
			this.Controls.Add(this.menu);
			this.MainMenuStrip = this.menu;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Számítógép nyilvántartó";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.OnLoad);
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem szamitogepToolStripMenuItem;
        private ToolStripMenuItem hibakToolStripMenuItem;
        private ToolStripMenuItem dokumentumGenerálásToolStripMenuItem;
        private ToolStripMenuItem számítógépÖsszesMeghibásodásaToolStripMenuItem;
        private ToolStripMenuItem időszakMeghibásogásaiToolStripMenuItem;
        private ToolStripMenuItem beállításokToolStripMenuItem;
    }
}