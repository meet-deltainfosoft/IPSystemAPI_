using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserRights
    {
        public Guid? ParentMenuId { get; set; }
        public Guid? EndUserId { get; set; }
        public Guid? UserId { get; set; }
        public List<UT_UserRights>? UT_UserRights { get; set; }
    }

    public class UT_UserRights
    {
        public Guid? MenuId { get; set; }
        public bool? AllowInsert { get; set; }
        public bool? AllowUpdate { get; set; }
        public bool? AllowDelete { get; set; }
    }
}
