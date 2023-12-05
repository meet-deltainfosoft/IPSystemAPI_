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
    public class PokaYokeDashboardRepo : ConnectionBase, IPokaYokeDashboard
    {
        public PokaYokeDashboardRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<Response> GetPokaYokeDashBoard()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetPokaYokeDashBoard"); // Remove the extra space after "Action"

                    using (var multiResult = await dbConnection.QueryMultipleAsync("PokaYoke_DashBoard", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        var ProductLeaderBoard = await multiResult.ReadAsync();
                        var WidgerData = await multiResult.ReadAsync();
                        var MonthWiseQty = await multiResult.ReadAsync();

                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = new
                            {
                                ProductLeaderBoard = ProductLeaderBoard,
                                WidgerData = WidgerData,
                                MonthWiseQty = MonthWiseQty
                            }
                        };
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
