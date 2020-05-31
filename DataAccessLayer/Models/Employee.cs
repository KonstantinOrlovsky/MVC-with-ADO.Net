namespace DataAccessLayer
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Date { get ; set; }
        public string Post { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }

}



