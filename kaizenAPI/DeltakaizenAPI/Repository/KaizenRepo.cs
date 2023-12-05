using Dapper;
using DapperParameters;
using DataHelper;
using Microsoft.AspNetCore.Http;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class KaizenRepo : ConnectionBase, IKaizen
    {
        public KaizenRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<Response> ExportKaizenTemplate()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "ExportKaizenTemplate");
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_kiazens", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };

                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetAllKaizen()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetAllKaizen");
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_kiazens", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };

                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetAllKaizenDropDown(Guid? AuthorId)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetAllKaizenDropDown");
                    dynamicParameters.Add("@AuthorId ", AuthorId);
                    var cmd = new CommandDefinition("Kaizen_Transaction_kiazens", dynamicParameters, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache);
                    using (var reader = await dbConnection.QueryMultipleAsync(cmd))
                    {
                        var plants = await reader.ReadAsync();
                        var departments = await reader.ReadAsync();
                        var companies = await reader.ReadAsync();
                        var status = await reader.ReadAsync();
                        var category = await reader.ReadAsync();
                        var totem = await reader.ReadAsync();
                        var users = await reader.ReadAsync();
                        var IPNumber = await reader.ReadAsync();
                        var Employee = await reader.ReadAsync();
                        var Manager = await reader.ReadAsync();

                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = new
                            {
                                plants = plants,
                                departments = departments,
                                companies = companies,
                                status = status,
                                category = category,
                                totem = totem,
                                users = users,
                                IPNumber = IPNumber,
                                Employee = Employee,
                                Manager = Manager,
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> GetKaizenById(Guid? KaizenId)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action ", "GetKaizenById");
                    dynamicParameters.Add("@KaizenId", KaizenId);
                    var cmd = new CommandDefinition("Kaizen_Transaction_kiazens", dynamicParameters, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache);
                    using (var reader = await dbConnection.QueryMultipleAsync(cmd))
                    {
                        var response = await reader.ReadAsync();
                        var categories = await reader.ReadAsync();
                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = new
                            {
                                response = response,
                                categories = categories
                            }
                        };
                    }
                    //var result = await dbConnection.QueryAsync("Kaizen_Transaction_kiazens", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Response> ImportGiftPDF(Guid UserId, IFormFile GiftPDF)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }
                    if (GiftPDF != null && GiftPDF.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + GiftPDF.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await GiftPDF.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@Action", "ImportGiftPDF");
                        dynamicParameters.Add("@UserId", UserId);
                        dynamicParameters.Add("@GiftUploadPath", filePath);
                        var result = await dbConnection.QueryAsync("Kaizen_Transaction_kiazens", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                        return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                    }
                    else
                    {
                        return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops, something went wrong", Data = null };
            }
        }

        public async Task<Response> ImportGiftPDF2(GiftPDFs giftPDFs)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }
                    if (giftPDFs.GiftPDF != null && giftPDFs.GiftPDF.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + giftPDFs.GiftPDF.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await giftPDFs.GiftPDF.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@Action", "ImportGiftPDF");
                        dynamicParameters.Add("@UserId", giftPDFs.UserId);
                        dynamicParameters.Add("@GiftUploadPath", filePath);
                        var result = await dbConnection.QueryAsync("Kaizen_Transaction_kiazens", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                        return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                    }
                    else
                    {
                        return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops, something went wrong", Data = null };
            }
        }

        public async Task<Response> ImportKaizen(BaseKaizen BaseKaizen)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("Action", "ImportKaizen2");
                    dynamicParameters.Add("AuthorId", BaseKaizen.AuthorId);
                    dynamicParameters.AddTable("@KaizenType", "KaizenType", BaseKaizen.ImportKaizen);
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_kiazens", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };

                    //var cmd = new CommandDefinition("Kaizen_Transaction_kiazens", dynamicParameters, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache);
                    //using (var reader = await dbConnection.QueryMultipleAsync(cmd))
                    //{
                    //    var response = reader.Read<Response>().FirstOrDefault();
                    //    if (response.IsSuccessful == false)
                    //    {
                    //        var data = reader.Read();
                    //        return new Response() { IsSuccessful = response.IsSuccessful, Message = response.Message, Data = data };
                    //    }
                    //    else
                    //    {
                    //        return new Response() { IsSuccessful = response.IsSuccessful, Message = response.Message, Data = null };
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> InsertKaizen(Kaizen kaizen)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@KaizenId", kaizen.KaizenId);
                dynamicParameters.Add("@No", kaizen.No);
                dynamicParameters.Add("@Date", kaizen.Date);
                dynamicParameters.Add("@JustDidIt", kaizen.JustDidIt);
                dynamicParameters.Add("@Proposal", kaizen.Proposal);
                dynamicParameters.Add("@Categories", kaizen.Categories);
                dynamicParameters.Add("@Result", kaizen.Result);
                dynamicParameters.Add("@Scope", kaizen.Scope);
                dynamicParameters.Add("@UserId", kaizen.UserId);
                dynamicParameters.Add("@DepartmentId", kaizen.DepartmentId);
                dynamicParameters.Add("@CompanyId", kaizen.CompanyId);
                dynamicParameters.Add("@PlantId", kaizen.PlantId);
                dynamicParameters.Add("@Totem", kaizen.Totem);
                dynamicParameters.Add("@CostSaving", kaizen.CostSaving);
                dynamicParameters.Add("@Status", kaizen.Status);
                dynamicParameters.Add("@ResposibleUserId", kaizen.ResponsibleUserId);
                dynamicParameters.Add("@ImplementedDate", kaizen.ImplementedDate);
                dynamicParameters.Add("@BeforeImprovementFilePath", kaizen.@BeforeImprovementFilePath);
                dynamicParameters.Add("@AfterImprovementFilePath", kaizen.AfterImprovementFilePath);
                dynamicParameters.Add("@ManagerId", kaizen.ManagerId);
                dynamicParameters.Add("@AuthorId", kaizen.AuthorId);
                dynamicParameters.Add("@Action", "InsertKaizen");
                using (var dbConnection = GetDbConnection())
                {
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_kiazens", dynamicParameters, commandType: CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "", Data = result };
                }

            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> UpdateKaizen(Kaizen kaizen)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@KaizenId", kaizen.KaizenId);
                dynamicParameters.Add("@No", kaizen.No);
                dynamicParameters.Add("@Date", kaizen.Date);
                dynamicParameters.Add("@JustDidIt", kaizen.JustDidIt);
                dynamicParameters.Add("@Proposal", kaizen.Proposal);
                dynamicParameters.Add("@Categories", kaizen.Categories);
                dynamicParameters.Add("@Result", kaizen.Result);
                dynamicParameters.Add("@Scope", kaizen.Scope);
                dynamicParameters.Add("@UserId", kaizen.UserId);
                dynamicParameters.Add("@DepartmentId", kaizen.DepartmentId);
                dynamicParameters.Add("@CompanyId", kaizen.CompanyId);
                dynamicParameters.Add("@PlantId", kaizen.PlantId);
                dynamicParameters.Add("@Totem", kaizen.Totem);
                dynamicParameters.Add("@CostSaving", kaizen.CostSaving);
                dynamicParameters.Add("@Status", kaizen.Status);
                dynamicParameters.Add("@ResposibleUserId", kaizen.ResponsibleUserId);
                dynamicParameters.Add("@ImplementedDate", kaizen.ImplementedDate);
                dynamicParameters.Add("@BeforeImprovementFilePath", kaizen.@BeforeImprovementFilePath);
                dynamicParameters.Add("@AfterImprovementFilePath", kaizen.AfterImprovementFilePath);
                dynamicParameters.Add("@ManagerId", kaizen.ManagerId);
                dynamicParameters.Add("@AuthorId", kaizen.AuthorId);
                dynamicParameters.Add("@Action", "UpdateKaizen");
                using (var dbConnection = GetDbConnection())
                {
                    var result = await dbConnection.QueryAsync("Kaizen_Transaction_kiazens", dynamicParameters, commandType: CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "", Data = result };
                }

            }
            catch (Exception ex)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
    }
}
