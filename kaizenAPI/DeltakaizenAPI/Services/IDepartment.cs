using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDepartment
    {
        public Task<Response> InsertDepartment(Department department);
        public Task<Response> UpdateDepartment(Department department);
        public Task<Response> GetAllDepartment(Department department);
        public Task<Response> GetDepartmentById(Department department);
        public Task<Response> GetDepartmentDropDown(Department department);
    }
}
