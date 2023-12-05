using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPlant
    {
        public Task<Response> InsertPlant(Plant plant);
        public Task<Response> UpdatePlant(Plant plant);
        public Task<Response> GetAllPlant(Plant plant);
        public Task<Response> GetPlantById(Plant plant);
    }
}
