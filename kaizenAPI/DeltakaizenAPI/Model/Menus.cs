using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Menus
    {
        
        public class ParentMenus
        {
            public Guid? ParentId { get; set; }
            public string? Description { get; set; }
            public string? Icon { get; set; }
        }

        public class ChildMenus
        {
            public Guid? ChildId { get; set; }
            public string? ChildDescription { get; set; }
            public string? Parent { get; set; }
            public string? Icon { get; set; }
            public string? Routing { get; set; }
            public bool? AllowInsert { get; set; }
            public bool? AllowUpdate { get; set; }
            public bool? AllowDelete { get; set; }
        }

        public class RequestParameters
        {
            public Guid? UserId { get; set; }
            public Guid? Action { get; set; }
        }
    }
}
