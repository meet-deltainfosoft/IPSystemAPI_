using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DashBoard
    {
        public Guid? PlantId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }

    public class GetLeaderBoardDetail {
        public Guid? PlantId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }

    }
}
