namespace SzamitogepNyilvantarto.UI.ViewModels;

public class HibaViewModel : Hiba
{
    public string HibasGepAzonosito { get; set; }

    public string? CsereGepAzonosito { get; set; }

    public string? AllapotElnevezes { get; set; }


    public HibaViewModel() { }

    public HibaViewModel(Hiba hiba)
    {
        Id= hiba.Id;
        BejelentesDatum= hiba.BejelentesDatum;
        HibaLeiras= hiba.HibaLeiras;
        HibasGepId= hiba.HibasGepId;
        HibasGepAzonosito = hiba.HibasGep.Azonosito;
        Terem = hiba.Terem;
        CsereGepId= hiba.CsereGepId;
        CsereGepAzonosito = hiba.CsereGep?.Azonosito;
        VisszakerulesDatum= hiba.VisszakerulesDatum;
        JavitasLeiras = hiba.JavitasLeiras;
        AllapotId= hiba.AllapotId;
        AllapotElnevezes = hiba.Allapot.Elnevezes;
    }

    public Hiba ToEntity()
    {
        return new Hiba()
        {
            BejelentesDatum= BejelentesDatum,
            HibaLeiras = HibaLeiras,
            HibasGepId= HibasGepId,
            CsereGepId=CsereGepId,
            VisszakerulesDatum=VisszakerulesDatum,
            JavitasLeiras=JavitasLeiras,
            Terem=Terem,
            AllapotId=AllapotId,
        };
    }
    public void ToEntity(Hiba entity)
    {
        entity.HibaLeiras = HibaLeiras;
        entity.VisszakerulesDatum = VisszakerulesDatum;
        entity.BejelentesDatum = BejelentesDatum;
        entity.JavitasLeiras = JavitasLeiras;
        entity.CsereGepId=CsereGepId;
        entity.HibasGepId=HibasGepId;
        entity.Terem=Terem;
        entity.AllapotId = AllapotId;
    }
}
