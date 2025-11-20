using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities.Domain
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string EmploymentID { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string ExtensionName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = string.Empty;      // FK

        public int CivilStatus { get; set; }

        public bool IsFilipino { get; set; }
        public bool IsDualCitizen { get; set; }
        public string ImageSource { get; set; } = string.Empty;



    }
}
