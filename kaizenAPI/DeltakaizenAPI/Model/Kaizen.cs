using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Kaizen
    {
        public Guid? KaizenId { get; set; }
        public string? No { get; set; }
        public string? Date { get; set; }
        public bool? JustDidIt { get; set; }
        public string? Proposal { get; set; }
        public string? Categories { get; set; }
        public string? Result { get; set; }
        public string? Scope { get; set; }
        public Guid? UserId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? PlantId { get; set; }
        public Guid? Totem { get; set; }
        public decimal? CostSaving { get; set; }
        public Guid? Status { get; set; }
        public Guid? ResponsibleUserId { get; set; }
        public DateTime  ImplementedDate { get; set; }
        public string? BeforeImprovementFilePath { get; set; }
        public string? AfterImprovementFilePath { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? ManagerId { get; set; }
        public string? Action { get; set; }
    }


    public class BaseKaizen
    {
        public Guid? AuthorId { get; set;}
        public List<ImportKaizen>? ImportKaizen { get; set; }
    }

    public class ImportKaizen
    {
        public string? Id { get; set; }
        public string? Category { get; set; }
        public string? Scope { get; set; }
        public string? Status { get; set; }
        public string? Theme { get; set; }
        public decimal? CostSaving    { get; set; }
        public string? Company { get; set; }
        public string? DateImplemented { get; set; }
        public string? Remarks { get; set; }
        public string? Plant { get; set; }
        public string? Totem { get; set; }
        public string? Ideaowner { get; set; }
        public string? ResponsibleforImplementation { get; set; }
        public string? Manager { get; set; }
        public string? JustDIDIt { get; set; }
    }

    public class GiftPDFs
    {
        public IFormFile? GiftPDF { get; set; }
        public Guid? UserId { get; set; }
    }
}
