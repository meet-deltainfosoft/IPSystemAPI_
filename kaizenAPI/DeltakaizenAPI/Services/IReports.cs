using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IReports
    {
        public Task<byte[]> CreateReportFile(RDLCReport Reports);
        public Task<byte[]> TopCategoriesReportFile(RDLCReport Reports);
        public Task<byte[]> KaizenStatusReportFile(RDLCReport Reports);
        public Task<byte[]> BestKaizenReportFile(RDLCReport Reports);
        public Task<Response> GetReportsDropDown();
        public Task<Response> BestKaizen(RDLCReport objReport);
        public Task<byte[]> RenderReport2(Report objReport);
    }
}
