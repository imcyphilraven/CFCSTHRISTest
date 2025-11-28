namespace HRIS.WebAPI.Contracts.Employee
{
    public class UpdateEmployeeRequest
    {
        public Guid EmployeeID { get; set; }
        public string EmploymentID { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? ExtensionName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = null!;
        public char SexAtBirth { get; set; }
        public int CivilStatusID { get; set; }      // FK
        public bool IsFilipino { get; set; }
        public bool IsDualCitizen { get; set; }
        public string? ImageSource { get; set; }
    }
}
