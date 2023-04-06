using Microsoft.EntityFrameworkCore.Infrastructure;
using SzamitogepNyilvantarto.Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SzamitogepNyilvantarto.UI.MenuControls.Hiba
{
    public partial class HibaForm : Form
    {
        private HibaViewModel model = new HibaViewModel();

        public delegate void HibaDelegate(HibaViewModel model);

        public static event HibaDelegate NewHibaAdded;
        public static event HibaDelegate HibaUpdated;

        private delegate void Action();
        private Action action;
        public HibaForm()
        {
            InitializeComponent();
            LoadListBoxHibas();
            LoadListBoxCsere();
            dateTimePickerDatum.MaxDate = DateTime.Now;
            dateTimePickerVisszakerulesDatum.Enabled=false;
            richTextBoxJavitasLeiras.Enabled=false;
            dateTimePickerDatum.MaxDate=DateTime.Now;
            action = AddHiba;
            this.Text = "Hiba Hozzáadása";
            model = new HibaViewModel();
        }
        public HibaForm(HibaViewModel model)
        {
            InitializeComponent();
            dateTimePickerDatum.MaxDate = DateTime.Now;
            dateTimePickerVisszakerulesDatum.MaxDate= DateTime.Now;
            this.model = model;
            if(model.CsereGepId == null)
            {
                LoadListBoxCsere();
            }
            ControlEnabled();
            PutData();
            this.Text = "Hiba módosítása";
            action = UpdateHiba;
        }
        private void LoadListBoxHibas()
        {
            using AppDbContext context = new AppDbContext();
            List<SzamitogepViewModel> szamitogepek = context.Szamitogepek.Include(x => x.Allapot)
                                                                      .Include(x => x.Hibak)
                                                                      .Where(x => x.AllapotId == 1)
                                                                      .Select(x => new SzamitogepViewModel(x))
                                                                      .ToList();

            ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBoxHibasGep);
            foreach (SzamitogepNyilvantarto.Data.Entities.Szamitogep szamitogep in szamitogepek)
            {
                //collection.Add(szamitogep);
                listBoxHibasGep.Items.Add(szamitogep);
            }

            //listBoxHibasGep.Items.AddRange(collection);
            listBoxHibasGep.DisplayMember = "Azonosito";
            listBoxHibasGep.ValueMember = "Id";
        }
        private void LoadListBoxCsere()
        {
            using AppDbContext context = new AppDbContext();
            List<SzamitogepViewModel> csereSzamitogepek = context.Szamitogepek.Include(x => x.Allapot)
                                                                      .Include(x => x.Hibak)
                                                                      .Where(x => x.AllapotId == 2)
                                                                      .Select(x => new SzamitogepViewModel(x))
                                                                      .ToList();

            ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBoxCsereGep);
            foreach (SzamitogepNyilvantarto.Data.Entities.Szamitogep szamitogep in csereSzamitogepek)
            {
                //collection.Add(szamitogep);
                listBoxCsereGep.Items.Add(szamitogep);
            }

            //listBoxCsereGep.Items.AddRange(collection);
            listBoxCsereGep.DisplayMember = "Azonosito";
            listBoxCsereGep.ValueMember = "Id";
        }

        private void ControlEnabled()
        {
            listBoxCsereGep.Enabled = model.CsereGepId == null ?
                                      true : false;
            checkBoxUgyanOlyan.Enabled = model.CsereGepId == null ?
                                      true : false;
            listBoxHibasGep.Enabled = false;
            dateTimePickerDatum.Enabled = false;
            richTextBoxHibaLeiras.Enabled = false;
            checkBoxVisszakerules.Enabled = model.VisszakerulesDatum==null ? 
                                                        true : false;
            checkBoxJavitasAlatt.Enabled = model.VisszakerulesDatum == null ?
                                                        true : false;
            checkBoxLeselejtezve.Enabled = model.VisszakerulesDatum == null ?
                                                        true : false;
            buttonOK.Enabled = model.VisszakerulesDatum == null ?
                                                        true : false;
        }

        private void UgyanOlyanCsereCheckedChange(object sender, EventArgs e)
        {
            SzamitogepViewModel? hibasSzamitogep = (SzamitogepViewModel?)listBoxHibasGep.SelectedItem;
            List<SzamitogepViewModel> csereSzamitogepek = new List<SzamitogepViewModel>();
            using AppDbContext context = new AppDbContext();
            ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBoxCsereGep);
            
            if (checkBoxUgyanOlyan.Checked)
            {
                if (hibasSzamitogep == null)
                {
                    MessageBox.Show("Nincs kiválasztva hibás számítógép!", "Figyelem!", MessageBoxButtons.OK);
                    checkBoxUgyanOlyan.Checked = false;
                    return;
                }
                listBoxCsereGep.Items.Clear();

                csereSzamitogepek = context.Szamitogepek.Include(x => x.Allapot)
                                                        .Include(x => x.Hibak)
                                                        .Where(x => x.Allapot.Elnevezes == "Használatra kész")
                                                        .Where(x=>x.HatertarMerete==hibasSzamitogep.HatertarMerete 
                                                                && x.HattertarTipusa==hibasSzamitogep.HattertarTipusa
                                                                && x.MemoriaMerete==hibasSzamitogep.MemoriaMerete
                                                                && x.MemoriaTipusa==hibasSzamitogep.MemoriaTipusa)
                                                        .Select(x => new SzamitogepViewModel(x))
                                                        .ToList();
            }
            else
            {
                listBoxCsereGep.Items.Clear();
                csereSzamitogepek = context.Szamitogepek.Include(x => x.Allapot)
                                                        .Include(x => x.Hibak)
                                                        .Where(x => x.Allapot.Elnevezes == "Használatra kész")
                                                        .Select(x => new SzamitogepViewModel(x))
                                                        .ToList();
            }
            foreach (SzamitogepNyilvantarto.Data.Entities.Szamitogep szamitogep in csereSzamitogepek)
            {
                //collection.Add(szamitogep);
                listBoxCsereGep.Items.Add(szamitogep);
            }

            //listBoxCsereGep.Items.AddRange(collection);
            listBoxCsereGep.DisplayMember = "Azonosito";
            listBoxCsereGep.ValueMember = "Id";

        }

        private void MegoldodottCheckedChange(object sender, EventArgs e)
        {
            if (checkBoxVisszakerules.Checked)
            {
                dateTimePickerVisszakerulesDatum.Enabled = true;
                dateTimePickerVisszakerulesDatum.MaxDate=DateTime.Now;
                richTextBoxJavitasLeiras.Enabled = true;
                checkBoxJavitasAlatt.Enabled= false;
                checkBoxLeselejtezve.Enabled= false;
            }
            else
            {
                dateTimePickerVisszakerulesDatum.Enabled= false;
                richTextBoxJavitasLeiras.Enabled= false;
                richTextBoxJavitasLeiras.Text= string.Empty;
                checkBoxJavitasAlatt.Enabled= true;
                checkBoxLeselejtezve.Enabled = true;
            }
        }

        private void LeselejtezveCheckedChange(object sender, EventArgs e)
        {
            checkBoxJavitasAlatt.Enabled=checkBoxLeselejtezve.Checked?
                                            false: true;
            checkBoxVisszakerules.Enabled = checkBoxLeselejtezve.Checked ?
                                           false : true;
        }

        private void JavitasAlattCheckedChange(object sender, EventArgs e)
        {
            checkBoxLeselejtezve.Enabled = checkBoxJavitasAlatt.Checked ?
                                           false : true;
            checkBoxVisszakerules.Enabled = checkBoxJavitasAlatt.Checked ?
                                           false : true;
        }

        public void CollectData()
        {
            SzamitogepViewModel hibasSzamitogep = (SzamitogepViewModel)listBoxHibasGep.SelectedItem;
            SzamitogepViewModel csereSzamitogep = (SzamitogepViewModel)listBoxCsereGep.SelectedItem;

            model.BejelentesDatum = dateTimePickerDatum.Value;
            model.HibaLeiras = richTextBoxHibaLeiras.Text;

            model.HibasGepId = hibasSzamitogep is null ? 0 : hibasSzamitogep.Id;
            model.HibasGepAzonosito = hibasSzamitogep?.Azonosito;

            model.VisszakerulesDatum = dateTimePickerVisszakerulesDatum.Enabled ? 
                                    dateTimePickerVisszakerulesDatum.Value:null;
            model.JavitasLeiras = richTextBoxJavitasLeiras.Enabled ?
                                richTextBoxJavitasLeiras.Text:null;

            model.CsereGepId = csereSzamitogep?.Id;
            model.CsereGepAzonosito = csereSzamitogep?.Azonosito;
        }
        public void PutData() 
        { 
            dateTimePickerDatum.Value= model.BejelentesDatum;
            richTextBoxHibaLeiras.Text=model.HibaLeiras;

            richTextBoxJavitasLeiras.Text = model.JavitasLeiras;

            using AppDbContext context = new AppDbContext();
            SzamitogepNyilvantarto.Data.Entities.Szamitogep hibasSzamtogep = context.Szamitogepek.Find(model.HibasGepId);

            listBoxHibasGep.Items.Add(new SzamitogepViewModel(hibasSzamtogep));
            listBoxHibasGep.DisplayMember = "Azonosito";
            listBoxHibasGep.ValueMember = "Id";
            listBoxHibasGep.SelectedIndex = 0;
            if (hibasSzamtogep.AllapotId == 5)
            {
                checkBoxLeselejtezve.Checked = true;
                checkBoxJavitasAlatt.Enabled = false;
                checkBoxVisszakerules.Enabled = false;
            }
            if (hibasSzamtogep.AllapotId == 4)
            {
                checkBoxJavitasAlatt.Checked = true;
                checkBoxLeselejtezve.Enabled = false;
                checkBoxVisszakerules.Enabled = false;
            }

            if (model.CsereGepId!=null)
            {
                SzamitogepNyilvantarto.Data.Entities.Szamitogep csereSzamtogep = context.Szamitogepek.Find(model.CsereGepId);

                listBoxCsereGep.Items.Add(new SzamitogepViewModel(csereSzamtogep));
                listBoxCsereGep.DisplayMember = "Azonosito";
                listBoxCsereGep.ValueMember = "Id";
                listBoxCsereGep.SelectedIndex = 0;
            }

            if (model.VisszakerulesDatum!=null)
            {
                dateTimePickerVisszakerulesDatum.Value = (DateTime)model.VisszakerulesDatum;
            }
        }

        public void ShowValidationMessages(Dictionary<string, string> error)
        {
            labelErrorHibasGep.Text = error.GetValueOrDefault(nameof(HibaViewModel.HibasGepId));
            labelErrorHibaLeiras.Text = error.GetValueOrDefault(nameof(HibaViewModel.HibaLeiras));
        }

        public void SzamitogepAllapotValtozas(int allapotId)
        {
            using AppDbContext context = new AppDbContext();
            SzamitogepNyilvantarto.Data.Entities.Szamitogep entity = context.Szamitogepek.Find(model.HibasGepId);
            entity.AllapotId = allapotId;
            model.AllapotId = allapotId;
            entity.Terem = allapotId == 4 ?
                            "Szervíz" : "Raktár";
            context.Update(entity);
            context.SaveChanges();
        }

        public void SzamitogepHasznalatraKesz()
        {
            using AppDbContext context = new AppDbContext();
            SzamitogepNyilvantarto.Data.Entities.Szamitogep entity = context.Szamitogepek.Find(model.CsereGepId);
            entity.AllapotId = 2;
            entity.Terem = "Raktár";
            context.Update(entity);
            context.SaveChanges();
        }

        public void SzamitogepHasznalatban(int id)
        {
            using AppDbContext context = new AppDbContext();
            SzamitogepNyilvantarto.Data.Entities.Szamitogep entity = context.Szamitogepek.Find(id);
            entity.AllapotId = 1;
            entity.Terem = model.Terem;
            context.Update(entity);
            context.SaveChanges();
        }

        public void AllapotBealltas()
        {
            if (model.VisszakerulesDatum is not null)
            {
                SzamitogepHasznalatban(model.HibasGepId);
                model.AllapotId = 6;
                if (model.CsereGepId is not null)
                {
                    SzamitogepHasznalatraKesz();
                }
            }
            else
            {
                if (model.CsereGepId is not null)
                {
                    SzamitogepHasznalatban((int)model.CsereGepId);
                }
                if (checkBoxJavitasAlatt.Checked)
                {
                    SzamitogepAllapotValtozas(4);
                }
                if (checkBoxLeselejtezve.Checked)
                {
                    SzamitogepAllapotValtozas(5);
                }
            }
        }

        public void AddHiba()
        {
            CollectData();
            SzamitogepViewModel hibasSzamitogep = (SzamitogepViewModel)listBoxHibasGep.SelectedItem;
            model.Terem = hibasSzamitogep.Terem;
            ModelValidationResult modelValidation = model.Validate();

            if (!modelValidation.IsValid)
            {
                ShowValidationMessages(modelValidation.Errors);
                return;
            }
            try
            {
                using AppDbContext context = new AppDbContext();
                SzamitogepAllapotValtozas(3);
                AllapotBealltas();
                SzamitogepNyilvantarto.Data.Entities.Hiba entity = model.ToEntity();
                context.Hibak.Add(entity);
                context.SaveChanges();

                model.Id = entity.Id;

				SzamitogepNyilvantarto.Data.Entities.Allapot allapotEntity = context.Allapotok.Find(model.AllapotId);
                model.AllapotElnevezes = allapotEntity.Elnevezes;
				NewHibaAdded?.Invoke(model);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a mentés közben!", "Figyelem", MessageBoxButtons.OK);
                return;
            }
        }
        public void UpdateHiba()
        {
            CollectData();
            using AppDbContext context = new AppDbContext();
            SzamitogepNyilvantarto.Data.Entities.Hiba entity = context.Hibak.Find(model.Id);

            ModelValidationResult modelValidation = model.Validate();
            if (!modelValidation.IsValid)
            {
                ShowValidationMessages(modelValidation.Errors);
                return;
            }
            try
            {
                AllapotBealltas();
                model.ToEntity(entity);
                context.Hibak.Update(entity);
                context.SaveChanges();
                model.AllapotElnevezes = entity.Allapot.Elnevezes;
                HibaUpdated?.Invoke(model);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a mentés közben!", "Figyelem", MessageBoxButtons.OK);
                return;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            action();
        }

        
    }
}
