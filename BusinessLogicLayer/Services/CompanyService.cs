using System.Collections.Generic;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.Infrastructure;

namespace BusinessLogicLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ServiceModule serviceModule = new ServiceModule();

        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }
         
        public IList<CompanyDTO> GetCompanies()
        {
            return serviceModule.ConvertToCompanyDTOList(companyRepository.GetCompanies());
        }

        public CompanyDTO GetCompanyById(int? id)
        {
            var company =  companyRepository.GetCompanyById(id);

            return serviceModule.ConvertToCompanyDTO(company);
        }

        public void InsertNew(CompanyDTO companyDTO)
        {
           var company =  serviceModule.ConvertToCompany(companyDTO);
           companyRepository.InsertNew(company);
        }

        public void Update(CompanyDTO companyDTO)
        {
            var company = serviceModule.ConvertToCompany(companyDTO);
            companyRepository.Update(company);
        }

        public void Delete(CompanyDTO companyDTO)
        {
            var company = serviceModule.ConvertToCompany(companyDTO);
            companyRepository.Delete(company);
        }
    }
}
