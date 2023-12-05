using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserRights
    {
        public Task<Response> GetAllUserRights(UserRights userRights);
        public Task<Response> InsertUserRights(UserRights userRights);
        public Task<Response> GetAllMenu();
        public Task<Response> GetAllRights();
    }
}
