using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProducts
    {
        public Task<Response> InsrertProduct(Products products);
        public Task<Response> UpdateProduct(Products products);
        public Task<Response> GetAllProduct(Products products);
        public Task<Response> GetProductById(Products products);
        public Task<Response> ValidateMotorAssembly(Products products);
        public Task<Response> UploadPumpPhotos(UploadPumpPhotos uploadPump, IFormFile file);
        public Task<Response> ValidateSerialNoLable(ValidateSerialNoLable ValidateSerialNoLable);
        public Task<Response> InsertStages(InsertStages InsertStages);
        public Task<Response> PackagingPhoto(PackagingPhoto PackagingPhoto, IFormFile FrontPhoto, IFormFile TopPhoto, IFormFile OpenPhoto, IFormFile ClosedPhoto);
        public Task<Response> DashBoardCheckLists(DashBoardCheckLists DashBoardCheckLists);
        public Task<Response> UpdatePumpType(UpdatePumpType UpdatePumpType);
        public Task<Response> InsertPumpModelDetails(InsertPumpModelDetails insertPumpModelDetails, IFormFile ImageFrontView, IFormFile ImageSideView, IFormFile ImageCurveImage);
        public Task<Response> GetPumpDetails(GetPumpDetails getPumpDetails);
        public Task<Response> UpdateCurveImages(UpdateCurveImages updateCurveImages, IFormFile ImageCurveImage, IFormFile ImageFrontView, IFormFile ImageSideView);
        public Task<Response> ValidateNamePlateString(ValidateNamePlateString validateNamePlateString);
        public Task<Response> MotorKWValidate(MotorKWValidate motorKWValidate);
        public Task<Response> GetPoDetailsBySerialNumber(GetPoDetailsBySerialNumber GetPoDetailsBySerialNumber);
        public Task<Response> GetKWLabel();
        public Task<Response> UpdateMotorSerialNumber(UpdateMotorSerialNumber UpdateMotorSerialNumber);
    }
}
