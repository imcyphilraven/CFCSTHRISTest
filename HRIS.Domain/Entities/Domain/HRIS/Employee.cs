using HRIS.Domain.Entities.Common;
using HRIS.Domain.Entities.Domain.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities.Domain.HRIS
{
    public class Employee : BaseAuditableEntity
    {
        public Guid EmployeeID { get; set; }
        public string EmploymentID { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ExtensionName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
        public string SexAtBirth { get; set; } = null!;

        public int CivilStatusID { get; set; }      // FK
        public bool IsFilipino { get; set; }
        public bool IsDualCitizen { get; set; }
        public string ImageSource { get; set; } = string.Empty;


        // Navigation Properties
        public CivilStatus? CivilStatus { get; set; }
        public ICollection<EmployeeIdentification> EmployeeIdentifications { get; set; } = new List<EmployeeIdentification>();

    }
}
