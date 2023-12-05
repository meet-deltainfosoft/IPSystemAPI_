using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly IApproval _Iapproval;

        public ApprovalController(IApproval approval)
        {
            _Iapproval = approval;
        }

        [HttpPost]
        [ActionName("GetApprovalDropDown")]
        public async Task<IActionResult> GetApprovalDropDown(Approval approval)
        {
            return Ok(await _Iapproval.GetApprovalDropDown(approval));
        }

        [HttpPost]
        [ActionName("GetAllApprove")]
        public async Task<IActionResult> GetAllApprove(Approval approval)
        {
            return Ok(await _Iapproval.GetAllApprove(approval));
        }
    }
}
