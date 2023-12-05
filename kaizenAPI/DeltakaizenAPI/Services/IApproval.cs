using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IApproval
    {
        public Task<Response> GetApprovalDropDown(Approval approval);
        public Task<Response> GetAllApprove(Approval approval);
    }
}
