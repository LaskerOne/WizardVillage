using WizardVillageAPI.Models.DTO;

namespace WizardVillageAPI.Data
{
  public static class VillageStore
  {
    public static readonly List<VillageDto> VillageList = new()
    {
      new VillageDto{ Id=1, Nombre="Villa 1", Ocupantes=3, MetrosCuadrados=50},
      new VillageDto{ Id=2, Nombre="Villa 2", Ocupantes=2, MetrosCuadrados=60},
      new VillageDto{ Id=3, Nombre="Villa 3", Ocupantes=5, MetrosCuadrados=120},
      new VillageDto{Id = 4, Nombre = "Villa 4", Ocupantes = 1, MetrosCuadrados = 45},
      new VillageDto{Id = 5, Nombre = "Villa a eliminar", Ocupantes = 4, MetrosCuadrados = 110}
    };
  }
}