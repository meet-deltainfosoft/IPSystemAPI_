using DataHelper;
//using Microsoft.Reporting.WebForms;
//using Microsoft.ReportingServices.Interfaces;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using Dapper;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;
using System.Net;

namespace Repository
{
    public class ReportsRepo : ConnectionBase, IReports
    {
        public ReportsRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }


        public async Task<Response> BestKaizen(RDLCReport objReport)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@FromDate", objReport.FromDate);
                    dynamicParameters.Add("@ToDate", objReport.ToDate);
                    dynamicParameters.Add("@PlantId", objReport.PlantId);
                    dynamicParameters.Add("@CompanyId", objReport.CompanyId);
                    dynamicParameters.Add("@UserId", objReport.UserId);
                    dynamicParameters.Add("@Action", "BestKaizen");
                    var results = await dbConnection.QueryAsync("Kaizen_Reports_Approval_Status", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = results };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Data = null, IsSuccessful = false, Message = ex.Message.ToString() };
            }
        }

        public async Task<byte[]> BestKaizenReportFile(RDLCReport objReport)
        {
            try
            {
                
                using (var dbConnection = GetDbConnection())
                {
                    string reportpath = Path.Combine(Directory.GetCurrentDirectory(), "Reports\\BestKaizenReport.rdlc"); ;
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@FromDate", objReport.FromDate);
                    dynamicParameters.Add("@ToDate", objReport.ToDate);
                    dynamicParameters.Add("@PlantId", objReport.PlantId);
                    dynamicParameters.Add("@CompanyId", objReport.CompanyId);
                    dynamicParameters.Add("@UserId", objReport.UserId);
                    dynamicParameters.Add("@Action", "BestKaizen");
                    var results = await dbConnection.QueryAsync("Kaizen_Reports_Approval_Status", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    AspNetCore.Reporting.LocalReport report = new AspNetCore.Reporting.LocalReport(reportpath);

                    report.AddDataSource("BestKaizen", results.ToList());
                    var result = report.Execute(RenderType.Pdf, 1);
                    return result.MainStream;
                }
            }
            catch (Exception ex)
            {
                using (var dbConnection = GetDbConnection())
                {
                    string insertErrorQuery = "INSERT INTO BackEndError (ErrorMessage) " +
                                 "VALUES (@ErrorMessage)";
                    var errorParameters = new DynamicParameters();
                    errorParameters.Add("@ErrorMessage", ex.Message);
                    dbConnection.Execute(insertErrorQuery, errorParameters);
                }
                throw;
            }
        }

        public async Task<byte[]> CreateReportFile(RDLCReport objReport)
        {
            try
            {
                string reportpath = Path.Combine(Directory.GetCurrentDirectory(), "Reports\\Report.rdlc"); ;
                using (var dbConnection = GetDbConnection())
                {
                    
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@FromDate", objReport.FromDate);
                    dynamicParameters.Add("@ToDate", objReport.ToDate);
                    dynamicParameters.Add("@PlantId", objReport.PlantId);
                    dynamicParameters.Add("@CompanyId", objReport.CompanyId);
                    dynamicParameters.Add("@UserId", objReport.UserId);
                    dynamicParameters.Add("@Action", "TopPerformer");
                    var results = await dbConnection.QueryAsync("Kaizen_Reports_Approval_Status", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    AspNetCore.Reporting.LocalReport report = new AspNetCore.Reporting.LocalReport(reportpath);
                   
                    report.AddDataSource("TopPeformerS", results.ToList());
                    var result = report.Execute(RenderType.Pdf, 1);
                    return result.MainStream;
                }
            }
            catch (Exception ex)
            {
                using (var dbConnection = GetDbConnection())
                {
                    string insertErrorQuery = "INSERT INTO BackEndError (ErrorMessage) " +
                                 "VALUES (@ErrorMessage)";
                    var errorParameters = new DynamicParameters();
                    errorParameters.Add("@ErrorMessage", ex.Message);
                    dbConnection.Execute(insertErrorQuery, errorParameters);
                }
                throw;
            }
        }

        public async Task<Response> GetReportsDropDown()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetReportsDropDown");
                    var results = await dbConnection.QueryAsync("Kaizen_Reports_Approval_Status", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful",IsSuccessful = true ,Data = results};
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<byte[]> KaizenStatusReportFile(RDLCReport objReport)
        {
            try
            {
                string reportpath = Path.Combine(Directory.GetCurrentDirectory(), "Reports\\kaizenStatus.rdlc"); ;
                using (var dbConnection = GetDbConnection())
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@FromDate", objReport.FromDate);
                    dynamicParameters.Add("@ToDate", objReport.ToDate);
                    dynamicParameters.Add("@PlantId", objReport.PlantId);
                    dynamicParameters.Add("@CompanyId", objReport.CompanyId);
                    dynamicParameters.Add("@UserId", objReport.UserId);
                    dynamicParameters.Add("@Action", "KaizenStatus");
                    var results = await dbConnection.QueryAsync("Kaizen_Reports_Approval_Status", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    AspNetCore.Reporting.LocalReport report = new AspNetCore.Reporting.LocalReport(reportpath);

                    report.AddDataSource("KaizenStatus2", results.ToList());
                    var result = report.Execute(RenderType.Pdf, 1);
                    return result.MainStream;
                }
            }
            catch (Exception ex)
            {
                using (var dbConnection = GetDbConnection())
                {
                    string insertErrorQuery = "INSERT INTO BackEndError (ErrorMessage) " +
                                 "VALUES (@ErrorMessage)";
                    var errorParameters = new DynamicParameters();
                    errorParameters.Add("@ErrorMessage", ex.Message);
                    dbConnection.Execute(insertErrorQuery, errorParameters);
                }
                throw;
            }
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
                DbHelper.get_configuration("SSRS_Password"));


                return Client.DownloadData(SSRS_Rest_API_URL);
            }
            catch (Exception ex)
            {

                throw ex.GetBaseException();
            }
        }

        public async Task<byte[]> TopCategoriesReportFile(RDLCReport objReport)
        {
            try
            {
                string reportpath = Path.Combine(Directory.GetCurrentDirectory(), "Reports\\TopCategory.rdlc"); ;
                using (var dbConnection = GetDbConnection())
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@FromDate", objReport.FromDate);
                    dynamicParameters.Add("@ToDate", objReport.ToDate);
                    dynamicParameters.Add("@PlantId", objReport.PlantId);
                    dynamicParameters.Add("@CompanyId", objReport.CompanyId);
                    dynamicParameters.Add("@UserId", objReport.UserId);
                    dynamicParameters.Add("@Action", "TopCategories");
                    var results = await dbConnection.QueryAsync("Kaizen_Reports_Approval_Status", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    AspNetCore.Reporting.LocalReport report = new AspNetCore.Reporting.LocalReport(reportpath);

                    report.AddDataSource("TopCategorys", results.ToList());
                    var result = report.Execute(RenderType.Pdf, 1);
                    return result.MainStream;
                }
            }
            catch (Exception ex)
            {
                using (var dbConnection = GetDbConnection())
                {
                    string insertErrorQuery = "INSERT INTO BackEndError (ErrorMessage) " +
                                 "VALUES (@ErrorMessage)";
                    var errorParameters = new DynamicParameters();
                    errorParameters.Add("@ErrorMessage", ex.Message);
                    dbConnection.Execute(insertErrorQuery, errorParameters);
                }
                throw;
            }
        }
    }
}
