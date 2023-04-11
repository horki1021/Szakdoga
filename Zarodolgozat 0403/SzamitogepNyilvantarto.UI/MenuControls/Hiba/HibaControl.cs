namespace SzamitogepNyilvantarto.UI.MenuControls.Hiba;

public partial class HibaControl : BaseControl
{
    public HibaControl()
    {
        InitializeComponent();
        SetDGVHeaders();

        HibaForm.NewHibaAdded += OnAddNewHiba;
        HibaForm.HibaUpdated += OnHibaUpdate;
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        FillDGV();

    }

    public void SetDGVHeaders()
    {
        dataGridView.AutoGenerateColumns = false;
        dataGridView.ColumnCount = 12;

        dataGridView.Columns[0].HeaderText = "ID";
        dataGridView.Columns[0].DataPropertyName = nameof(HibaViewModel.Id);
        dataGridView.Columns[0].Visible = false;

        dataGridView.Columns[1].HeaderText= "Hibás gép id";
        dataGridView.Columns[1].DataPropertyName = nameof(HibaViewModel.HibasGepId);
        dataGridView.Columns[1].Visible = false;

        dataGridView.Columns[2].HeaderText = "Hibás gép Azonosító";
        dataGridView.Columns[2].DataPropertyName = nameof(HibaViewModel.HibasGepAzonosito);

        dataGridView.Columns[3].HeaderText = "Csere gép id";
        dataGridView.Columns[3].DataPropertyName = nameof(HibaViewModel.CsereGepId);
        dataGridView.Columns[3].Visible = false;

        dataGridView.Columns[4].HeaderText = "Csere gép Azonosító";
        dataGridView.Columns[4].DataPropertyName = nameof(HibaViewModel.CsereGepAzonosito);

        dataGridView.Columns[5].HeaderText = "Észlelés dátum";
        dataGridView.Columns[5].DataPropertyName = nameof(HibaViewModel.BejelentesDatum);

        dataGridView.Columns[6].HeaderText = "Hiba Leírása";
        dataGridView.Columns[6].DataPropertyName = nameof(HibaViewModel.HibaLeiras);

        dataGridView.Columns[7].HeaderText = "Visszakerülés dátum";
        dataGridView.Columns[7].DataPropertyName = nameof(HibaViewModel.VisszakerulesDatum);

        dataGridView.Columns[8].HeaderText = "Javitás Leírása";
        dataGridView.Columns[8].DataPropertyName = nameof(HibaViewModel.JavitasLeiras);

        dataGridView.Columns[9].HeaderText = "Terem";
        dataGridView.Columns[9].DataPropertyName = nameof(HibaViewModel.Terem);

        dataGridView.Columns[10].HeaderText = "Állapot";
        dataGridView.Columns[10].DataPropertyName= nameof(HibaViewModel.AllapotId);
        dataGridView.Columns[10].Visible = false;

        dataGridView.Columns[11].HeaderText = "Állapot";
        dataGridView.Columns[11].DataPropertyName = nameof(HibaViewModel.AllapotElnevezes);
    }

    public void FillDGV() 
    {
        using AppDbContext context = new AppDbContext();
        adapter.DataSource = context.Hibak.Include(x => x.HibasGep)
                                          .Include(x=>x.Allapot)
                                          .Include(x=>x.CsereGep)
                                          .Select(x => new HibaViewModel(x))
                                          .ToList();
        dataGridView.DataSource = adapter;
    }

    protected override void OnAddClick(object sender, EventArgs e)
    {
        HibaForm form = new HibaForm();
        form.ShowDialog();
    }

    protected override void OnUpdateClick(object sender, EventArgs e)
    {
        HibaViewModel model = (HibaViewModel)adapter.Current;
        if (model == null)
        {
            MessageBox.Show("Jelöljön ki egy hibát!", "Figyelem!", MessageBoxButtons.OK);
            return;
        }
        HibaForm form = new HibaForm(model);
        form.ShowDialog();
    }

    private void OnAddNewHiba(HibaViewModel model)
    {
        adapter.Add(model);
    }
    private void OnHibaUpdate(HibaViewModel model)
    {
        HibaViewModel viewModel = (HibaViewModel)adapter.Current;
        int index = adapter.IndexOf(viewModel);
        adapter.RemoveAt(index);
        adapter.Insert(index, model);
    }
}
