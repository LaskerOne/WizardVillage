using Microsoft.AspNetCore.Mvc;
using WizardVillageAPI.Data;
using WizardVillageAPI.Models.DTO;

namespace WizardVillageAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VillageController : ControllerBase
  {
    //GET ALL
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<VillageDto>> GetListVillages() => Ok(VillageStore.VillageList);

    //GET BY ID
    [HttpGet("{id}", Name = "GetVillage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(404)]
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

    //POST
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VillageDto> CreateVillage([FromBody] VillageDto villa)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (VillageStore.VillageList.FirstOrDefault(x => x.Nombre.ToLower() == villa.Nombre.ToLower()) != null)
      {
        ModelState.AddModelError("NombreExiste", "Ya existe una Villa con ese nombre en la lista de registros");
        return BadRequest(ModelState);
      }

      if (villa == null)
      {
        return BadRequest();
      }
      if (villa.Id > 0)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }

      villa.Id = VillageStore.VillageList.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
      VillageStore.VillageList.Add(villa);

      return CreatedAtRoute("GetVillage", new { id = villa.Id }, villa);
    }

    //PUT
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdateVilla(int id, [FromBody] VillageDto villa)
    {
      if (villa == null || id != villa.Id)
      {
        return BadRequest();
      }

      var Selectvilla = VillageStore.VillageList.FirstOrDefault(x => x.Id == id);
      Selectvilla.Nombre = villa.Nombre;
      Selectvilla.MetrosCuadrados = villa.MetrosCuadrados;
      Selectvilla.Ocupantes = villa.Ocupantes;

      return NoContent();
    }

    //DELETE
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteVillage(int id)
    {
      if (id == 0)
      {
        return BadRequest();
      }

      var villa = VillageStore.VillageList.FirstOrDefault(x => x.Id == id);

      if (villa == null)
      {
        return NotFound();
      }

      VillageStore.VillageList.Remove(villa);

      return NoContent();
    }
  };
}