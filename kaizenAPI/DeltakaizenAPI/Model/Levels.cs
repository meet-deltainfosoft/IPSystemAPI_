using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Levels
    {
        public Guid? LevelsId { get; set; }
        public string? Level { get; set; }
        public int? Marks { get; set; }
        public Guid? UserId { get; set; }
        public string? Action { get; set; }
    }

    public class DeleteLevels
    {
        public Guid? LevelsId { get; set; }
    }
}
