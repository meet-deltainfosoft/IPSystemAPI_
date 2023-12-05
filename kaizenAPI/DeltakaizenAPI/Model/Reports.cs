using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RDLCReport
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public Guid? PlantId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? UserId { get; set; }
        public string? path { get; set; }
    }

    public class Report
    {
        public string? report_path { get; set; }
        public string? report_export_format { get; set; }
        public string? report_content_type { get; set; }
        public IDictionary<string, object>? report_parameters { get; set; }
    }
}
