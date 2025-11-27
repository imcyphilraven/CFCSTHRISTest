using MediatR;

namespace HRIS.Application.Employees.Commands.CreateEmployee
{
    // Returns the new EmployeeId (Guid) after creating
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string EmploymentId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? ExtensionName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = null!;
        public char SexAtBirth { get; set; }
        public int CivilStatusId { get; set; }
        public bool IsFilipino { get; set; }
        public bool IsDualCitizen { get; set; }
        public string? ImageSource { get; set; }
    }
}
