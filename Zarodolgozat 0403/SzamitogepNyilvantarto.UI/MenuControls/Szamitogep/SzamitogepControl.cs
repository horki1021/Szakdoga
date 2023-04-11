namespace SzamitogepNyilvantarto.UI.MenuControls.Szamitogep
{
    public partial class SzamitogepControl : BaseControl
    {
        public SzamitogepControl()
        {
            InitializeComponent();
            SetDGVHeaders();

            SzamitogepForm.SzamitogepAdded += OnAddNewSzamitogep;
            SzamitogepForm.SzamitogepUpdated += OnSzamitogepUpdate;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FillDGV();
        }

        public void SetDGVHeaders()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.ColumnCount = 10;

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[0].DataPropertyName = nameof(SzamitogepViewModel.Id);
            dataGridView.Columns[0].Visible = false;

            dataGridView.Columns[1].HeaderText = "Azonosító";
            dataGridView.Columns[1].DataPropertyName = nameof(SzamitogepViewModel.Azonosito);

            dataGridView.Columns[2].HeaderText = "Processzor";
            dataGridView.Columns[2].DataPropertyName = nameof(SzamitogepViewModel.Processzor);

            dataGridView.Columns[3].HeaderText = "Memória Típusa";
            dataGridView.Columns[3].DataPropertyName = nameof(SzamitogepViewModel.MemoriaTipusa);

            dataGridView.Columns[4].HeaderText = "Memória Mérete";
            dataGridView.Columns[4].DataPropertyName = nameof(SzamitogepViewModel.MemoriaMerete);

            dataGridView.Columns[5].HeaderText = "Háttértar Típusa";
            dataGridView.Columns[5].DataPropertyName = nameof(SzamitogepViewModel.HattertarTipusa);

            dataGridView.Columns[6].HeaderText = "Háttértar Mérete";
            dataGridView.Columns[6].DataPropertyName = nameof(SzamitogepViewModel.HatertarMerete);

            dataGridView.Columns[7].HeaderText = "Terem";
            dataGridView.Columns[7].DataPropertyName = nameof(SzamitogepViewModel.Terem);

            dataGridView.Columns[8].HeaderText = "AllapotId";
            dataGridView.Columns[8].DataPropertyName = nameof(SzamitogepViewModel.AllapotId);
            dataGridView.Columns[8].Visible = false;

            dataGridView.Columns[9].HeaderText = "Állapot";
            dataGridView.Columns[9].DataPropertyName = nameof(SzamitogepViewModel.AllapotElnevezes);
        }

        public void FillDGV()
        {
            using AppDbContext context = new AppDbContext();
            adapter.DataSource = context.Szamitogepek.Include(x=>x.Allapot)
                                                     .Select(x => new SzamitogepViewModel(x))
                                                     .ToList();

            dataGridView.DataSource = adapter;
        }

        protected override void OnAddClick(object sender, EventArgs e)
        {
            SzamitogepForm form=new SzamitogepForm();
            form.ShowDialog();
        }

        protected override void OnUpdateClick(object sender, EventArgs e)
        {
            SzamitogepViewModel model = (SzamitogepViewModel)adapter.Current;
            if (model == null)
            {
                MessageBox.Show("Jelöljön ki egy számítógépet!", "Figyelem!", MessageBoxButtons.OK);
                return;
            }
            SzamitogepForm form = new SzamitogepForm(model);
            form.ShowDialog();
        }

        private void OnAddNewSzamitogep(SzamitogepViewModel model)
        {
            adapter.Add(model);
        }
        private void OnSzamitogepUpdate(SzamitogepViewModel model)
        {
            SzamitogepViewModel viewModel = (SzamitogepViewModel)adapter.Current;
            int index = adapter.IndexOf(viewModel);
            adapter.RemoveAt(index);
            adapter.Insert(index, model);
        }
    }
}
