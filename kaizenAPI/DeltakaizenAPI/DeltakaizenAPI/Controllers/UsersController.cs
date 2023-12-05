using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _IUsers;

        public UsersController(IUsers IUsers)
        {
                _IUsers = IUsers;
        }

        [HttpPost]
        [ActionName("InsertUsers")]
        public async Task<IActionResult> InsertUsers(Users users) {
            return Ok(await _IUsers.InsertUsers(users));
        }



        [HttpPost]
        [ActionName("UpdateUsers")]
        public async Task<IActionResult> UpdateUsers(Users users)
        {
            return Ok(await _IUsers.UpdateUsers(users));
        }

        [HttpPost]
        [ActionName("GetUserById")]
        public async Task<IActionResult> GetUserById(Users users)
        {
            return Ok(await _IUsers.GetUserById(users));
        }


        [HttpGet]
        [ActionName("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _IUsers.GetAllUser());
        }

    }
}
