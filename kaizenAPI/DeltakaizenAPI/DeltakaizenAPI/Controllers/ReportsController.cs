using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReports _IReports;

        public ReportsController(IReports iReports)
        {
            _IReports = iReports;
        }

        [HttpPost]
        [ActionName("ExportData")]
        public async Task<ActionResult> ExportData(RDLCReport reports)
        {
            var byteRes = new byte[] { };
            //string path = _IhostingEnvironment.ContentRootPath+ "\\Reports\\Report.rdlc";
            byteRes = await _IReports.CreateReportFile(reports);
            return File(byteRes, "application/pdf", "ReportName.pdf");
            //return File(byteRes, System.Net.Mime.MediaTypeNames.Application.Octet, "ReportName.pdf");
        }

        [HttpPost]
        [ActionName("TopCategoriesReportFile")]
        public async Task<ActionResult> TopCategories(RDLCReport reports)
        {
            var byteRes = new byte[] { };
            byteRes = await _IReports.TopCategoriesReportFile(reports);
            return File(byteRes, "application/pdf", "ReportName.pdf");
        }

        [HttpGet]
        [ActionName("GetReportsDropDown")]
        public async Task<IActionResult> GetReportsDropDown()
        {
            return Ok(await _IReports.GetReportsDropDown());
        }

        [HttpPost]
        [ActionName("KaizenStatusReportFile")]
        public async Task<IActionResult> KaizenStatusReportFile(RDLCReport reports)
        {
            var byteRes = new byte[] { };
            byteRes = await _IReports.KaizenStatusReportFile(reports);
            return File(byteRes, "application/pdf", "ReportName.pdf");
        }

        [HttpPost]
        [ActionName("BestKaizenReportFile")]
        public async Task<IActionResult> BestKaizenReportFile(RDLCReport reports)
        {
            var byteRes = new byte[] { };
            byteRes = await _IReports.BestKaizenReportFile(reports);
            return File(byteRes, "application/pdf", "ReportName.pdf");
        }


        [HttpPost]
        [ActionName("BestKaizen")]    
        public async Task<IActionResult> BestKaizen(RDLCReport reports){
            return Ok(await _IReports.BestKaizen(reports));
        }

        [HttpPost]
        //[Route("api/{controller}/{action}")]
        [ActionName("getReportUrl")]
        public async Task<IActionResult> get_report(Report objReport)
        {
            try
            {
                byte[] reportContent = await _IReports.RenderReport2(objReport);

                Stream stream = new MemoryStream(reportContent);
                return new FileStreamResult(stream, objReport.report_content_type);
            }
            catch (Exception ex)
            {
                
                throw ex.GetBaseException();
            }
        }

    }
}
