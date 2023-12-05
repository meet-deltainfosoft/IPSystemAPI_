using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlant _iplant;

        public PlantsController(IPlant plant)
        {
                _iplant = plant;
        }

        [ActionName("InsertPlant")]
        [HttpPost]
        public async Task<IActionResult> InsertPlant(Plant plant)
        {
            return Ok(await _iplant.InsertPlant(plant));
        }


        [ActionName("UpdatePlant")]
        [HttpPost]
        public async Task<IActionResult> UpdatePlant(Plant plant)
        {
            return Ok(await _iplant.UpdatePlant(plant));
        }


        [ActionName("GetAllPlant")]
        [HttpPost]
        public async Task<IActionResult> GetAllPlant(Plant plant)
        {
            return Ok(await _iplant.GetAllPlant(plant));
        }

        [ActionName("GetPlantById")]
        [HttpPost]
        public async Task<IActionResult> GetPlantById(Plant plant)
        {
            return Ok(await _iplant.GetPlantById(plant));
        }
    }
}
