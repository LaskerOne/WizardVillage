using System.ComponentModel.DataAnnotations;

namespace WizardVillageAPI.Models
{
  public class VillageModel
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Nombre { get; set; }

    public string? Detalle { get; set; }

    [Required]
    public decimal Tarifa { get; set; }

    public int Ocupantes { get; set; }

    public double MetrosCuadrados { get; set; }

    public string ImagenUrl { get; set; }

    public string GradoSatisfaccion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime FechaActualizacion { get; set; }
  }
}