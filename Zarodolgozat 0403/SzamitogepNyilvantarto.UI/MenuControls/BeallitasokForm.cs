namespace SzamitogepNyilvantarto.UI.MenuControls;

public partial class BeallitasokForm : Form
{
    public BeallitasokForm()
    {
        InitializeComponent();
        using AppDbContext context = new AppDbContext();
        Felhasznalo felhasznalo = context.Felhasznalok.First(); //az adatbázisba csak egy felhasználó van
        if (felhasznalo.DokumentumTipus=="pdf") //rádiógomb beállítása az adatbázisban tárolt adat szerint
        {
            radioButtonPdf.Checked = true;
        }
        else
        {
            radioButtonDocx.Checked = true;
        }
    }
    
    private void OnJelszoOKClick(object sender, EventArgs e) //jelszó módosítás
    {
        try
        {
            using AppDbContext context = new AppDbContext();
            Felhasznalo felhasznalo = context.Felhasznalok.First();
            Felhasznalo bejelentkezo = new Felhasznalo(felhasznalo.FelhasznaloNev, textBoxRegi.Text);
            if (felhasznalo.Jelszo != bejelentkezo.Jelszo)//a rég jelszavak megegyeznek
            {
                MessageBox.Show("A régi jelszó téves, így a jelszó megváltoztatás meghiúsult.", "Figyelem", MessageBoxButtons.OK);
                return;
            }
            if (textBoxUj.Text != textBoxMégegyszer.Text || textBoxUj.Text == string.Empty)// az új jelszavak nem egyeznek
            {
                MessageBox.Show("Az új jelszavak nem egyeznek, így a jelszó megváltoztatás meghiúsult.", "Figyelem", MessageBoxButtons.OK);
                return;
            }
            felhasznalo.Jelszo = felhasznalo.HashSHA512(textBoxUj.Text);
            context.Felhasznalok.Update(felhasznalo);//a jelszó elmentése az adatbázisba
            context.SaveChanges();
            MessageBox.Show("A jelszó megváltoztatás sikerült.", "Figyelem", MessageBoxButtons.OK);
        }
        catch (Exception)
        {
            MessageBox.Show("A jelszó megváltoztatás nem sikerült.", "Figyelem", MessageBoxButtons.OK);
        }
    }

    private void OnDokumentumOKClick(object sender, EventArgs e) //dokumentum kiterjesztés változtatás
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
