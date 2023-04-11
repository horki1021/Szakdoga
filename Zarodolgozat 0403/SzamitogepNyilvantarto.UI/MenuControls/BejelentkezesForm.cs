namespace SzamitogepNyilvantarto.UI.MenuControls;

public partial class BejelentkezesForm : Form
{
    public BejelentkezesForm()
    {
        InitializeComponent();
    }

    private void OnOKClick(object sender, EventArgs e)//felhasználó ellenörzés
    {
        this.Text = "Bejelentkezés";
        buttonOK.Text = "Bejelentkezés";
        using AppDbContext context = new AppDbContext();
        Felhasznalo felhasznalo = context.Felhasznalok.First();
        Felhasznalo bejelentkezo = new Felhasznalo(textBoxFelhsznaloNev.Text, textBoxJelszo.Text);
        if (bejelentkezo.FelhasznaloNev == felhasznalo.FelhasznaloNev && bejelentkezo.Jelszo == felhasznalo.Jelszo)
        {
            this.Close();
        }
        else
        {
            MessageBox.Show("Téves felhasználónév vagy jelszó!", "Figyelem", MessageBoxButtons.OK);
        }
    }
}
