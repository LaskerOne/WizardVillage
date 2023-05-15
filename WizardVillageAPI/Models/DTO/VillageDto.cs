using System.ComponentModel.DataAnnotations;

namespace WizardVillageAPI.Models.DTO
{
  public class VillageDto
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Nombre { get; set; }

    public int Ocupantes { get; set; }

    public int MetrosCuadrados { get; set; }
  }
}