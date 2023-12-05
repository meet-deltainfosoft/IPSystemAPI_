using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Companies
    {
        public Guid? CompanyId { get; set; }
        public string? Company { get; set;}
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }
        public string? GstNumber { get; set; }
        public string? CompanyCode { get; set; }
        public Guid? UserId { get; set; }
        public List<LineDetail>? lineDetails { get; set; }
    }

    public class LineDetail
    {
        public string? LineDetailId { get; set; }
        public string? CompanyId { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsDirty { get; set; }
        public bool? IsDelete { get; set; }
    }


}
