using Dapper;
using DataHelper;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthenticationsRepo : ConnectionBase, IAuthentications
    {
        public AuthenticationsRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<Response> UserAuthentication(Authentications authentications)
        {
            try
            {

                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserName", authentications.UserName);
                    dynamicParameters.Add("@Password", authentications.Password);
                    dynamicParameters.Add("@Action", "UserAuthentication");

                    var result = await dbConnection.QueryMultipleAsync("Kaizen_Master_Authentication", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    //var response = result.Read<Response>();
                    var resultSet = result.Read<Response>().FirstOrDefault();
                    if (resultSet.IsSuccessful == true)
                    {
                        var data = result.Read();
                        return new Response() { IsSuccessful = true, Message = "Successful", Data = data };
                    }
                    else
                    {
                        return new Response() { IsSuccessful = false, Message = resultSet.Message, Data = null };
                    }
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }


    }
}
