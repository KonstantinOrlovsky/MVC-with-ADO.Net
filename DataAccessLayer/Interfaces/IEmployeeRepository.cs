using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    //Методы предназначены для получения экземпляра работника по id либо списка работников из базы данных.
    //Отправки данных полей экземпляра работника в базу данных для последующего создания, изменения и удаления записи в таблице Employees
    public interface IEmployeeRepository
    {
        IList<Employee> GetEmployees();
        Employee GetEmployeeById(int? id);
        void InsertNew(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
