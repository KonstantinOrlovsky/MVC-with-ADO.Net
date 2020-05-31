using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    //Методы предназначены для получения экземпляра работника по id либо списка работников из репозитория в DataAccessLayer.
    //Отправки данных полей экземпляра работника в репозиторий для последующего создания, изменения и удаления.
    public interface IEmployeeService
    {
        IList<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployeeById(int? id);
        void InsertNew(EmployeeDTO employee);
        void Update(EmployeeDTO employee);
        void Delete(EmployeeDTO employee);
    }
}
