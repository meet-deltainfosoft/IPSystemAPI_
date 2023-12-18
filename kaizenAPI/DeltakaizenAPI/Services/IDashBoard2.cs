using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDashBoard2
    {
        public Task<Response> GetDashBoardData(DashBoard dashBoard2);
        public Task<Response> GetDashBoardDropdDown();
        public Task<Stream> DownloadGiftPDF();
        public Task<Response> GetLeaderBoardDetail(GetLeaderBoardDetail getLeaderBoardDetail);

    }
}