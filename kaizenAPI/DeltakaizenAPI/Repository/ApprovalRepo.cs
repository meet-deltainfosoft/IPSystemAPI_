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
    public class ApprovalRepo : ConnectionBase, IApproval
    {
        public ApprovalRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<Response> GetAllApprove(Approval approval)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@FromDate", approval.FromDate);
                    dynamicParameters.Add("@ToDate", approval.ToDate);
                    dynamicParameters.Add("@KaizenIds", approval.KaizenIds);
                    dynamicParameters.Add("@PlantIds", approval.PlantIds);
                    dynamicParameters.Add("@StatusId", approval.StatusId);
                    dynamicParameters.Add("@Action", "GetAllApprove");
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_Approval", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetApprovalDropDown(Approval approval)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserId", approval.UserIds);
                    dynamicParameters.Add("@Action", "GetApprovalDropDown");

                    var cmd = new CommandDefinition("Kaizen_Transaction_Approval", dynamicParameters, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache);
                    using (var reader = await dbConnection.QueryMultipleAsync(cmd))
                    {
                        var Plants = await reader.ReadAsync();
                        var Kiazens = await reader.ReadAsync();
                        var Status = await reader.ReadAsync();

                        return new Response() { IsSuccessful = true, Message = "Successful", Data = new { Plants = Plants, kaiznes = Kiazens, Status = Status } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
    }
}
