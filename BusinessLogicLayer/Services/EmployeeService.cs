using System.Collections.Generic;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
   public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ServiceModule serviceModule = new ServiceModule();

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        public IList<EmployeeDTO> GetEmployees()
        {
            return serviceModule.ConvertToEmployeeDTOList(employeeRepository.GetEmployees());
        }

        public EmployeeDTO GetEmployeeById(int? id)
        {
            var employee = employeeRepository.GetEmployeeById(id);

            return serviceModule.ConvertToEmployeeDTO(employee);
        }

        public void InsertNew(EmployeeDTO employeeDTO)
        {
            var employee = serviceModule.ConvertToEmployee(employeeDTO);
            employeeRepository.InsertNew(employee);
        }

        public void Update(EmployeeDTO employeeDTO)
        {
            var employee = serviceModule.ConvertToEmployee(employeeDTO);
            employeeRepository.Update(employee);
        }

        public void Delete(EmployeeDTO employeeDTO)
        {
            var employee = serviceModule.ConvertToEmployee(employeeDTO);
            employeeRepository.Delete(employee);
        }
    }
}
