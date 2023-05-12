using WizardVillageAPI.Models.DTO;

namespace WizardVillageAPI.Data
{
  public static class VillageStore
  {
    public static readonly List<VillageDto> VillageList = new()
    {
      new VillageDto{ Id=1, nombre="Villa 1" },
      new VillageDto{ Id=2, nombre="Villa 2"},
      new VillageDto{ Id=3, nombre="Villa 3"}
    };
  }
}