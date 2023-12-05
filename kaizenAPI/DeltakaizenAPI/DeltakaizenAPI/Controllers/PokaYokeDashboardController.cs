using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [ActionName("GetPokaYokeDashBoard")]
        public async Task<IActionResult> GetPokaYokeDashBoard()
        {
            return Ok(await _IpokaYokeDashboard.GetPokaYokeDashBoard());
        }
    }
}
