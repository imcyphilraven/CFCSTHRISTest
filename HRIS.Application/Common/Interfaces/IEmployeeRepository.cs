using HRIS.Domain.Entities.Domain.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        
        // READ
        Task<Employee?> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<Employee>> GetAllAsync(CancellationToken cancellationToken);


        // WRITE
        Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken);
        Task UpdateAsync(Employee employee, CancellationToken cancellationToken);
        Task DeleteAsync(Employee employee, CancellationToken cancellationToken);

        Task SoftDeleteAsync(Employee employee, CancellationToken cancellationToken);


        // Additional methods can be added as needed
        // Paged Methods:
        Task<(IReadOnlyCollection<Employee> Items, int TotalCount)> GetPagedAsync(
            int pageNumber, 
            int pageSize, 
            string? searchTerm,
            bool? isActive,
            string? sortBy,
            bool isDescending,
            CancellationToken cancellationToken
        );

        Task<Employee?> GetEmployeeByIDIncludingInactiveAsync(
            Guid employeeID,
            CancellationToken cancellationToken
        );
        
    }
}
