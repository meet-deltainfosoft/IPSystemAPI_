using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Redeem
    {
        public Guid? RedeemId { get; set; }
        public Guid? EmployeeId { get; set; } 
        public string? Date { get; set; }
        public int? Points { get; set; }
        public Guid? Remarks { get; set; }
        public Guid? UserId { get; set; } 
    }

    public class GetProductsFromPoints
    {
        public Int32?  Point { get; set; }
    }
}
