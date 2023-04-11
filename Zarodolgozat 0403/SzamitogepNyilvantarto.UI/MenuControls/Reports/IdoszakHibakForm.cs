namespace SzamitogepNyilvantarto.UI.MenuControls.Reports;

public partial class IdoszakHibakForm : Form
{
    public IdoszakHibakForm()
    {
        InitializeComponent();
        dateTimePickerKezdet.MaxDate=DateTime.Now;
        dateTimePickerVeg.MaxDate=DateTime.Now;
    }

    private void OnKezdetLeave(object sender, EventArgs e) //ne lehessen kisebb a vég mint a kezdett
    {
        dateTimePickerVeg.MinDate = dateTimePickerKezdet.Value.Date;
    }
    
    private async void OnOKClick(object sender, EventArgs e)
    {
        using AppDbContext context = new AppDbContext();
        List<SzamitogepNyilvantarto.Data.Entities.Hiba> viewModel = context.Hibak.Include(x => x.Allapot)
                                                                                    .Include(x => x.HibasGep)
                                                                                    .Include(x => x.CsereGep)
                                                                                    .Where(x => x.BejelentesDatum.Date >= dateTimePickerKezdet.Value.Date && x.BejelentesDatum.Date <= dateTimePickerVeg.Value.Date) // a hiba bejelentése beleessen a kiválasztott tartományba
                                                                                    .ToList();
        if (!viewModel.Any())//nincs hiba az időszakon
        {
            MessageBox.Show("Az adott időszakon nincs hiba!", "Figyelem", MessageBoxButtons.OK);
            return;
        }
        try
        {
            string extension = context.Felhasznalok.First().DokumentumTipus;
            DocumentType type = extension == "pdf" ? DocumentType.PDF : DocumentType.DocX;
            IDocumentGenerator generator = DocumentGeneratorFactory.GetGeneratorType(type); //fájl típust a felhasználok táblából kérdezi
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fullPath = Path.Combine(path, $"Hibák {dateTimePickerKezdet.Value:yyyy.MM.dd}-{dateTimePickerVeg.Value:yyyy.MM.dd}.{extension}");
            await generator.GenerateDocumentAsync("IdoszakHibak", viewModel, fullPath); //dokumentum generálása
            MessageBox.Show("A dokumentum generálása megtörtént.", "Figyelem", MessageBoxButtons.OK);
            this.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("A dokumentum generálása sikertelen.", "Figyelem", MessageBoxButtons.OK);

        }
    }
}
