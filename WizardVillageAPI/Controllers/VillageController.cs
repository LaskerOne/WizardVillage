using Microsoft.AspNetCore.Mvc;
using WizardVillageAPI.Data;
using WizardVillageAPI.Models.DTO;

namespace WizardVillageAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VillageController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<VillageDto>> GetListVillages() => Ok(VillageStore.VillageList);

    [HttpGet("id")]
    public ActionResult<VillageDto> GetVillageById(int id)
    {
      if (id == 0)
      {
        return BadRequest();
      }
      var village = VillageStore.VillageList.FirstOrDefault(x => x.Id == id);

      if (village == null)
      {
        return NotFound();
      }

      return Ok(village);
    }
  };
}