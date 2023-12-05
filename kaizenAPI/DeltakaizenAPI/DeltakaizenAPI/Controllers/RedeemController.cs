using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RedeemController : ControllerBase
    {
        private readonly IRedeem _Iredeem;
        public RedeemController(IRedeem redeem)
        {
            _Iredeem = redeem;
        }


        [HttpPost]
        [ActionName("GetProductsFromPoints")]
        public async Task<IActionResult> GetProductsFromPoints(GetProductsFromPoints GetProductsFromPoints)
        {
            return Ok(await _Iredeem.GetProductsFromPoints(GetProductsFromPoints));
        }

        [HttpPost]
        [ActionName("InsertRedeem")]
        public async Task<IActionResult> InsertRedeem(Redeem redeem)
        {
            return Ok(await _Iredeem.InsertRedeem(redeem));
        }

        [HttpPost]
        [ActionName("UpdateRedeem")]
        public async Task<IActionResult> UpdateRedeem(Redeem redeem)
        {
            return Ok(await _Iredeem.UpdateRedeem(redeem));
        }

        [HttpGet]
        [ActionName("GetRedeemById")]
        public async Task<IActionResult> GetRedeemById(Guid? RedeemId)
        {
            return Ok(await _Iredeem.GetRedeemById(RedeemId));
        }

        [HttpGet]
        [ActionName("GetRedeemDropDown")]
        public async Task<IActionResult> GetRedeemDropDown()
        {
            return Ok(await _Iredeem.GetRedeemDropDown());
        }

        [HttpGet]
        [ActionName("GetRedeem")]
        public async Task<IActionResult> GetRedeem()
        {
            return Ok(await _Iredeem.GetRedeem());
        }


    }
}
