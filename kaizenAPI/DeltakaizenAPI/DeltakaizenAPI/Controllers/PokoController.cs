using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PokoController : ControllerBase
    {
        private readonly IPokoYoko _IpokoYoko;
        public PokoController(IPokoYoko pokoYoko)
        {
            _IpokoYoko = pokoYoko;
        }


        [HttpGet]
        [ActionName("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _IpokoYoko.GetAllProducts());
        }


        [HttpPost]
        [ActionName("GetProductById")]
        public async Task<IActionResult> GetProductById(PokoYoko pokoYoko)
        {
            return Ok(await _IpokoYoko.GetProductById(pokoYoko));
        }

        [HttpPost]
        [ActionName("DeleteByProductId")]
        public async Task<IActionResult> DeleteByProductId(PokoYoko pokoYoko)
        {
            return Ok(await _IpokoYoko.DeleteByProductId(pokoYoko));
        }

    }
}
