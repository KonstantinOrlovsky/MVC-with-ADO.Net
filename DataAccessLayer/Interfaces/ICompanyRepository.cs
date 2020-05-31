using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    //Методы предназначены для получения экземпляра компании по id либо списка компаний из базы данных.
    //Отправки данных полей экземпляра компании в базу данных для последующего создания, изменения и удаления записи в таблице Companies
    public interface ICompanyRepository
    {
        IList<Company> GetCompanies();
        Company GetCompanyById(int? id);
        void InsertNew(Company company);
        void Update(Company company);
        void Delete(Company company);
    }
}
