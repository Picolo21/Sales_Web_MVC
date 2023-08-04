namespace SalesWebMvc.Models
{
    public class Seller
    {
        public Seller()
        {
        }

        public Seller(
            int id,
            string name,
            string email,
            double baseSalary,
            DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return Sales
                .Where(salesRecord => salesRecord.Date >= initialDate && salesRecord.Date <= finalDate)
                .Sum(salesRecord => salesRecord.Amount);
        }
    }
}