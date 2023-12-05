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
    public class PokoYokoRepo : ConnectionBase, IPokoYoko
    {
        public PokoYokoRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<Response> DeleteByProductId(PokoYoko pokoYoko)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "DeleteByProductId");
                    dynamicParameters.Add("@PorudctId", pokoYoko.PorudctId);
                    var result = await dbConnection.QueryAsync<Response>("Kaizen_Report_PokoYoko_System", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var response = result.FirstOrDefault();
                    return new Response() { Message = response.Message, IsSuccessful = response.IsSuccessful, Data = null };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> GetAllProducts()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetAllProducts");
                    var result = await dbConnection.QueryAsync("Kaizen_Report_PokoYoko_System", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> GetProductById(PokoYoko pokoYoko)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetProductById");
                    dynamicParameters.Add("@PorudctId", pokoYoko.PorudctId);
                    var result = await dbConnection.QueryAsync("Kaizen_Report_PokoYoko_System", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
    }
}
