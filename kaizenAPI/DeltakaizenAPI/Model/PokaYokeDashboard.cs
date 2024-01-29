using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class PokaYokeDashboard
    {
        public string? Type { get; set; }
    }

    public class GetDashBoardById {
        public Guid? ProductId { get; set; }
        public string? PumpSerialNumber { get; set; }
    }

    public class DashBoard2
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? WorkOrder { get; set; }
        public string? PumpDescription { get; set; }
        public string? PumpDUTID { get; set; }
        public string? MotorDUTID { get; set; }
        public string? Type { get; set; }
    }
}
