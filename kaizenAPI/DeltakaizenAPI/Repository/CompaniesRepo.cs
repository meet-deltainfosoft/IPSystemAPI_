using DataHelper;
using Model;
using Services;
using Dapper;
using System.Data.Common;
using DapperParameters;
using System.Data;

namespace Repository
{
    public class CompaniesRepo : ConnectionBase, ICompanies
    {
        public CompaniesRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<Response> GetAllCompany(Companies companies)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetAllCompany");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Company", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> GetIdByCompany(Companies companies)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@CompanyId", companies.CompanyId);
                    dynamicParameters.Add("@Action", "GetCompanyById"); // Remove the extra space after "Action"

                    using (var multiResult = await dbConnection.QueryMultipleAsync("Kaizen_Master_Company", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        var company = await multiResult.ReadAsync(); 
                        var lineDetails = await multiResult.ReadAsync();

                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = new
                            {
                                company = company,
                                lineDetails = lineDetails
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

        public async Task<Response> InsertCompany(Companies companies)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Company", companies.Company);
                    dynamicParameters.Add("@Address", companies.Address);
                    dynamicParameters.Add("@Contact", companies.Contact);
                    dynamicParameters.Add("@City", companies.City);
                    dynamicParameters.Add("@Pincode ", companies.Pincode);
                    dynamicParameters.Add("@CompanyCode ", companies.CompanyCode);
                    dynamicParameters.Add("@GstNumber ", companies.GstNumber);
                    dynamicParameters.Add("@UserId ", companies.UserId);
                    dynamicParameters.AddTable("@LineDetailType", "LineDetailType", companies.lineDetails);
                    dynamicParameters.Add("@Action ", "InsertCompany");

                    return await dbConnection.QueryFirstAsync<Response>("Kaizen_Master_Company", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }

        public async Task<Response> UpdateCompany(Companies companies)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@CompanyId", companies.CompanyId);
                    dynamicParameters.Add("@Company", companies.Company);
                    dynamicParameters.Add("@Address", companies.Address);
                    dynamicParameters.Add("@Contact", companies.Contact);
                    dynamicParameters.Add("@City", companies.City);
                    dynamicParameters.Add("@CompanyCode ", companies.CompanyCode);
                    dynamicParameters.Add("@Pincode ", companies.Pincode);
                    dynamicParameters.Add("@GstNumber ", companies.GstNumber);
                    dynamicParameters.Add("@UserId ", companies.UserId);
                    dynamicParameters.AddTable("@LineDetailType", "LineDetailType", companies.lineDetails);
                    dynamicParameters.Add("@Action ", "UpdateCompany");

                    return await dbConnection.QueryFirstAsync<Response>("Kaizen_Master_Company", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
    }
}