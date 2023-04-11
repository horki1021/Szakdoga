namespace SzamitogepNyilvantarto.UI.MenuControls.Szamitogep;

public partial class SzamitogepForm : Form
{
    private List<Allapot> allapotok = new List<Allapot>()
    {
        new Allapot{Id=0, Elnevezes="Kérem válasszon..."}
    };
    private SzamitogepViewModel model=null;

    public delegate void SzamitogepDelegate(SzamitogepViewModel model);

    public static event SzamitogepDelegate SzamitogepAdded;
    public static event SzamitogepDelegate SzamitogepUpdated;

    private delegate void Action();
    private Action action;
    public SzamitogepForm()// számítógép hozzáadása
    {
        InitializeComponent();
        model= new SzamitogepViewModel();
        LoadAllapot();
        FillComboBox();
        action = AddSzamitogep;
    }

    public SzamitogepForm(SzamitogepViewModel model) //számítógép módosítása
    {
        InitializeComponent();
        this.model = model;
        LoadAllapot(model.AllapotId);
        FillComboBox();
        PutDataInControls();
        action = UpdateSzamitogep;
        this.Text = "Számítógép módosítása";
    }

    private void LoadAllapot() // állapodok kigyüjtése (használatban és használatra kész)
    {
        using AppDbContext context = new AppDbContext();
        allapotok.AddRange(context.Allapotok.Where(x=>x.Id==1 || x.Id==2).ToList());
    }

    private void LoadAllapot(int allapotid)//állapot kigyüjtése a módosításhoz
    {
        using AppDbContext context = new AppDbContext();
        allapotok.AddRange(context.Allapotok.Where(x => x.Id == allapotid).ToList());
    }

    private void FillComboBox() //állapot legördülő lista feltöltése
    {
        comboBoxAllapot.DataSource = allapotok;
        comboBoxAllapot.DisplayMember = "Elnevezes";
        comboBoxAllapot.ValueMember = "Id";
    }

    private void AllapotSelectedChange(object sender, EventArgs e)//terem változtatása az állapot alapján
    {
        if(comboBoxAllapot.SelectedValue is Allapot)
        {
            return;
        }
        if (((int)comboBoxAllapot.SelectedValue) == 1 || ((int)comboBoxAllapot.SelectedValue) == 0)
        {
            textBoxTerem.Enabled = true;
            textBoxTerem.Text = string.Empty;
        }
        else
        {
            textBoxTerem.Enabled = false;
            if((int)comboBoxAllapot.SelectedValue == 4)
            {
                textBoxTerem.Text = "Szervíz";
            }
            else
            {
                textBoxTerem.Text = "Raktár";
            }
        }
    }

    private void CollectData() //adatok összegyűjtése
    {
        model.Azonosito = textBoxAzonosito.Text;
        model.Processzor = textBoxProcesszor.Text;
        model.MemoriaTipusa = textBoxMemoriaTipus.Text;
        model.MemoriaMerete = numericTextBoxMemoriaMeret.IntValue == null ?
                              -1:(int)numericTextBoxMemoriaMeret.IntValue;
        model.HattertarTipusa = textBoxHattertarTipus.Text;
        model.HatertarMerete = numericTextBoxHattertarMeret.IntValue == null ? 
                               -1 : (int)numericTextBoxHattertarMeret.IntValue;
        model.Terem = textBoxTerem.Text;
        model.AllapotId = (int)comboBoxAllapot.SelectedValue;
        model.AllapotElnevezes = comboBoxAllapot.Text;
    }

    private void PutDataInControls()// meglévő adatokkal feltöltés
    {
        textBoxAzonosito.Text= model.Azonosito;
        textBoxProcesszor.Text= model.Processzor;
        textBoxMemoriaTipus.Text = model.MemoriaTipusa;
        numericTextBoxMemoriaMeret.IntValue = model.MemoriaMerete;
        textBoxHattertarTipus.Text = model.HattertarTipusa;
        numericTextBoxHattertarMeret.IntValue = model.HatertarMerete;
        comboBoxAllapot.SelectedValue = model.AllapotId;
		textBoxTerem.Text = model.Terem;
	}

    private void ShowErrors(Dictionary<string, string> errors) //hibauzenetek kiírása
    {
        labelErrorAzonosito.Text = errors.GetValueOrDefault(nameof(SzamitogepViewModel.Azonosito));
        labelErrorProcesszor.Text = errors.GetValueOrDefault(nameof(SzamitogepViewModel.Processzor));
        labelErrorMemoriaTipus.Text = errors.GetValueOrDefault(nameof(SzamitogepViewModel.MemoriaTipusa));
        labelErrorMemoriaMeret.Text = errors.GetValueOrDefault(nameof(SzamitogepViewModel.MemoriaMerete));
        labelErrorHattertarTipus.Text = errors.GetValueOrDefault(nameof(SzamitogepViewModel.HattertarTipusa));
        labelErrorHattertarMeret.Text = errors.GetValueOrDefault(nameof(SzamitogepViewModel.HatertarMerete));
        labelErrorTerem.Text = errors.GetValueOrDefault(nameof(SzamitogepViewModel.Terem));
        labelErrorAllapot.Text = errors.GetValueOrDefault(nameof(SzamitogepViewModel.AllapotId));
    }

    private bool IsSzamitogepExists() //ellenörzés hogy az azonosító már létezike
    {
        using AppDbContext context = new AppDbContext();
        int db = context.Szamitogepek.Count(x => x.Id != model.Id && x.Azonosito.ToLower() == model.Azonosito.ToLower());

        if (db != 0)
        {
            MessageBox.Show($"{model.Azonosito} azonosítójú számítógép már létezik.");
            return true;
        }

        return false;
    }

    private void AddSzamitogep() //számítógép hozzáadása
    {
        CollectData();
        ModelValidationResult validationResult = model.Validate();
        ShowErrors(validationResult.Errors);
        if (!validationResult.IsValid) 
        {
            return;
        }

        if(IsSzamitogepExists())
        {
            return;
        }
        try
        {
            using AppDbContext context = new AppDbContext();
            SzamitogepNyilvantarto.Data.Entities.Szamitogep entity = model.ToEntity();
            context.Szamitogepek.Add(entity);
            context.SaveChanges();
            model.Id = entity.Id;

            SzamitogepAdded?.Invoke(model);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hiba a mentés közben!", "Figyelem", MessageBoxButtons.OK);
            return;
        }
    }

    private void UpdateSzamitogep() //számítógép módosítása
    {
        CollectData();

        using AppDbContext context = new AppDbContext();
        SzamitogepNyilvantarto.Data.Entities.Szamitogep entity = context.Szamitogepek.Find(model.Id);

        ModelValidationResult validationResult = model.Validate();
        ShowErrors(validationResult.Errors);
        if (!validationResult.IsValid)
        {
            return;
        }

        if (IsSzamitogepExists())
        {
            return;
        }

        try
        {
            model.ToEntity(entity);
            context.Szamitogepek.Update(entity);
            context.SaveChanges();
            SzamitogepUpdated?.Invoke(model);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hiba a mentés közben!", "Figyelem", MessageBoxButtons.OK);
            return;
        }
    }

    private void OK_Click(object sender, EventArgs e) //ok gombra kattintáskor lefut a megfelelő függvény
    {
        action();
    }
}
