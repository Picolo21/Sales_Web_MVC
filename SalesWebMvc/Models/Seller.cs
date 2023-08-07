using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [EmailAddress(ErrorMessage = "Enter a valid {0}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Range(100, 50000, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        public double BaseSalary { get; set; }

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