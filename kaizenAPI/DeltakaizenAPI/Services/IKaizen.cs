using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IKaizen
    {
        public Task<Response> GetAllKaizenDropDown(Guid? AuthorId);
        public Task<Response> GetKaizenById(Guid? KaizenId);
        public Task<Response> GetAllKaizen();
        public Task<Response> UpdateKaizen(Kaizen kaizen);
        public Task<Response> InsertKaizen(Kaizen kaizen);
        public Task<Response> ExportKaizenTemplate();
        public Task<Response> ImportKaizen(BaseKaizen BaseKaizen);
        public Task<Response> ImportGiftPDF(Guid UserId, IFormFile formFile);
        public Task<Response> ImportGiftPDF2(GiftPDFs giftPDFs);
    }
}
