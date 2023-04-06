using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzamitogepNyilvantarto.UI.MenuControls
{
    public partial class BeallitasokForm : Form
    {
        public BeallitasokForm()
        {
            InitializeComponent();
            using AppDbContext context = new AppDbContext();
            Felhasznalo felhasznalo = context.Felhasznalok.First();
            if (felhasznalo.DokumentumTipus=="pdf")
            {
                radioButtonPdf.Checked = true;
            }
            else
            {
                radioButtonDocx.Checked = true;
            }
        }
        
        private void OnJelszoOKClick(object sender, EventArgs e)
        {
            try
            {
                using AppDbContext context = new AppDbContext();
                Felhasznalo felhasznalo = context.Felhasznalok.First();
                Felhasznalo bejelentkezo = new Felhasznalo(felhasznalo.FelhasznaloNev, textBoxRegi.Text);
                if (felhasznalo.Jelszo != bejelentkezo.Jelszo)
                {
                    MessageBox.Show("A régi jelszó téves, így a jelszó megváltoztatás meghiúsult.", "Figyelem", MessageBoxButtons.OK);
                    return;
                }
                if (textBoxUj.Text != textBoxMégegyszer.Text || textBoxUj.Text == string.Empty)
                {
                    MessageBox.Show("Az új jelszavak nem egyeznek, így a jelszó megváltoztatás meghiúsult.", "Figyelem", MessageBoxButtons.OK);
                    return;
                }
                felhasznalo.Jelszo = felhasznalo.HashSHA512(textBoxUj.Text);
                context.Felhasznalok.Update(felhasznalo);
                context.SaveChanges();
                MessageBox.Show("A jelszó megváltoztatás sikerült.", "Figyelem", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("A jelszó megváltoztatás nem sikerült.", "Figyelem", MessageBoxButtons.OK);
            }
        }

        private void OnDokumentumOKClick(object sender, EventArgs e)
        {
            try
            {
                using AppDbContext context = new AppDbContext();
                Felhasznalo felhasznalo = context.Felhasznalok.First();
                felhasznalo.DokumentumTipus = radioButtonDocx.Checked ? "docx" : "pdf";
                context.Felhasznalok.Update(felhasznalo);
                context.SaveChanges();
                MessageBox.Show("Az alapérelmezett fájl kiterjesztés megváltoztatása sikerült", "Figyelem", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Az alapérelmezett fájl kiterjesztés megváltoztatása nem sikerült", "Figyelem", MessageBoxButtons.OK);
            }
        }
    }
}
