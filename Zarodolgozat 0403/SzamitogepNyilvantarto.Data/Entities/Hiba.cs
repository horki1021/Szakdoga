namespace SzamitogepNyilvantarto.Data.Entities;

[Table("Hibak")]
public class Hiba
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime BejelentesDatum { get; set; }

    [Required]
    [MaxLength(500)]
    public string HibaLeiras { get; set; }

    public string? JavitasLeiras { get; set; }

    public DateTime? VisszakerulesDatum { get; set; }

    public string Terem { get; set; }


    [ForeignKey("Allapotok")]
    [Range(1, int.MaxValue)]
    public int? AllapotId { get; set; }

    public virtual Allapot? Allapot { get; set; }

    [ForeignKey("Szamitogepek")]
    [Required]
    [Range(1, int.MaxValue, ErrorMessage ="Kötelező megadni")]
    public int HibasGepId { get; set; }

    public virtual Szamitogep HibasGep { get; set; }

    [ForeignKey("Szamitogepek")]
    public int? CsereGepId { get; set; }

    public virtual Szamitogep? CsereGep { get; set; }

}
