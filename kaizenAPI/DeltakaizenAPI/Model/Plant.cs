using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Plant
    {
        public Guid? PlantId { get; set; }
        public string? PlantName { get; set; }
        public Guid? UserId { get; set; }
        public string? Action { get; set; }
    }
}
