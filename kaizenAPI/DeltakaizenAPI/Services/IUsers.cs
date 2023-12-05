using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public  interface IUsers
    {
        public Task<Response> InsertUsers(Users users);
        public Task<Response> UpdateUsers(Users users);
        public Task<Response> GetUserById(Users users);
        public Task<Response> GetAllUser();
    }
}
