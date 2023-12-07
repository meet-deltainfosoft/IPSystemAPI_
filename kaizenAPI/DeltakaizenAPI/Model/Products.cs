using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Products
    {
        public Guid? ProductId { get; set; }
        public string? ProductOrderNumber { get; set; }
        public string? PumpPartNumber { get; set; }
        public string? PumpDescription { get; set; }
        public string? MotorPartNumber { get; set; }
        public string? MotorDescription { get; set; }
        public string? PumpSerialNumber { get; set; }
        public decimal? PumpQty { get; set; }
        public string? Action { get; set; }
        public string? PumpFullNumber { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsSkip { get; set; }
        public string? kwLabel { get; set; }
        public string? PlantId { get; set; }
    }
    public class UploadPumpPhotos
    {
        public string? ProductOrderNumber { get; set; }
        public Guid? UserId { get; set; }
        public string? PumpSerialNumber { get; set; }
        public bool? IsSkip { get; set; }
        public string? PumpPhotos { get; set; }
    }


    public class ValidateSerialNoLable
    {
        public string? PumpSerialNumber { get; set; }
        public string? ProductOrderNumber { get; set; }
    }

    public class InsertStages
    {
        public string? ProductOrderNumber { get; set; }
        public int? StageNo { get; set; }
        public bool? StageStatus { get; set; }
        public string? PumpSerialNumber { get; set; }
        public bool? IsSkip { get; set; }
        public Guid? UserId { get; set; }
    }

    public class PackagingPhoto
    {
        public string? ProductOrderNumber { get; set; }
        public string? StageNo { get; set; }
        public bool? StageStatus { get; set; }
        public string? PumpSerialNumber { get; set; }
        public bool? IsSkip { get; set; }
        public Guid? UserId { get; set; }

    }

    public class DashBoardCheckLists
    {
        public string? ProductOrderNumber { get; set; }
        public string? PumpSerialNumber { get; set; }
    }

    public class UpdatePumpType
    {
        public string? PumpType { get; set; }
        public string? ProductOrderNumber { get; set; }
        public string? BaseType { get; set; }
        public string? KwLabel { get; set; }
        public Guid? UserId { get; set; }
    }

    public class InsertPumpModelDetails
    {
        public Guid? PumpMotorId { get; set; }
        public string? ModelGroup { get; set; }
        public string? ModelType { get; set; }
        public Guid? UserId { get; set; }
       // public string? BaseType { get; set; }
    }

    public class GetPumpDetails
    {
        public string? ModelGroup { get; set; }
        public string? BaseType { get; set; }
    }

    public class UpdateCurveImages
    {
        public Guid? PumpMotorId { get; set; }
    }

    public class ValidateNamePlateString
    {
        public string? NamePlateString { get; set; }
        public string? ProductOrderNumber { get; set; }
    }

    public class MotorKWValidate
    {
        public string? MotorPartNumber { get; set; }
        public string? ProductOrderNumber { get; set; }
    }

    public class GetPoDetailsBySerialNumber
    {
        public string? PumpFullNumber { get; set; }
    }

    public class UpdateMotorSerialNumber
    {
        public string? ProductOrderNumber { get; set; }
        public string? MotorPartNumber { get; set; }
        public string? MotorSerialNumber { get; set; }
    }
}