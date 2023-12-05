using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Approval
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? PlantIds { get; set; }
        public Guid? UserIds { get; set; }
        public Guid? StatusId { get; set; }
        public Guid? KaizenIds { get; set; }
        public Guid? Action { get; set; }
    }
}
