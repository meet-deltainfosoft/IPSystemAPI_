using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartment _iDepartment;

        public DepartmentsController(IDepartment department)
        {
            _iDepartment = department;
        }

        [ActionName("InsertDepartment")]
        [HttpPost]
        public async Task<IActionResult> InsertDepartment(Department department)
        {
            return Ok(await _iDepartment.InsertDepartment(department));
        }

        [ActionName("UpdateDepartment")]
        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            return Ok(await _iDepartment.UpdateDepartment(department));
        }


        [ActionName("GetAllDepartment")]
        [HttpPost]
        public async Task<IActionResult> GetAllDepartment(Department department)
        {
            return Ok(await _iDepartment.GetAllDepartment(department));
        }

        [ActionName("GetDepartmentById")]
        [HttpPost]
        public async Task<IActionResult> GetDepartmentById(Department department)
        {
            return Ok(await _iDepartment.GetDepartmentById(department));
        }

        [ActionName("GetDepartmentDropDown")]
        [HttpPost]
        public async Task<IActionResult> GetDepartmentDropDown(Department department)
        {
            return Ok(await _iDepartment.GetDepartmentDropDown(department));
        }
    }
}
