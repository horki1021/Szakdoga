using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SzamitogepNyilvantarto.UI.MenuControls;
using SzamitogepNyilvantarto.UI.MenuControls.Hiba;
using SzamitogepNyilvantarto.UI.MenuControls.Reports;
using SzamitogepNyilvantarto.UI.MenuControls.Szamitogep;

namespace SzamitogepNyilvantarto.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void OnLoad(object sender, EventArgs e)
        {
            BejelentkezesForm form = new BejelentkezesForm();
            form.ShowDialog();
        }

        private void LoadSzamitogepControl(object sender, EventArgs e)
        {
            SzamitogepControl control = new SzamitogepControl();
            control.Dock = DockStyle.Fill;
            menu.Enabled= false;
            this.Controls.Add(control);
            this.Text = "Számítógépek kezelése";
        }

        private void LoadHibaControl(object sender, EventArgs e)
        {
            HibaControl control = new HibaControl();
            control.Dock = DockStyle.Fill;
            menu.Enabled = false;
            this.Controls.Add(control);
            this.Text = "Hibák kezelése";
        }

        private void LoadBeallitasok(object sender, EventArgs e)
        {
            BeallitasokForm form = new BeallitasokForm();
            form.ShowDialog();
        }

        private void LoadIdoszakHibak(object sender, EventArgs e)
        {
            IdoszakHibakForm form = new IdoszakHibakForm();
            form.ShowDialog();
        }

        private void LoadSzamitogepHibak(object sender, EventArgs e)
        {
            SzamitogepHibakForm form = new SzamitogepHibakForm();
            form.ShowDialog();
        }

        public void CloseControl (UserControl control)
        {
            this.Controls.Remove(control);
            menu.Enabled = true;
            this.Text = "Számítógép nyilvántartó";
        }
    }
}
