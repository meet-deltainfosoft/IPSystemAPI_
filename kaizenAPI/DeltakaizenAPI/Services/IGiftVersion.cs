using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IGiftVersion
    {
        public Task<Response> InsertGiftVersion(GiftVersion giftVersion);
        public Task<Response> UpdateGiftVersion(GiftVersion giftVersion);
        public Task<Response> GetAllGiftVersion();
        public Task<Response> GetGiftVersionById(GiftVersion giftVersion);
        public Task<Stream> DownloadGiftVersionPDF(string GiftVersionPath);
    }
}
