using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserRightsController : ControllerBase
    {
        private readonly IUserRights _IUserRights;

        public UserRightsController(IUserRights iuserRights)
        {
            _IUserRights = iuserRights;
        }

        [HttpPost]
        [ActionName("GetAllUserRights")]
        public async Task<IActionResult> GetAllUserRights(UserRights userRights)
        {
            return Ok(await _IUserRights.GetAllUserRights(userRights));
        }

        [HttpPost]
        [ActionName("InsertUserRights")]
        public async Task<IActionResult> InsertUserRights(UserRights userRights)
        {
            return Ok(await _IUserRights.InsertUserRights(userRights));
        }

        [HttpPost]
        [ActionName("GetAllMenu")]
        public async Task<IActionResult> GetAllMenu()
        {
            return Ok(await _IUserRights.GetAllMenu());
        }

        [HttpPost]
        [ActionName("GetAllRights")]
        public async Task<IActionResult> GetAllRights()
        {
            return Ok(await _IUserRights.GetAllRights());
        }
    }
}
