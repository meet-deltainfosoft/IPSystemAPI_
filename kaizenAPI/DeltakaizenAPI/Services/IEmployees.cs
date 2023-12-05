using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployees
    {
        public Task<Response> InsertEmployees(Employees employees);
        public Task<Response> UpdateEmployees(Employees employees);
        public Task<Response> GetAllEmployees(Employees employees);
        public Task<Response> GetAllEmployeesDropDown(Employees employees);
        public Task<Response> GetEmployeesById(Employees employees);
        public Task<Response> ImportEmployee(EmployeeBase employees);
        public Task<Response> ExportEmployeesTemplate();
    }
}
