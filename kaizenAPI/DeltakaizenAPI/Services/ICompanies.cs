using Model;

namespace Services
{
    public interface ICompanies
    {
        public Task<Response> InsertCompany(Companies companies);
        public Task<Response> UpdateCompany(Companies companies);
        public Task<Response> GetIdByCompany(Companies companies);
        public Task<Response> GetAllCompany(Companies companies);
    }
}