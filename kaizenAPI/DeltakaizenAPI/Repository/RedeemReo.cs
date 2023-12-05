using Dapper;
using DataHelper;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RedeemReo : ConnectionBase, IRedeem
    {
        public RedeemReo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<Response> GetProductsFromPoints(GetProductsFromPoints getProductsFromPoints)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetProductsFromPoints");
                    dynamicParameters.Add("@Points", getProductsFromPoints.Point);
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_Redeem", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
            }
        }
        public async Task<Response> GetRedeem()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetRedeem");
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_Redeem", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
            }
        }
        public async Task<Response> GetRedeemById(Guid? RedeemId)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetRedeemById");
                    dynamicParameters.Add("@RedeemId", RedeemId);
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_Redeem", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
            }
        }
        public async Task<Response> GetRedeemDropDown()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetRedeemDropDown");
                    //var result = await dbConnection.QueryMultipleAsync("Kaizen_Transaction_Redeem", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    //var Employee = result.Read();
                    using (var multiResult = await dbConnection.QueryMultipleAsync("Kaizen_Transaction_Redeem", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        var Employee = await multiResult.ReadAsync();
                        var Point = await multiResult.ReadAsync();
                        var RedeemStatus = await multiResult.ReadAsync();

                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = new
                            {
                                Employee = Employee,
                                Point = Point,
                                RedeemStatus = RedeemStatus
                            }
                        };
                    }

                    // return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
            }
        }
        public async Task<Response> InsertRedeem(Redeem redeem)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsertRedeem");
                    dynamicParameters.Add("@EmployeeId", redeem.EmployeeId);
                    dynamicParameters.Add("@Date", redeem.Date);
                    dynamicParameters.Add("@Points", redeem.Points);
                    dynamicParameters.Add("@Remarks", redeem.Remarks);
                    dynamicParameters.Add("@UserId", redeem.UserId);
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_Redeem", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
            }
        }
        public async Task<Response> UpdateRedeem(Redeem redeem)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "UpdateRedeem");
                    dynamicParameters.Add("@RedeemId", redeem.RedeemId);
                    dynamicParameters.Add("@EmployeeId", redeem.EmployeeId);
                    dynamicParameters.Add("@Date", redeem.Date);
                    dynamicParameters.Add("@Points", redeem.Points);
                    dynamicParameters.Add("@Remarks", redeem.Remarks);
                    dynamicParameters.Add("@UserId", redeem.UserId);
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_Redeem", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
            }
        }
    }
}
