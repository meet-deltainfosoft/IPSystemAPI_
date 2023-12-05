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
    public class UsersRepo : ConnectionBase, IUsers
    {
        public UsersRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<Response> GetAllUser()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetAllUser");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Users", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {

                return new Response() { IsSuccessful = false, Message = ex.Message.ToString(), Data = null };
            }
        }
        public async Task<Response> GetUserById(Users users)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserId", users.UserId);
                    dynamicParameters.Add("@Action", "GetUserById");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Users", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = ex.Message.ToString(), Data = null };
            }
        }
        public async Task<Response> InsertUsers(Users users)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserId", users.UserId);
                    dynamicParameters.Add("@FirstName", users.FirstName);
                    dynamicParameters.Add("@LastName", users.LastName);
                    dynamicParameters.Add("@UserName", users.UserName);
                    dynamicParameters.Add("@Password", users.Password);
                    dynamicParameters.Add("@IsAdmin", users.IsAdmin);
                    dynamicParameters.Add("@IsDisabled", users.IsDisabled);
                    dynamicParameters.Add("@CUSerId", users.CUSerId);
                    dynamicParameters.Add("@Action", "InsertUsers");
                    var result = await dbConnection.QueryAsync<Response>("Kaizen_Master_Users", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var response = result.FirstOrDefault();
                  
                    return new Response() { IsSuccessful = response.IsSuccessful, Message = response.Message, Data =null };
                }
            }
            catch (Exception ex)
            {

                return new Response() { IsSuccessful = false, Message = ex.Message.ToString(), Data = null };
            }
        }
        public async Task<Response> UpdateUsers(Users users)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserId", users.UserId);
                    dynamicParameters.Add("@FirstName", users.FirstName);
                    dynamicParameters.Add("@LastName", users.LastName);
                    dynamicParameters.Add("@UserName", users.UserName);
                    dynamicParameters.Add("@Password", users.Password);
                    dynamicParameters.Add("@IsAdmin", users.IsAdmin);
                    dynamicParameters.Add("@IsDisabled", users.IsDisabled);
                    dynamicParameters.Add("@CUSerId", users.CUSerId);
                    dynamicParameters.Add("@Action", "UpdateUsers");
                    var result = await dbConnection.QueryAsync<Response>("Kaizen_Master_Users", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var response = result.FirstOrDefault();

                    return new Response() { IsSuccessful = response.IsSuccessful, Message = response.Message, Data = null};
                }
            }
            catch (Exception ex)
            {

                return new Response() { IsSuccessful = false, Message = ex.Message.ToString(), Data = null };
            }
        }
    }
}
