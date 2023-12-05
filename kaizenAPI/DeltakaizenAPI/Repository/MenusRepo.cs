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
    public class MenusRepo : ConnectionBase, IMenus
    {
        public MenusRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<Response> GetAllMenu(Menus.RequestParameters requestParameters)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetAllMenu");
                    dynamicParameters.Add("@UserId ", requestParameters.UserId);
                    var result = await dbConnection.QueryMultipleAsync("Kaizen_Master_Menu", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var ParentMenus = result.Read<Menus.ParentMenus>();
                    var Master = result.Read();
                    var Transaction = result.Read();
                    var Reports = result.Read();
                    var UtilitySettings = result.Read();

                    return new Response() { Message = "Successful", IsSuccessful = true, Data = new {ParentMenus = ParentMenus ,Masters = Master,Transaction = Transaction,Reports = Reports,UtilitySettings = UtilitySettings} };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

       
    }
}
