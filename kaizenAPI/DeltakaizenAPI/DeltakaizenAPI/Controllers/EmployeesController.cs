using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployees _Iemployees;

        public EmployeesController(IEmployees iemployees)
        {
            _Iemployees = iemployees;
        }

        [HttpPost]
        [ActionName("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees(Employees employees)
        {
            return Ok(await _Iemployees.GetAllEmployees(employees));
        }

        [HttpPost]
        [ActionName("GetAllEmployeesDropDown")]
        public async Task<IActionResult> GetAllEmployeesDropDown(Employees employees)
        {
            return Ok(await _Iemployees.GetAllEmployeesDropDown(employees));
        }

        [HttpPost]
        [ActionName("GetEmployeesById")]
        public async Task<IActionResult> GetEmployeesById(Employees employees)
        {
            return Ok(await _Iemployees.GetEmployeesById(employees));
        }

        [HttpPost]
        [ActionName("InsertEmployees")]
        public async Task<IActionResult> InsertEmployees(Employees employees)
        {
            return Ok(await _Iemployees.InsertEmployees(employees));
        }

        [HttpPost]
        [ActionName("UpdateEmployees")]
        public async Task<IActionResult> UpdateEmployees(Employees employees)
        {
            return Ok(await _Iemployees.UpdateEmployees(employees));
        }


        [HttpPost]
        [ActionName("ImportEmployee")]
        public async Task<IActionResult> ImportEmployee(EmployeeBase employees)
        {
            return Ok(await _Iemployees.ImportEmployee(employees));
        }


        [HttpPost]
        [ActionName("ExportEmployeesTemplate")]
        public async Task<IActionResult> ExportEmployeesTemplate()
        {
            return Ok(await _Iemployees.ExportEmployeesTemplate());
        }


    }
}
