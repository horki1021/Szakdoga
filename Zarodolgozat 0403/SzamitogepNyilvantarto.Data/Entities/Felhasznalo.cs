namespace SzamitogepNyilvantarto.Data.Entities;

[Table("Felhasznalok")]
public class Felhasznalo
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string FelhasznaloNev { get; set; }

    [Required]
    public string  Jelszo{ get; set; }

    [Required]
    public string DokumentumTipus { get; set; }

    public Felhasznalo(string felhasznaloNev, string jelszo)
    {
        FelhasznaloNev = felhasznaloNev;
        Jelszo = HashSHA512(jelszo);
    }

    public Felhasznalo() { }

    public Felhasznalo(int id, string felhasznaloNev, string jelszo, string dokumentumTipus)
    {
        Id = id;
        FelhasznaloNev = felhasznaloNev;
        Jelszo = HashSHA512(jelszo);
        DokumentumTipus = dokumentumTipus;
    }

    public Felhasznalo(string felhasznaloNev, string jelszo, string dokumentumTipus)
    {
        FelhasznaloNev = felhasznaloNev;
        Jelszo = HashSHA512(jelszo);
        DokumentumTipus = dokumentumTipus;
    }

    private string ToNumber(byte[] bytes)
    {
        StringBuilder result = new StringBuilder(bytes.Length * 2);
        for (int i = 0; i < bytes.Length; i++)
        {
            result.Append(bytes[i].ToString());
        }
        return result.ToString();
    }

    public string HashSHA512(string input)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        data = new SHA512Managed().ComputeHash(data);
        string hash = ToNumber(data);
        return hash;
    }

}
