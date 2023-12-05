using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IAuthentications _IAuthentications;
        public UserAuthenticationController(IAuthentications Iauthentications)
        {
                _IAuthentications = Iauthentications;
        }

        [ActionName("UserAuthentication")]
        [HttpPost]
        public async Task<IActionResult> UserAuthentication(Authentications authentications)
        {
            return Ok(await _IAuthentications.UserAuthentication(authentications));
        }
    }
}
