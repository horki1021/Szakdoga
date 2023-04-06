namespace SzamitogepNyilvantarto.Data.Entities;

[Table("Allapotok")]
public class Allapot
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Elnevezes { get; set; }

    [InverseProperty(nameof(Szamitogep.Allapot))]
    public virtual IList<Szamitogep> Szamitogepek { get; set; }

    [InverseProperty(nameof(Hiba.Allapot))]
    public virtual IList<Hiba> Hibak { get; set; }
}
