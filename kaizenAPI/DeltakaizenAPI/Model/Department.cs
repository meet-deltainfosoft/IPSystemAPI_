using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Department
    {
        public Guid? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public Guid? PlantId { get; set; }
        public Guid? UserId { get; set; }
        public string? Action { get; set; }
    }
}
