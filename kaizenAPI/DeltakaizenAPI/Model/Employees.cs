using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class Employees
    {
        public Guid? EmployeId { get; set; }
        public string? SAPId { get; set; }
        public string? ShortalInitial { get; set; }
        public string? Employee { get; set; }
        public Guid? JobTitle { get; set; }
        public Guid? Department { get; set; }
        public string? DateOfJoin { get; set; }
        public Guid? UserId { get; set; }
        public string? Action { get; set; }
    }

    public class EmployeeBase
    {
        public Guid? UserId { get; set; }
        public List<EmployeeImportDetail>? employeeImportDetails { get; set; }
    }

    public class EmployeeImportDetail
    {
        public int? SrNo { get; set; }
        public int? SAPId { get; set; }
        public string? ShortalInitial { get; set; }
        public string? Employee { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
        public string? DateOfJoin { get; set; }
    }
}
