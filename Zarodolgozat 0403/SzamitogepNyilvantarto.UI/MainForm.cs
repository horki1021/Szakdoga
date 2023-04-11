namespace SzamitogepNyilvantarto.UI;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    public void OnLoad(object sender, EventArgs e)
    {
        BejelentkezesForm form = new BejelentkezesForm();//bejelentkezésform megjelenítése
        form.ShowDialog();
    }

    private void LoadSzamitogepControl(object sender, EventArgs e)//számítógépek kezelése
    {
        SzamitogepControl control = new SzamitogepControl();
        control.Dock = DockStyle.Fill;
        menu.Enabled= false;
        this.Controls.Add(control);
        this.Text = "Számítógépek kezelése";
    }

    private void LoadHibaControl(object sender, EventArgs e)//hinák kezelése
    {
        HibaControl control = new HibaControl();
        control.Dock = DockStyle.Fill;
        menu.Enabled = false;
        this.Controls.Add(control);
        this.Text = "Hibák kezelése";
    }

    private void LoadBeallitasok(object sender, EventArgs e)//beállítás form megjelenítés
    {
        BeallitasokForm form = new BeallitasokForm();
        form.ShowDialog();
    }

    private void LoadIdoszakHibak(object sender, EventArgs e)//időszaki hibák form
    {
        IdoszakHibakForm form = new IdoszakHibakForm();
        form.ShowDialog();
    }

    private void LoadSzamitogepHibak(object sender, EventArgs e)//számítógép hibák form
    {
        SzamitogepHibakForm form = new SzamitogepHibakForm();
        form.ShowDialog();
    }

    public void CloseControl (UserControl control)//controlok bezárása
    {
        this.Controls.Remove(control);
        menu.Enabled = true;
        this.Text = "Számítógép nyilvántartó";
    }
}
