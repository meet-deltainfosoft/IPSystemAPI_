using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ILevels _ILevels;
        public LevelsController(ILevels iLevels) {
            _ILevels = iLevels;
        }

        [ActionName("InsertLevels")]
        [HttpPost]
        public async Task<IActionResult> InsertLevels(Levels levels)
        {
            return Ok(await _ILevels.InsertLevels(levels));
        }

        [ActionName("UpdateLevels")]
        [HttpPost]
        public async Task<IActionResult> UpdateLevels(Levels levels)
        {
            return Ok(await _ILevels.UpdateLevels(levels));
        }

        [ActionName("GetAllLevels")]
        [HttpPost]
        public async Task<IActionResult> GetAllLevels(Levels levels)
        {
            return Ok(await _ILevels.GetAllLevels(levels));
        }


        [ActionName("GetLevelsById")]
        [HttpPost]
        public async Task<IActionResult> GetLevelsById(Levels levels)
        {
            return Ok(await _ILevels.GetLevelsById(levels));
        }


        [ActionName("DeleteLevels")]
        [HttpPost]
        public async Task<IActionResult> DeleteLevels(DeleteLevels DeleteLevels)
        {
            return Ok(await _ILevels.DeleteLevels(DeleteLevels));
        }
    }
}
