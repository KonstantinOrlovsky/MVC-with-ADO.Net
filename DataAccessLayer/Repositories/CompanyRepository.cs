using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;

        public IList<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_ReadCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var company = new Company();
                    company.Id = rdr.GetInt32(0);
                    company.Name = rdr.GetString(1);
                    company.Prefix = rdr.GetString(2);
                    company.Count = rdr.GetInt32(3);
                    companies.Add(company);
                }
                con.Close();

                return (companies);
            }
        }

        public Company GetCompanyById(int? id)
        {
            var company = new Company();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_GetCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                company.Id = rdr.GetInt32(0);
                company.Name = rdr.GetString(1);
                company.Prefix = rdr.GetString(2);
                company.Count = rdr.GetInt32(3);
                con.Close();

                return company;
            }
        }

        public void InsertNew(Company company)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("sp_CreateCompany", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prefix", company.Prefix);
                cmd.Parameters.AddWithValue("@name", company.Name);
                cmd.Parameters.AddWithValue("@count", company.Count.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Company company)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("sp_EditCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Id", company.Id.ToString());
                cmd.Parameters.AddWithValue("@name", company.Name);
                cmd.Parameters.AddWithValue("@prefix", company.Prefix);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(Company company)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("sp_DeleteCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Id", company.Id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

