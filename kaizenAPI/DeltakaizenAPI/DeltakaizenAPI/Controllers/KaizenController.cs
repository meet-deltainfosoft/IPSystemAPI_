using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class KaizenController : ControllerBase
    {
        private readonly IKaizen _Ikaizen;

        public KaizenController(IKaizen ikaizen)
        {
            _Ikaizen = ikaizen;
        }
        
        
        [HttpGet]
        [ActionName("GetAllKaizenDropDown")]
        public async Task<IActionResult> GetAllKaizenDropDown(Guid? AuthorId)
        {
            return Ok(await _Ikaizen.GetAllKaizenDropDown(AuthorId));
        }

        [HttpPost]
        [ActionName("UpdateKaizen")]
        public async Task<IActionResult> UpdateKaizen(Kaizen kaizen)
        {
            return Ok(await _Ikaizen.UpdateKaizen(kaizen));
        }

        [HttpPost]
        [ActionName("InsertKaizen")]
        public async Task<IActionResult> InsertKaizen(Kaizen kaizen)
        {
            return Ok(await _Ikaizen.InsertKaizen(kaizen));
        }

        [HttpGet]
        [ActionName("GetAllKaizen")]
        public async Task<IActionResult> GetAllKaizen()
        {
            return Ok(await _Ikaizen.GetAllKaizen());
        }


        [HttpGet]
        [ActionName("ExportKaizenTemplate")]
        public async Task<IActionResult> ExportKaizenTemplate()
        {
            return Ok(await _Ikaizen.ExportKaizenTemplate());
        }

        [HttpGet]
        [ActionName("GetKaizenById")]
        public async Task<IActionResult> GetKaizenById(Guid? KaizenId)
        {
            return Ok(await _Ikaizen.GetKaizenById(KaizenId));
        }

        [HttpPost]
        [ActionName("ImportKaizen")]
        public async Task<IActionResult> ImportKaizen(BaseKaizen kaizen)
        {
            return Ok(await _Ikaizen.ImportKaizen(kaizen));
        }

        [HttpPost]
        //[Consumes("multipart/form-data")]
        [ActionName("ImportGiftPDF")]
        public async Task<IActionResult> ImportGiftPDF([FromForm]Guid UserId ,IFormFile formFile)
        {
            return Ok(await _Ikaizen.ImportGiftPDF(UserId,formFile));
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [ActionName("ImportGiftPDF2")]
        public async Task<IActionResult> ImportGiftPDF2([FromForm] GiftPDFs giftPDFs)
        {
            return Ok(await _Ikaizen.ImportGiftPDF2(giftPDFs));
        }
    }
}
