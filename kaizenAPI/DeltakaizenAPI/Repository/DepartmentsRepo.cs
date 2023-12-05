using Dapper;
using DataHelper;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DepartmentsRepo : ConnectionBase, IDepartment
    {
        public DepartmentsRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<Response> GetAllDepartment(Department department)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetAllDepartment");

                    var result =  await dbConnection.QueryAsync("Kaizen_Master_Departments", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> GetDepartmentById(Department department)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DepartmentId ", department.DepartmentId);
                    dynamicParameters.Add("@Action ", "GetDepartmentById");

                    var result =  await dbConnection.QueryAsync("Kaizen_Master_Departments", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful",IsSuccessful = true, Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> GetDepartmentDropDown(Department department)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetDepartmentDropDown");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Departments", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Sucessful", Data = result };
                }
            }
            catch (Exception)
            {

                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> InsertDepartment(Department department)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DepartmentId ", department.DepartmentId);
                    dynamicParameters.Add("@Department ", department.DepartmentName);
                    dynamicParameters.Add("@PlantId ", department.PlantId);
                    dynamicParameters.Add("@UserId ", department.UserId);
                    dynamicParameters.Add("@Action ", "InsertDepartment");

                    return await dbConnection.QueryFirstAsync<Response>("Kaizen_Master_Departments", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> UpdateDepartment(Department department)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DepartmentId ", department.DepartmentId);
                    dynamicParameters.Add("@Department ", department.DepartmentName);
                    dynamicParameters.Add("@PlantId ", department.PlantId);
                    dynamicParameters.Add("@UserId ", department.UserId);
                    dynamicParameters.Add("@Action ", "UpdateDepartment");

                    return await dbConnection.QueryFirstAsync<Response>("Kaizen_Master_Departments", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
    }
}
