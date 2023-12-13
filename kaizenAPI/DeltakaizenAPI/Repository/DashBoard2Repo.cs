using Dapper;
using DataHelper;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DashBoard2Repo : ConnectionBase, IDashBoard2
    {
        public DashBoard2Repo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<Stream> DownloadGiftPDF()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "DownloadGiftPDF");
                    string filePath = await dbConnection.QuerySingleAsync<string>("Kaizen_DashBoard", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    //return new Response() { IsSuccessful = true, Message = "Successful", Data = result };   
                }
            }
            catch (Exception)
            {
                throw;
                //return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetDashBoardData(DashBoard dashBoard2)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@FromDate", dashBoard2.FromDate);
                    dynamicParameters.Add("@ToDate", dashBoard2.ToDate);
                    dynamicParameters.Add("@PlantId", dashBoard2.PlantId);
                    dynamicParameters.Add("@Action", "GetDashBoardData");
                    var cmd = new CommandDefinition("Kaizen_DashBoard", dynamicParameters, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache);
                    using (var reader = await dbConnection.QueryMultipleAsync(cmd))
                    {
                        var IpSummary = await reader.ReadAsync();
                        var HighestPoints = await reader.ReadAsync();
                        var Performer = await reader.ReadAsync();
                        var IPsPointsYearlyTrend = await reader.ReadAsync();
                        var CostSavingTrend = await reader.ReadAsync();
                        return new Response() { IsSuccessful = true, Message = "", Data = new { IpSummary = IpSummary, HighestPoints = HighestPoints, Performer = Performer, IPsPointsYearlyTrend = IPsPointsYearlyTrend, CostSavingTrend = CostSavingTrend } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetDashBoardDropdDown()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetDashBoardDropdDown");
                    var result = await dbConnection.QueryAsync("Kaizen_DashBoard", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };

                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }



        }
    }
}
