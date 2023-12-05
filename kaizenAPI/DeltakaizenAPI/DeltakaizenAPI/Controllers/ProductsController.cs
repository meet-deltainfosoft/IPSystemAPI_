using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace DeltakaizenAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProducts _Iproducts;
        private readonly IConfiguration _configuration;
        public ProductsController(IProducts products, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _Iproducts = products;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }


        [HttpPost]
        [ActionName("InsrertProduct")]
        public async Task<IActionResult> InsrertProduct(Products products)
        {
            return Ok(await _Iproducts.InsrertProduct(products));
        }

        [HttpPost]
        [ActionName("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Products products)
        {
            return Ok(await _Iproducts.UpdateProduct(products));
        }

        [HttpPost]
        [ActionName("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct(Products products)
        {
            return Ok(await _Iproducts.GetAllProduct(products));
        }

        [HttpPost]
        [ActionName("GetProductById")]
        public async Task<IActionResult> GetProductById(Products products)
        {
            return Ok(await _Iproducts.GetProductById(products));
        }

        [HttpPost]
        [ActionName("ValidateMotorAssembly")]
        public async Task<IActionResult> ValidateMotorAssembly(Products products)
        {
            return Ok(await _Iproducts.ValidateMotorAssembly(products));
        }

        [HttpPost]
        [ActionName("UploadPumpPhotos")]
        public async Task<IActionResult> UploadPumpPhotos([FromForm] UploadPumpPhotos uploadPump,IFormFile file)
        {
            return Ok(await _Iproducts.UploadPumpPhotos(uploadPump, file));
        }

        [HttpPost]
        [ActionName("ValidateSerialNoLable")]
        public async Task<IActionResult> ValidateSerialNoLable(ValidateSerialNoLable ValidateSerialNoLable)
        {
            return Ok(await _Iproducts.ValidateSerialNoLable(ValidateSerialNoLable));
        }

        [HttpPost]
        [ActionName("InsertStages")]
        public async Task<IActionResult> InsertStages(InsertStages InsertStages)
        {
            return Ok(await _Iproducts.InsertStages(InsertStages));
        }

        [HttpPost]
        [ActionName("PackagingPhoto")] 
        public async Task<IActionResult> PackagingPhoto([FromForm] PackagingPhoto PackagingPhoto, IFormFile FrontPhoto, IFormFile TopPhoto, IFormFile OpenPhoto, IFormFile ClosedPhoto)
        {
            return Ok(await _Iproducts.PackagingPhoto(PackagingPhoto, FrontPhoto, TopPhoto, OpenPhoto, ClosedPhoto));
        }

        [HttpPost]
        [ActionName("DashBoardCheckLists")]
        public async Task<IActionResult> DashBoardCheckLists(DashBoardCheckLists DashBoardCheckLists)
        {
            return Ok(await _Iproducts.DashBoardCheckLists(DashBoardCheckLists));
        }


        [HttpPost]
        [ActionName("UpdatePumpType")]
        public async Task<IActionResult> UpdatePumpType(UpdatePumpType updatePumpType)
        {
            return Ok(await _Iproducts.UpdatePumpType(updatePumpType));
        }

        [HttpPost]
        [ActionName("InsertPumpModelDetails")]
        public async Task<IActionResult> InsertPumpModelDetails([FromForm] InsertPumpModelDetails insertPumpModelDetails, IFormFile ImageFrontView, IFormFile ImageSideView, IFormFile ImageCurveImage)
        {
            return Ok(await _Iproducts.InsertPumpModelDetails(insertPumpModelDetails, ImageFrontView, ImageSideView, ImageCurveImage));
        }


        [HttpPost]
        [ActionName("GetPumpDetails")]
        public async Task<IActionResult> GetPumpDetails(GetPumpDetails GetPumpDetails)
        {
            return Ok(await _Iproducts.GetPumpDetails(GetPumpDetails));
        }

        [HttpPost]
        [ActionName("UpdateCurveImages")]
        public async Task<IActionResult> UpdateCurveImages([FromForm] UpdateCurveImages UpdateCurveImages, IFormFile ImageCurveImage, IFormFile ImageFrontView, IFormFile ImageSideView)
        {
            return Ok(await _Iproducts.UpdateCurveImages(UpdateCurveImages,ImageCurveImage, ImageFrontView, ImageSideView));
        }


        [HttpPost]
        [ActionName("ValidateNamePlateString")]
        public async Task<IActionResult> ValidateNamePlateString(ValidateNamePlateString validateNamePlateString)
        {
            return Ok(await _Iproducts.ValidateNamePlateString(validateNamePlateString));
        }

        [HttpPost]
        [ActionName("MotorKWValidate")]
        public async Task<IActionResult> MotorKWValidate(MotorKWValidate motorKWValidate)
        {
            return Ok(await _Iproducts.MotorKWValidate(motorKWValidate));
        }

        [HttpPost]
        [ActionName("GetPoDetailsBySerialNumber")]
        public async Task<IActionResult> GetPoDetailsBySerialNumber(GetPoDetailsBySerialNumber GetPoDetailsBySerialNumber)
        {
            return Ok(await _Iproducts.GetPoDetailsBySerialNumber(GetPoDetailsBySerialNumber));
        }


        [HttpGet]
        [ActionName("GetKWLabel")]
        public async Task<IActionResult> GetKWLabel()
        {
            return Ok(await _Iproducts.GetKWLabel());
        }


        [HttpPost]
        [ActionName("UpdateMotorSerialNumber")]
        public async Task<IActionResult> UpdateMotorSerialNumber(UpdateMotorSerialNumber UpdateMotorSerialNumber)
        {
            return Ok(await _Iproducts.UpdateMotorSerialNumber(UpdateMotorSerialNumber));
        }
    }

}
