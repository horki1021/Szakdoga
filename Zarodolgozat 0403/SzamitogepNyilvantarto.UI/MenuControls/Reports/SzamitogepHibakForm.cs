﻿namespace SzamitogepNyilvantarto.UI.MenuControls.Reports;

public partial class SzamitogepHibakForm : Form
{
    public SzamitogepHibakForm()
    {
        InitializeComponent();
        LoadListBox();
    }

    private void LoadListBox() //listbox számítógéppekkel való feétöltése
    {
        using AppDbContext context = new AppDbContext();
        List<SzamitogepNyilvantarto.Data.Entities.Szamitogep> szamitogepek = context.Szamitogepek.ToList();

        foreach (SzamitogepNyilvantarto.Data.Entities.Szamitogep szamitogep in szamitogepek)
        {
            listBoxSzamitogep.Items.Add(szamitogep);
        }
        listBoxSzamitogep.DisplayMember = "Azonosito";
        listBoxSzamitogep.ValueMember = "Id";
    }

    private async void OnOKClick(object sender, EventArgs e)
    {
        using AppDbContext context = new AppDbContext();
        List<SzamitogepNyilvantarto.Data.Entities.Hiba> viewModel = context.Hibak.Include(x => x.Allapot)
                                                                                    .Include(x => x.HibasGep)
                                                                                    .ThenInclude(x => x.Allapot)
                                                                                    .Include(x => x.CsereGep)
                                                                                    .Where(x => x.HibasGep == listBoxSzamitogep.SelectedItem) //azok a hibák amiknek a hibás gépe a kiválasztott
                                                                                    .ToList();
			if (listBoxSzamitogep.SelectedItem is null) //nincs kijelölve semmi
			{
				MessageBox.Show("Nincs kijelölve számítógép!", "Figyelem", MessageBoxButtons.OK);
				return;
			}
			if (!viewModel.Any())// nincs a gépnek hibája
			{
				MessageBox.Show("Az adott számítógépnek nincs hibája!", "Figyelem", MessageBoxButtons.OK);
				return;
			}

			try
        {
            string extension = context.Felhasznalok.First().DokumentumTipus;
            DocumentType type = extension == "pdf" ? DocumentType.PDF : DocumentType.DocX;
            IDocumentGenerator generator = DocumentGeneratorFactory.GetGeneratorType(type);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fullPath = Path.Combine(path, $"{viewModel[0].HibasGep.Azonosito} hibái.{extension}");
            await generator.GenerateDocumentAsync("SzamitogepHibak", viewModel, fullPath);// dokumentum generálása
            MessageBox.Show("A dokumentum generálása megtörtént.", "Figyelem", MessageBoxButtons.OK);
            this.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("A dokumentum generálása sikertelen.", "Figyelem", MessageBoxButtons.OK);

        }
    }
}
