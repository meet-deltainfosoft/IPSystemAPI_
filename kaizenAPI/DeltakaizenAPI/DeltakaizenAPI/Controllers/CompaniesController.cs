using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanies _iCompanies;

        public CompaniesController(ICompanies companies)
        {
            _iCompanies = companies;
        }

        [ActionName("InsertCompany")]
        [HttpPost]
        public async Task<IActionResult> InsertCompany(Companies companies)
        {
            return Ok(await _iCompanies.InsertCompany(companies));
        }

        [ActionName("GetAllCompany")]
        [HttpPost]
        public async Task<IActionResult> GetAllCompany(Companies companies)
        {
            return Ok(await _iCompanies.GetAllCompany(companies));
        }


        [ActionName("GetIdByCompany")]
        [HttpPost]
        public async Task<IActionResult> GetIdByCompany(Companies companies)
        {
            return Ok(await _iCompanies.GetIdByCompany(companies));
        }


        [ActionName("UpdateCompany")]
        [HttpPost]
        public async Task<IActionResult> UpdateCompany(Companies companies)
        {
            return Ok(await _iCompanies.UpdateCompany(companies));
        }
    }
}