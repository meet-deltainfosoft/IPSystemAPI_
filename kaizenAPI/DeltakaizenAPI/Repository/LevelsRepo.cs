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
    public class LevelsRepo : ConnectionBase, ILevels
    {
        public LevelsRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<Response> DeleteLevels(DeleteLevels deleteLevels)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "DeleteLevels");
                    dynamicParameters.Add("@LevelsId",deleteLevels.LevelsId);
                    var result = await dbConnection.QueryAsync<Response>("Kaizen_Master_Levels", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successfull", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetAllLevels(Levels levels)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetAllLevels");

                    var result = await dbConnection.QueryAsync("Kaizen_Master_Levels", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetLevelsById(Levels levels)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetLevelsById");
                    dynamicParameters.Add("@LevelsId", levels.LevelsId);

                    var result = await dbConnection.QueryAsync("Kaizen_Master_Levels", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> InsertLevels(Levels levels)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsertLevels");
                    dynamicParameters.Add("@Level", levels.Level);
                    dynamicParameters.Add("@Marks", levels.Marks);
                    dynamicParameters.Add("@UserId", levels.UserId);

                    var result = await dbConnection.QueryAsync("Kaizen_Master_Levels", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> UpdateLevels(Levels levels)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "UpdateLevels");
                    dynamicParameters.Add("@LevelsId", levels.LevelsId);
                    dynamicParameters.Add("@Level", levels.Level);
                    dynamicParameters.Add("@Marks", levels.Marks);
                    dynamicParameters.Add("@UserId", levels.UserId);

                    var result = await dbConnection.QueryAsync("Kaizen_Master_Levels", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
    }
}
