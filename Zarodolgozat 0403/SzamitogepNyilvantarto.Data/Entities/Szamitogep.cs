namespace SzamitogepNyilvantarto.Data.Entities;

[Table("Szamitogepek")]
public class Szamitogep
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Kötelező megadni!")]
    public string Azonosito { get; set; }

    [Required(ErrorMessage = "Kötelező megadni!")]
    [MaxLength(100)]
    public string Processzor { get; set; }

    [Required(ErrorMessage = "Kötelező megadni!")]
    [MinLength(4, ErrorMessage = "A következő formában: ddr1, ddr2, ddr3, ...")]
    [MaxLength(4 , ErrorMessage ="A következő formában: ddr1, ddr2, ddr3, ...")]
    public string MemoriaTipusa { get; set; }

    [Required(ErrorMessage = "Kötelező megadni!")]
    [Range(4,32)]
    public int MemoriaMerete { get; set;}

    [Required(ErrorMessage = "Kötelező megadni!")]
    [MinLength(3, ErrorMessage = "ssd vagy hdd")]
    [MaxLength(3, ErrorMessage = "ssd vagy hdd")]
    public string HattertarTipusa { get; set; }

    [Required(ErrorMessage = "Kötelező megadni!")]//sdd 120-2t hdd500-3t
    [Range(120, 3000, ErrorMessage ="120 és 3000 közötti egész szám. (GB)")]
    public int HatertarMerete { get; set; }

    [Required(ErrorMessage = "Kötelező megadni!")]
    [MaxLength(50)]
    public string Terem { get; set; }


    [Required]
    [ForeignKey("Allapotok")]
    [Range(1, 5, ErrorMessage ="Kérem válasszon!")]
    public int AllapotId { get; set; }

    public virtual Allapot Allapot { get; set; }

    [InverseProperty(nameof(Hiba.HibasGep))]
    public virtual IList<Hiba> Hibak { get; set; }

    [InverseProperty(nameof(Hiba.CsereGep))]
    public virtual IList<Hiba> Cserek { get; set; }

}
