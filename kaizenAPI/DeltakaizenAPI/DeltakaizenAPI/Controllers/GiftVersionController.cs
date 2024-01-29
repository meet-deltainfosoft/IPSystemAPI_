using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GiftVersionController : ControllerBase
    {
        private readonly IGiftVersion _IGiftVersion;

        public GiftVersionController(IGiftVersion iGiftVersion)
        {
            _IGiftVersion = iGiftVersion;
        }

        [ActionName("InsertGiftVersion")]
        [HttpPost]
        public async Task<IActionResult> InsertGiftVersion([FromForm] GiftVersion giftVersion)
        {
            return Ok(await _IGiftVersion.InsertGiftVersion(giftVersion));
        }


        [ActionName("UpdateGiftVersion")]
        [HttpPost]
        public async Task<IActionResult> UpdateGiftVersion([FromForm] GiftVersion giftVersion)
        {
            return Ok(await _IGiftVersion.UpdateGiftVersion(giftVersion));
        }


        [ActionName("GetAllGiftVersion")]
        [HttpGet]
        public async Task<IActionResult> GetAllGiftVersion()
        {
            return Ok(await _IGiftVersion.GetAllGiftVersion());
        }

        [ActionName("GetGiftVersionById")]
        [HttpPost]
        public async Task<IActionResult> GetGiftVersionById(GiftVersion giftVersion)
        {
            return Ok(await _IGiftVersion.GetGiftVersionById(giftVersion));
        }

        [HttpGet]
        [ActionName("DownloadGiftVersionPDF")]
        public async Task<IActionResult> DownloadGiftVersionPDF(string GiftVersionPath)
        {
            var stream = await _IGiftVersion.DownloadGiftVersionPDF(GiftVersionPath);
            return File(stream, "application/pdf");
        }

    }
}
