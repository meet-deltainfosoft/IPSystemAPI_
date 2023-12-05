using Dapper;
using DapperParameters;
using DataHelper;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Model.Menus;

namespace Repository
{
    public class EmployeesRepo : ConnectionBase, IEmployees
    {
        public EmployeesRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<Response> GetAllEmployees(Employees employees)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetAllEmployees");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Employees", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result};
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> GetAllEmployeesDropDown(Employees employees)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetAllEmployeesDropDown");
                    var cmd = new CommandDefinition("Kaizen_Master_Employees", dynamicParameters, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache);
                    using (var reader = await dbConnection.QueryMultipleAsync(cmd))
                    {
                        var Department = await reader.ReadAsync();
                        var JobTitle = await reader.ReadAsync();
                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = new
                            {
                                Department = Department,
                                JobTitle = JobTitle
                            }
                        };
                    }

                    //var result = await dbConnection.QueryMultipleAsync("Kaizen_Master_Employees", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                    

                    //var Department = result.Read();
                    //var JobTitle = result.Read();

                    //return new Response() { Message = "Successful", IsSuccessful = true, Data = new { Department  = Department , JobTitle  = JobTitle } };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> GetEmployeesById(Employees employees)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetEmployeesById");
                    dynamicParameters.Add("@EmployeId ", employees.EmployeId);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Employees", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> InsertEmployees(Employees employees)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    
                    dynamicParameters.Add("@EmployeId", employees.EmployeId);
                    dynamicParameters.Add("@SAPId", employees.SAPId);
                    dynamicParameters.Add("@ShortalInitial", employees.ShortalInitial);
                    dynamicParameters.Add("@Employee", employees.Employee);
                    dynamicParameters.Add("@JobTitle", employees.JobTitle);
                    dynamicParameters.Add("@Department", employees.Department);
                    dynamicParameters.Add("@DateOfJoin", employees.DateOfJoin);
                    dynamicParameters.Add("@UserId", employees.UserId);
                    dynamicParameters.Add("@Action", "InsertEmployees");

                    var result = await dbConnection.QueryAsync("Kaizen_Master_Employees", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> UpdateEmployees(Employees employees)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "UpdateEmployees");
                    dynamicParameters.Add("@EmployeId", employees.EmployeId);
                    dynamicParameters.Add("@SAPId", employees.SAPId);
                    dynamicParameters.Add("@ShortalInitial", employees.ShortalInitial);
                    dynamicParameters.Add("@Employee", employees.Employee);
                    dynamicParameters.Add("@JobTitle", employees.JobTitle);
                    dynamicParameters.Add("@Department", employees.Department);
                    dynamicParameters.Add("@DateOfJoin", employees.DateOfJoin);
                    dynamicParameters.Add("@UserId", employees.UserId);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Employees", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> ImportEmployee(EmployeeBase employees)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "ImportEmployee");
                    dynamicParameters.Add("@UserId", employees.UserId);
                    dynamicParameters.AddTable("@UT_Employee", "UT_Employee", employees.employeeImportDetails);
                    var result = await dbConnection.QueryMultipleAsync("Kaizen_Master_Employees", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var resultSet = result.Read<Response>().FirstOrDefault();
                    if (resultSet.IsSuccessful == false)
                    {
                        var data = result.Read();
                        return new Response() { IsSuccessful = false, Message = "Invalid Information", Data = data };
                    }
                    else
                    {
                        return new Response() { IsSuccessful = resultSet.IsSuccessful, Message = resultSet.Message, Data = null };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> ExportEmployeesTemplate()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();

                    dynamicParameters.Add("@Action", "ExportEmployeesTemplate");

                    var result = await dbConnection.QueryAsync("Kaizen_Master_Employees", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
    }
}
