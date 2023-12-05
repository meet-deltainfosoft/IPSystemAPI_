using Dapper;
using DapperParameters;
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
    public class UserRightsRepo : ConnectionBase, IUserRights
    {
        public UserRightsRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<Response> GetAllMenu()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetAllMenu");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_User_Rights", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex) {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetAllRights()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetAllRights");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_User_Rights", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetAllUserRights(UserRights userRights)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@ParentMenuId ", userRights.ParentMenuId);
                    dynamicParameters.Add("@Action ", "GetAllUserRights");
                    dynamicParameters.Add("@EndUserId ", userRights.EndUserId);
                    dynamicParameters.Add("@UserId ", userRights.UserId);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_User_Rights", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> InsertUserRights(UserRights userRights)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsertUserRights");
                    dynamicParameters.Add("@EndUserId", userRights.EndUserId);
                    dynamicParameters.Add("@UserId", userRights.UserId);
                    dynamicParameters.AddTable("@UT_UserRights", "UT_UserRights", userRights.UT_UserRights);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_User_Rights", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "The rights have been saved.", Data = null };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }


    }
}
