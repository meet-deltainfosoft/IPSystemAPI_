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
}
