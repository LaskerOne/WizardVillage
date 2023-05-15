using System.ComponentModel.DataAnnotations;

namespace WizardVillageAPI.Models.DTO
{
  public class VillageDto
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Nombre { get; set; }

    public string? Detalle { get; set; }

    [Required]
    public decimal Tarifa { get; set; }

    public int Ocupantes { get; set; }

    public double MetrosCuadrados { get; set; }

    public string ImagenUrl { get; set; }

    public string GradoSatisfaccion { get; set; }
  }
}