using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPokaYokeDashboard
    {
        public Task<Response> GetPokaYokeDashBoard(PokaYokeDashboard pokaYokeDashboard);
        public Task<Response> GetDashBoardById(GetDashBoardById GetDashBoardById);
    }
}
