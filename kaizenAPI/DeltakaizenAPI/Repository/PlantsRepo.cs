using DataHelper;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Repository
{
    public class PlantsRepo : ConnectionBase, IPlant
    {
        public PlantsRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<Response> GetAllPlant(Plant plant)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetAllPlant");

                    var result = await dbConnection.QueryAsync("Kaizen_Master_Plants", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> GetPlantById(Plant plant)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PlantId", plant.PlantId);
                    dynamicParameters.Add("@Action", "GetPlantById");   

                    var result = await dbConnection.QueryAsync("Kaizen_Master_Plants", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> InsertPlant(Plant plant)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsertPlant");
                    dynamicParameters.Add("@Plant", plant.PlantName);
                    dynamicParameters.Add("@UserId", plant.UserId);

                    return await dbConnection.QueryFirstAsync<Response>("Kaizen_Master_Plants", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    //return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> UpdatePlant(Plant plant)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "UpdatePlant");
                    dynamicParameters.Add("@PlantId", plant.PlantId);
                    dynamicParameters.Add("@Plant", plant.PlantName);
                    dynamicParameters.Add("@UserId", plant.UserId);

                    return await dbConnection.QueryFirstAsync<Response>("Kaizen_Master_Plants", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
    }
}
