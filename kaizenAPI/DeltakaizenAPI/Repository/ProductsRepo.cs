using Azure.Core;
using Dapper;
using DataHelper;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using System.Data.Common;
using System.Data;
using System.Numerics;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class ProductsRepo : ConnectionBase, IProducts
    {
        public IConfiguration _Iconfiguration;
        public ProductsRepo(IDbConnectionFactory dbConnectionFactory, IConfiguration configuration) : base(dbConnectionFactory)
        {
            _Iconfiguration = configuration;
        }
        public async Task<Response> GetAllProduct(Products products)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetAllProduct");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };

                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> GetProductById(Products products)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetProductById");
                    dynamicParameters.Add("@ProductOrderNumber", products.ProductOrderNumber);

                    using (var multiResult = await dbConnection.QueryMultipleAsync("Kaizen_Master_Products", dynamicParameters, commandType: CommandType.StoredProcedure))
                    {
                        var resultSets = new List<List<dynamic>>();

                        while (!multiResult.IsConsumed)
                        {
                            var resultSet = multiResult.Read<dynamic>().ToList();
                            resultSets.Add(resultSet);
                        }

                        var flattenedResult = resultSets.SelectMany(x => x);

                        return new Response()
                        {
                            Message = "Successful",
                            IsSuccessful = true,
                            Data = flattenedResult.ToList()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> InsertStages(InsertStages InsertStages)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsertStages");
                    dynamicParameters.Add("@ProductOrderNumber", InsertStages.ProductOrderNumber);
                    dynamicParameters.Add("@StageNo", InsertStages.StageNo);
                    dynamicParameters.Add("@StageStatus", InsertStages.StageStatus);
                    dynamicParameters.Add("@UserId", InsertStages.UserId);
                    dynamicParameters.Add("@IsSkip", InsertStages.IsSkip);
                    dynamicParameters.Add("@PumpSerialNumber", InsertStages.PumpSerialNumber);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> InsrertProduct(Products products)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsrertProduct");
                    dynamicParameters.Add("@ProductId", products.ProductId);
                    dynamicParameters.Add("@ProductOrderNumber", products.ProductOrderNumber);
                    dynamicParameters.Add("@PumpPartNumber", products.PumpPartNumber);
                    dynamicParameters.Add("@PumpDescription", products.PumpDescription);
                    dynamicParameters.Add("@MotorPartNumber", products.MotorPartNumber);
                    dynamicParameters.Add("@MotorDescription", products.MotorDescription);
                    dynamicParameters.Add("@PumpSerialNumber", products.PumpSerialNumber);
                    dynamicParameters.Add("@PumpQty", products.PumpQty);
                    dynamicParameters.Add("@PumpFullNumber", products.PumpFullNumber);
                    dynamicParameters.Add("@UserId", products.UserId);
                    dynamicParameters.Add("@IsSkip", products.IsSkip);
                    dynamicParameters.Add("@kwLabel", products.kwLabel);
                    dynamicParameters.Add("@PlanId", products.PlantId);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };

                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> UpdateProduct(Products products)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsrertProduct");
                    dynamicParameters.Add("@ProductId", products.ProductId);
                    dynamicParameters.Add("@ProductOrderNumber", products.ProductOrderNumber);
                    dynamicParameters.Add("@PumpPartNumber", products.PumpPartNumber);
                    dynamicParameters.Add("@PumpDescription", products.PumpDescription);
                    dynamicParameters.Add("@MotorPartNumber", products.MotorPartNumber);
                    dynamicParameters.Add("@MotorDescription", products.MotorDescription);
                    dynamicParameters.Add("@PumpSerialNumber", products.PumpSerialNumber);
                    dynamicParameters.Add("@PumpQty", products.PumpQty);
                    dynamicParameters.Add("@PumpFullNumber", products.PumpFullNumber);
                    dynamicParameters.Add("@UserId", products.UserId);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };

                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> UploadPumpPhotos(UploadPumpPhotos uploadPump, IFormFile file)
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


                    if (file != null && file.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@Action", "UploadPumpPhotos");
                        dynamicParameters.Add("@UserId", uploadPump.UserId);
                        dynamicParameters.Add("@PumpSerialNumber", uploadPump.PumpSerialNumber);
                        dynamicParameters.Add("@IsSkip", uploadPump.IsSkip);
                        dynamicParameters.Add("@ProductOrderNumber", uploadPump.ProductOrderNumber);
                        dynamicParameters.Add("@PumpPhotos", uniqueFileName);
                    }
                    else
                    {
                        // Handle the case where no file is provided.
                        return new Response() { IsSuccessful = false, Message = "No file uploaded", Data = null };
                    }
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops, something went wrong", Data = null };
            }
        }
        public async Task<Response> ValidateMotorAssembly(Products products)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "ValidateMotorAssembly");
                    dynamicParameters.Add("@ProductOrderNumber", products.ProductOrderNumber);
                    dynamicParameters.Add("@PumpSerialNumber", products.PumpSerialNumber);
                    dynamicParameters.Add("@PumpPartNumber", products.PumpPartNumber);
                    var result = await dbConnection.QueryMultipleAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var resultSet = result.Read<Response>().FirstOrDefault();
                    if (resultSet.IsSuccessful == true)
                    {
                        var data = result.Read();
                        return new Response() { IsSuccessful = true, Message = resultSet.Message, Data = data };
                    }
                    else
                    {
                        return new Response() { IsSuccessful = false, Message = resultSet.Message, Data = null };
                    }

                }
            }
            catch (Exception ex)
            {

                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> ValidateSerialNoLable(ValidateSerialNoLable ValidateSerialNoLable)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "ValidateSerialNoLable");
                    dynamicParameters.Add("@ProductOrderNumber", ValidateSerialNoLable.ProductOrderNumber);
                    dynamicParameters.Add("@PumpSerialNumber", ValidateSerialNoLable.PumpSerialNumber);

                    var result = await dbConnection.QueryMultipleAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var resultSet = result.Read<Response>().FirstOrDefault();
                    if (resultSet.IsSuccessful == true)
                    {
                        var data = result.Read();
                        return new Response() { IsSuccessful = true, Message = resultSet.Message, Data = data };
                    }
                    else
                    {
                        return new Response() { IsSuccessful = false, Message = resultSet.Message, Data = null };
                    }

                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> PackagingPhoto(PackagingPhoto packagingPhoto, IFormFile FrontPhoto, IFormFile TopPhoto, IFormFile OpenPhoto, IFormFile ClosedPhoto)
        {
            try
            {


                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Action", "PackagingPhoto");
                dynamicParameters.Add("@ProductOrderNumber", packagingPhoto.ProductOrderNumber);
                dynamicParameters.Add("@StageNo", packagingPhoto.StageNo);
                dynamicParameters.Add("@StageStatus", packagingPhoto.StageStatus);
                dynamicParameters.Add("@UserId", packagingPhoto.UserId);
                dynamicParameters.Add("@PumpSerialNumber", packagingPhoto.PumpSerialNumber);
                dynamicParameters.Add("@IsSkip", packagingPhoto.IsSkip);
                string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                if (!Directory.Exists(imageDirectory))
                {
                    Directory.CreateDirectory(imageDirectory);
                }
                if (FrontPhoto != null && FrontPhoto.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + FrontPhoto.FileName;
                    string filePath = Path.Combine(imageDirectory, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await FrontPhoto.CopyToAsync(fileStream);
                    }
                    dynamicParameters.Add("@Photo1", uniqueFileName);
                }

                if (TopPhoto != null && TopPhoto.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + TopPhoto.FileName;
                    string filePath = Path.Combine(imageDirectory, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await TopPhoto.CopyToAsync(fileStream);
                    }
                    dynamicParameters.Add("@Photo2", uniqueFileName);
                }

                if (OpenPhoto != null && OpenPhoto.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + OpenPhoto.FileName;
                    string filePath = Path.Combine(imageDirectory, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await OpenPhoto.CopyToAsync(fileStream);
                    }
                    dynamicParameters.Add("@Photo3", uniqueFileName);
                }

                if (ClosedPhoto != null && ClosedPhoto.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + ClosedPhoto.FileName;
                    string filePath = Path.Combine(imageDirectory, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ClosedPhoto.CopyToAsync(fileStream);
                    }
                    dynamicParameters.Add("@Photo4", uniqueFileName);
                }


                //foreach (var file in files)
                //{
                //    if (file.Length > 0)
                //    {
                //        if (file.FileName.Contains("FrontPhoto"))
                //        {
                //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                //            string filePath = Path.Combine(imageDirectory, uniqueFileName);
                //            dynamicParameters.Add("@Photo1", uniqueFileName);
                //            using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            {
                //                await file.CopyToAsync(fileStream);
                //            }
                //        }
                //        else if(file.FileName.Contains("TopPhoto"))
                //        {
                //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                //            string filePath = Path.Combine(imageDirectory, uniqueFileName);
                //            dynamicParameters.Add("@Photo2", uniqueFileName);
                //            using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            {
                //                await file.CopyToAsync(fileStream);
                //            }
                //        }

                //        else if (file.FileName.Contains("OpenPhoto"))
                //        {
                //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                //            string filePath = Path.Combine(imageDirectory, uniqueFileName);
                //            dynamicParameters.Add("@Photo3", uniqueFileName);
                //            using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            {
                //                await file.CopyToAsync(fileStream);
                //            }
                //        }
                //        else if(file.FileName.Contains("ClosedPhoto"))
                //        {
                //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                //            string filePath = Path.Combine(imageDirectory, uniqueFileName);
                //            dynamicParameters.Add("@Photo4", uniqueFileName);
                //            using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            {
                //                await file.CopyToAsync(fileStream);
                //            }
                //        }
                //    }
                //}
                using (var dbConnection = GetDbConnection())
                {
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = true, Message = "Successful", Data = null };

            }
        }
        public async Task<Response> DashBoardCheckLists(DashBoardCheckLists DashBoardCheckLists)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "DashBoardCheckLists");
                    dynamicParameters.Add("@ProductOrderNumber", DashBoardCheckLists.ProductOrderNumber);
                    dynamicParameters.Add("@PumpSerialNumber", DashBoardCheckLists.PumpSerialNumber);
                    var cmd = new CommandDefinition("Kaizen_Master_Products", dynamicParameters, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache);
                    using (var reader = await dbConnection.QueryMultipleAsync(cmd))
                    {
                        var Products = await reader.ReadAsync();
                        var ValidationDetails = await reader.ReadAsync();

                        return new Response() { IsSuccessful = true, Message = "Successful", Data = new { Products = Products, ValidationDetails = ValidationDetails } };
                    }
                }

            }
            catch (Exception)
            {
                return new Response() { IsSuccessful = true, Message = "Successful", Data = null };
            }
        }
        public async Task<Response> UpdatePumpType(UpdatePumpType UpdatePumpType)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "UpdatePumpType");
                    dynamicParameters.Add("@PumpType", UpdatePumpType.PumpType);
                    dynamicParameters.Add("@UserId", UpdatePumpType.UserId);
                    dynamicParameters.Add("@BaseType", UpdatePumpType.BaseType);
                    dynamicParameters.Add("@ProductOrderNumber", UpdatePumpType.ProductOrderNumber);
                    dynamicParameters.Add("@KwLabel", UpdatePumpType.KwLabel);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = true, Message = "Successful", Data = null };
            }
        }
        public async Task<Response> InsertPumpModelDetails(InsertPumpModelDetails insertPumpModelDetails, IFormFile ImageFrontView, IFormFile ImageSideView, IFormFile ImageCurveImage)
        {
            try
            {
                var FileUploadPath = _Iconfiguration["UploadFolderPath"];
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "InsertPumpModelDetails");
                    dynamicParameters.Add("@PumpMotorId", insertPumpModelDetails.PumpMotorId);
                    dynamicParameters.Add("@ModelGroup", insertPumpModelDetails.ModelGroup);
                    dynamicParameters.Add("@ModelType", insertPumpModelDetails.ModelType);
                    string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }

                    if (ImageFrontView != null && ImageFrontView.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFrontView.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFrontView.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@ImageFrontView", FileUploadPath + uniqueFileName);
                    }

                    if (ImageSideView != null && ImageSideView.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageSideView.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageSideView.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@ImageSideView", FileUploadPath + uniqueFileName);
                    }


                    if (ImageCurveImage != null && ImageCurveImage.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageCurveImage.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageCurveImage.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@ImageCurveImage", FileUploadPath + uniqueFileName);
                    }

                    dynamicParameters.Add("@UserId", insertPumpModelDetails.UserId);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_PumpModelDetails", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = true, Message = "Successful", Data = null };
            }
        }
        public async Task<Response> GetPumpDetails(GetPumpDetails getPumpDetails)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetPumpDetails");
                    dynamicParameters.Add("@ModelGroup", getPumpDetails.ModelGroup);
                    dynamicParameters.Add("@BaseType", getPumpDetails.BaseType);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_PumpModelDetails", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { IsSuccessful = true, Message = "Successful", Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = true, Message = "Successful", Data = null };
            }
        }
        public async Task<Response> UpdateCurveImages(UpdateCurveImages updateCurveImages, IFormFile ImageCurveImage, IFormFile ImageFrontView, IFormFile ImageSideView)
        {
            try
            {
                var FileUploadPath = _Iconfiguration["UploadFolderPath"];
                using (var dbConnection = GetDbConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "UpdateCurveImages");
                    dynamicParameters.Add("@PumpMotorId", updateCurveImages.PumpMotorId);
                    string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }

                    if (ImageCurveImage != null && ImageCurveImage.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageCurveImage.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageCurveImage.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@ImageCurveImage", FileUploadPath + uniqueFileName);
                    }


                    if (ImageFrontView != null && ImageFrontView.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFrontView.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFrontView.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@ImageFrontView", FileUploadPath + uniqueFileName);
                    }


                    if (ImageSideView != null && ImageSideView.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageSideView.FileName;
                        string filePath = Path.Combine(imageDirectory, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageSideView.CopyToAsync(fileStream);
                        }
                        dynamicParameters.Add("@ImageSideView", FileUploadPath + uniqueFileName);
                    }

                    var result = await dbConnection.QueryAsync<Response>("Kaizen_Master_PumpModelDetails", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var response = result.FirstOrDefault<Response>();
                    return new Response() { Message = response.Message, IsSuccessful = response.IsSuccessful, Data = null };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = true, Message = "Successful", Data = null };
            }
        }
        public async Task<Response> ValidateNamePlateString(ValidateNamePlateString validateNamePlateString)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "ValidateNamePlateString");
                    dynamicParameters.Add("@ProductOrderNumber", validateNamePlateString.ProductOrderNumber);
                    dynamicParameters.Add("@NamePlateString", validateNamePlateString.NamePlateString);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> MotorKWValidate(MotorKWValidate motorKWValidate)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "MotorKWValidate");
                    dynamicParameters.Add("@MotorPartNumber", motorKWValidate.MotorPartNumber);
                    dynamicParameters.Add("@ProductOrderNumber", motorKWValidate.ProductOrderNumber);
                    var result = await dbConnection.QueryAsync<Response>("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var response = result.FirstOrDefault();
                    return new Response() { Message = response.Message, IsSuccessful = response.IsSuccessful, Data = null };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> GetPoDetailsBySerialNumber(GetPoDetailsBySerialNumber GetPoDetailsBySerialNumber)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetPoDetailsBySerialNumber");
                    dynamicParameters.Add("@PumpFullNumber", GetPoDetailsBySerialNumber.PumpFullNumber);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful =true, Data = result };
                }
            }
            catch (Exception)
            {

                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async  Task<Response> GetKWLabel()
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "GetKWLabel");
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception)
            {

                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
        public async Task<Response> UpdateMotorSerialNumber(UpdateMotorSerialNumber UpdateMotorSerialNumber)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Action", "UpdateMotorSerialNumber");
                    dynamicParameters.Add("@ProductOrderNumber", UpdateMotorSerialNumber.ProductOrderNumber);
                    dynamicParameters.Add("@MotorPartNumber", UpdateMotorSerialNumber.MotorPartNumber);
                    dynamicParameters.Add("@MotorSerialNumber", UpdateMotorSerialNumber.MotorSerialNumber);
                    var result = await dbConnection.QueryAsync("Kaizen_Master_Products", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { Message = "Successful", IsSuccessful = true, Data = result };
                }
            }
            catch (Exception)
            {

                return new Response() { IsSuccessful = false, Message = "Oops Something Went Wrong", Data = null };
            }
        }
    }
}
