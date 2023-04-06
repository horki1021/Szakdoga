namespace SzamitogepNyilvantarto.UI.ViewModels;
public class SzamitogepViewModel :Szamitogep
{
    
    public string AllapotElnevezes { get; set; }

    #region Konstruktorok
    public SzamitogepViewModel()
    {

    }

    public SzamitogepViewModel(Szamitogep szamitogep)
    {
        Id=szamitogep.Id;
        Azonosito = szamitogep.Azonosito;
        Processzor=szamitogep.Processzor;
        MemoriaTipusa = szamitogep.MemoriaTipusa;
        MemoriaMerete = szamitogep.MemoriaMerete;
        HattertarTipusa = szamitogep.HattertarTipusa;
        HatertarMerete = szamitogep.HatertarMerete;
        Terem = szamitogep.Terem;
        AllapotId = szamitogep.AllapotId;
        AllapotElnevezes = szamitogep.Allapot.Elnevezes;
    }
    #endregion

    public Szamitogep ToEntity()
    {
        return new Szamitogep()
        {
            Azonosito=this.Azonosito,
            Processzor = this.Processzor,
            MemoriaTipusa = this.MemoriaTipusa,
            MemoriaMerete = this.MemoriaMerete,
            HattertarTipusa = this.HattertarTipusa,
            HatertarMerete = this.HatertarMerete,
            Terem = this.Terem,
            AllapotId = this.AllapotId
        };
    }
    public void ToEntity(Szamitogep entity)
    {
        entity.Azonosito = this.Azonosito;
        entity.Processzor = this.Processzor;
        entity.MemoriaTipusa = this.MemoriaTipusa;
        entity.MemoriaMerete = this.MemoriaMerete;
        entity.HattertarTipusa = this.HattertarTipusa;
        entity.HatertarMerete = this.HatertarMerete;
        entity.Terem = this.Terem;
        entity.AllapotId = this.AllapotId;
    }
}
