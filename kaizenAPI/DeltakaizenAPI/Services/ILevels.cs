using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ILevels
    {
        public Task<Response> InsertLevels(Levels levels);
        public Task<Response> UpdateLevels(Levels levels);
        public Task<Response> GetAllLevels(Levels levels);
        public Task<Response> GetLevelsById(Levels levels);
        public Task<Response> DeleteLevels(DeleteLevels deleteLevels);
    }
}
