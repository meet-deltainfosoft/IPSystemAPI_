using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPokoYoko
    {
        public Task<Response> GetAllProducts();
        public Task<Response> GetProductById(PokoYoko pokoYoko);
        public Task<Response> DeleteByProductId(PokoYoko pokoYoko);
    }
}
