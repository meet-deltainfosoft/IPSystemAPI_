using DataHelper;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReportRepo : IReports
    {
        public Task<Response> BestKaizen(RDLCReport objReport)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> BestKaizenReportFile(RDLCReport Reports)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> CreateReportFile(RDLCReport Reports)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetReportsDropDown()
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> KaizenStatusReportFile(RDLCReport Reports)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> RenderReport2(Report objReport)
        {
            try
            {
                var SSRS_Rest_API_URL = DbHelper.get_configuration("SSRS_Rest_API_URL");
                SSRS_Rest_API_URL = SSRS_Rest_API_URL + objReport.report_path
                    + "&rs:Format=" + objReport.report_export_format;
                for (int i = 0; i < objReport.report_parameters.Count; i++)
                {
                    SSRS_Rest_API_URL += string.Format("&{0}={1}", objReport.report_parameters.Keys.ElementAt(i),
                        objReport.report_parameters[objReport.report_parameters.Keys.ElementAt(i)]);
                }
                WebClient Client = new WebClient();
                Client.UseDefaultCredentials = true;
                Client.Credentials = new NetworkCredential
                (DbHelper.get_configuration("SSRS_Username"),
                DbHelper.get_configuration("SSRS_Password"),
                DbHelper.get_configuration("SSRS_Domain"));

                return Client.DownloadData(SSRS_Rest_API_URL);
            }
            catch (Exception ex)
            {
                
                throw ex.GetBaseException();
            }
        }

        public Task<byte[]> TopCategoriesReportFile(RDLCReport Reports)
        {
            throw new NotImplementedException();
        }
    }
}
