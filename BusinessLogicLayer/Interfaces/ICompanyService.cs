using System.Collections.Generic;
namespace BusinessLogicLayer.Interfaces
{
    //Методы предназначены для получения экземпляра компании по id либо списка компаний из репозитория в DataAccessLayer.
    //Отправки данных полей экземпляра компании в репозиторий для последующего создания, изменения и удаления.
   public interface ICompanyService
    {
        IList<CompanyDTO> GetCompanies();
        CompanyDTO GetCompanyById(int? id);
        void InsertNew(CompanyDTO company);
        void Update(CompanyDTO company);
        void Delete(CompanyDTO company);
    }
}
