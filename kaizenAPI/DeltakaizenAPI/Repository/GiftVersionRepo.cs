using Dapper;
using DataHelper;
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
    public class GiftVersionRepo : ConnectionBase, IGiftVersion
    {
        public GiftVersionRepo(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<Response> GetAllGiftVersion()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetAllGiftVersion");
                    //var result = await dbConnection.QueryMultipleAsync("Kaizen_Master_GiftVersion", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var cmd = new CommandDefinition("Kaizen_Master_GiftVersion", dynamicParameters, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache);
                    using (var reader = await dbConnection.QueryMultipleAsync(cmd))
                    {
                        var CountResults = await reader.ReadAsync();
                        var GiftVersions = await reader.ReadAsync();
                        return new Response()
                        {
                            IsSuccessful = true,
                            Message = "Successful",
                            Data = new
                            {
                                CountResults = CountResults,
                                GiftVersions = GiftVersions
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
        public async Task<Response> GetGiftVersionById(GiftVersion giftVersion)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetGiftVersionById");
                    dynamicParameters.Add("@GiftVersionId", giftVersion.GiftVersionId);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_GiftVersion", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> InsertGiftVersion(GiftVersion giftVersion)
        {
            try
            {
                string filePath = "";
                using (var dbConnection = GetDbConnection())
                {
                    string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }
                    if (giftVersion.GiftCataloguePath != null && giftVersion.GiftCataloguePath.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + giftVersion.GiftCataloguePath.FileName;
                        filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await giftVersion.GiftCataloguePath.CopyToAsync(fileStream);
                        }
                    }
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsertGiftVersion");
                    dynamicParameters.Add("@Version", giftVersion.Version);
                    dynamicParameters.Add("@UserId", giftVersion.UserId);
                    dynamicParameters.Add("@GiftCataloguePath", filePath);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_GiftVersion", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Response> UpdateGiftVersion(GiftVersion giftVersion)
        {
            try
            {
                string filePath = "";
                using (var dbConnection = GetDbConnection())
                {
                    string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }
                    if (giftVersion.GiftCataloguePath != null && giftVersion.GiftCataloguePath.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + giftVersion.GiftCataloguePath.FileName;
                        filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await giftVersion.GiftCataloguePath.CopyToAsync(fileStream);
                        }
                    }
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "UpdateGiftVersion");
                    dynamicParameters.Add("@Version", giftVersion.Version);
                    dynamicParameters.Add("@UserId", giftVersion.UserId);
                    dynamicParameters.Add("@GiftCataloguePath", filePath);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_GiftVersion", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception)
            {
                return new Response() { Message = "Oops Something Went Wrong!!", IsSuccessful = false, Data = null };
            }
        }
        public async Task<Stream> DownloadGiftVersionPDF(string GiftVersionPath)
        {
            using (var dbConnection = GetDbConnection())
            {
                return new FileStream(GiftVersionPath, FileMode.Open, FileAccess.Read);
            }
        }

        
    }
}
