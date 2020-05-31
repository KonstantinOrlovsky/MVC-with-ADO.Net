using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Infrastructure
{
    class ServiceModule
    {
        public List<CompanyDTO> ConvertToCompanyDTOList(IList<Company> list)
        {
            return list.Select((company) => new CompanyDTO() { Id = company.Id, Name = company.Name, Prefix = company.Prefix, Count = company.Count }).ToList();
        }

        public List<EmployeeDTO> ConvertToEmployeeDTOList(IList<Employee> list)
        {
            var companyDTO = new CompanyDTO();
            return list.Select((employee) => new EmployeeDTO() {
                IdEmployee = employee.IdEmployee,
                Name = employee.Name,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Date = employee.Date,
                Post = employee.Post,
                Company = ConvertToCompanyDTO(employee.Company)
            }).ToList();
        }

        public Company ConvertToCompany(CompanyDTO companyDTO)
        {
            var company = new Company();

            company.Id = companyDTO.Id;
            company.Name = companyDTO.Name;
            company.Prefix = companyDTO.Prefix;
            company.Count = companyDTO.Count;

            return company;
        }

        public Employee ConvertToEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee();

            employee.IdEmployee = employeeDTO.IdEmployee;
            employee.Name = employeeDTO.Name;
            employee.Surname = employeeDTO.Surname;
            employee.Patronymic = employeeDTO.Patronymic;
            employee.Date = employeeDTO.Date;
            employee.Post = employeeDTO.Post;
            employee.CompanyId = employeeDTO.CompanyId;

            return employee;
        }

        public CompanyDTO ConvertToCompanyDTO(Company company)
        {
            var companyDTO = new CompanyDTO();

            companyDTO.Id = company.Id;
            companyDTO.Name = company.Name;
            companyDTO.Prefix = company.Prefix;
            companyDTO.Count = company.Count;

            return companyDTO;
        }

        public EmployeeDTO ConvertToEmployeeDTO(Employee employee)
        {
            var employeeDTO = new EmployeeDTO();
            employeeDTO.Company = new CompanyDTO();

            employeeDTO.IdEmployee = employee.IdEmployee;
            employeeDTO.Name = employee.Name;
            employeeDTO.Surname = employee.Surname;
            employeeDTO.Patronymic = employee.Patronymic;
            employeeDTO.Date = employee.Date;
            employeeDTO.Post = employee.Post;
            employeeDTO.CompanyId = employee.CompanyId;
            employeeDTO.Company.Name = employee.Company.Name;

            return employeeDTO;
        }
    }
}
