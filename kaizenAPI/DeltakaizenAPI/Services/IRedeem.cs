using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRedeem
    {
        public Task<Response> InsertRedeem(Redeem redeem);
        public Task<Response> UpdateRedeem(Redeem redeem);
        public Task<Response> GetRedeemById(Guid? RedeemId);
        public Task<Response> GetRedeemDropDown();
        public Task<Response> GetRedeem();
        public Task<Response> GetProductsFromPoints(GetProductsFromPoints getProductsFromPoints);
    }
}
