﻿using Dapper;
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

        public async Task<Response> GetDashBoardById(GetDashBoardById GetDashBoardById)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@ProductId", GetDashBoardById.ProductId);
                    dynamicParameters.Add("@PumpSerialNumber", GetDashBoardById.PumpSerialNumber);
                    dynamicParameters.Add("@Action", "GetDashBoardById");
                    using (var multiResult = await dbConnection.QueryMultipleAsync("Poko_Report_DashBoard", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        var ProductsData = await multiResult.ReadAsync();
                        var ProductsDetail = await multiResult.ReadAsync();

                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = new
                            {
                                ProductsData = ProductsData,
                                ProductsDetail = ProductsDetail
                            }
                        };
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> GetPokaYokeDashBoard(PokaYokeDashboard pokaYokeDashboard)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Type", pokaYokeDashboard.Type);
                    dynamicParameters.Add("@Action", "GetPokaYokeDashBoard");


                    using (var multiResult = await dbConnection.QueryMultipleAsync("PokaYoke_DashBoard", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        var ProductLeaderBoard = await multiResult.ReadAsync();
                        var WidgerData = await multiResult.ReadAsync();
                        var MonthWiseQty = await multiResult.ReadAsync();
                        var ProductsDetail = await multiResult.ReadAsync();

                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = new
                            {
                                ProductLeaderBoard = ProductLeaderBoard,
                                WidgerData = WidgerData,
                                MonthWiseQty = MonthWiseQty,
                                ProductsDetail = ProductsDetail
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
