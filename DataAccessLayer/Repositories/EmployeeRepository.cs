using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;

        public IList<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_ReadEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var employee = new Employee()
                    {
                        Company = new Company(),
                        IdEmployee = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Surname = rdr.GetString(2),
                        Patronymic = rdr.GetString(3),
                        Date = rdr.GetString(4),
                        Post = rdr.GetString(5)
                    };
                    employee.Company.Name = rdr.GetString(7);
                    employees.Add(employee);
                }
                con.Close();

                return (employees);
            }
        } 

        public Employee GetEmployeeById(int? id)
        {
            Employee employee = new Employee();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_GetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                employee.Company = new Company();
                employee.IdEmployee = rdr.GetInt32(0);
                employee.Name = rdr.GetString(1);
                employee.Surname = rdr.GetString(2);
                employee.Patronymic = rdr.GetString(3);
                employee.Date = rdr.GetString(4);
                employee.Post = rdr.GetString(5);
                employee.Company.Name = rdr.GetString(7);
                con.Close();

                return employee;
            }
        }

        public void InsertNew(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("sp_CreateEmployee", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@surname", employee.Surname);
                cmd.Parameters.AddWithValue("@patronymic", employee.Patronymic);
                cmd.Parameters.AddWithValue("@date", employee.Date);
                cmd.Parameters.AddWithValue("@post", employee.Post);
                cmd.Parameters.AddWithValue("@companyId", employee.CompanyId.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("sp_EditEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@idEmployee", employee.IdEmployee);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@surname", employee.Surname);
                cmd.Parameters.AddWithValue("@patronymic", employee.Patronymic);
                cmd.Parameters.AddWithValue("@date", employee.Date);
                cmd.Parameters.AddWithValue("@post", employee.Post);
                cmd.Parameters.AddWithValue("@companyId", employee.CompanyId.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Id", employee.IdEmployee);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
