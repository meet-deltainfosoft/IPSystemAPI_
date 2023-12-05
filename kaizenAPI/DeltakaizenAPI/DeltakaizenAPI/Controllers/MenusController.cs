using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenus _iMenus;

        public MenusController(IMenus menus)
        {
            _iMenus = menus;
        }

        [ActionName("GetAllMenu")]
        [HttpPost]
        public async Task<IActionResult> GetAllMenu(Menus.RequestParameters requestParameters)
        {
            return Ok(await _iMenus.GetAllMenu(requestParameters));
        }
    }
}
