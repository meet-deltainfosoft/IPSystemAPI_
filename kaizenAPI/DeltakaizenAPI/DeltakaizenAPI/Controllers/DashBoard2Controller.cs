using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DashBoard2Controller : ControllerBase
    {
        private readonly IDashBoard2 _IdashBoard2;

        public DashBoard2Controller(IDashBoard2 dashBoard2)
        {
              _IdashBoard2 = dashBoard2;
        }

        [HttpPost]
        [ActionName("GetDashBoardData")]
        public async Task<IActionResult> GetDashBoardData(DashBoard dashBoard2)
        {
            return Ok(await _IdashBoard2.GetDashBoardData(dashBoard2));
        }


        [HttpGet]
        [ActionName("GetDashBoardDropdDown")]
        public async Task<IActionResult> GetDashBoGetDashBoardDropdDownardData()
        {
            return Ok(await _IdashBoard2.GetDashBoardDropdDown());
        }

        [HttpGet]
        [ActionName("DownloadGiftPDF")]
        public async Task<IActionResult> DownloadGiftPDF()
        {
            var stream = await _IdashBoard2.DownloadGiftPDF();
            return File(stream, "application/pdf");
            //return Ok(await _IdashBoard2.DownloadGiftPDF());
        }

        [HttpPost]
        [ActionName("GetLeaderBoardDetail")]
        public async Task<IActionResult> GetLeaderBoardDetail(GetLeaderBoardDetail getLeaderBoardDetail)
        {
            return Ok(await _IdashBoard2.GetLeaderBoardDetail(getLeaderBoardDetail));
        }
    }
}
