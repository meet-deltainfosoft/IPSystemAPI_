using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PokaYokeDashboardController : ControllerBase
    {
        private readonly IPokaYokeDashboard _IpokaYokeDashboard;

        public PokaYokeDashboardController(IPokaYokeDashboard IpokaYokeDashboard)
        {
            _IpokaYokeDashboard = IpokaYokeDashboard;
        }

        [HttpPost]
        [ActionName("GetPokaYokeDashBoard")]
        public async Task<IActionResult> GetPokaYokeDashBoard(PokaYokeDashboard pokaYokeDashboard)
        {
            return Ok(await _IpokaYokeDashboard.GetPokaYokeDashBoard(pokaYokeDashboard));
        }

        [HttpPost]
        [ActionName("GetDashBoardById")]
        public async Task<IActionResult> GetDashBoardById(GetDashBoardById GetDashBoardById)
        {
            return Ok(await _IpokaYokeDashboard.GetDashBoardById(GetDashBoardById));
        }
    }
}
