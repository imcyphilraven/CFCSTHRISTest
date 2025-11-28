using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities.Domain.HRIS;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Repositories.HRIS
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRISDbContext _context;

        public EmployeeRepository(HRISDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken)
        { 
            return await _context.Employees
                    .Include(e => e.CivilStatus)
                    .FirstOrDefaultAsync(e => e.EmployeeID == employeeId, cancellationToken);
        }

        public async Task<IReadOnlyCollection<Employee>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(e => e.CivilStatus)
                .Where(e => e.IsActive)
                .ToListAsync(cancellationToken);
        }

        public async Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }

        public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            // This is temporary, replace "system" with actual user
            employee.MarkUpdated("system");

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // Delete operation (permanent: Don't Use)
        public async Task DeleteAsync(Employee employee, CancellationToken cancellationToken)
        { 
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // Delete Operation - Soft Delete
        public async Task SoftDeleteAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            // This is temporary, replace "system" with actual user
            employee.SoftDelete("system");

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // Filtering , Sorting, and Pagination
        public async Task<(IReadOnlyCollection<Employee> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            bool? isActive,
            string? sortBy,
            bool isDescending,
            CancellationToken cancellationToken)
        {
            var query = _context.Employees
                .Include(e => e.CivilStatus)
                .AsQueryable();


            // Filtering

            // active/inactive/all
            if (isActive.HasValue)
            {
                query = query.Where(e => e.IsActive == isActive.Value);
            }
            // search term
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(e =>
                    e.FirstName.Contains(searchTerm) ||
                    e.LastName.Contains(searchTerm) ||
                    e.EmploymentID.Contains(searchTerm));
            }

            // Total Count before Pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                query = sortBy.ToLower() switch
                {
                    "employmentid" => isDescending 
                        ? query.OrderByDescending(e => e.EmploymentID) 
                        : query.OrderBy(e => e.EmploymentID),
                    

                    "lastname" => isDescending ? query.OrderByDescending(e => e.LastName) : query.OrderBy(e => e.LastName),

                    _ => query.OrderBy(e => e.LastName), // Default sorting
                };
            }
            
            // Pagination
            var skip = (pageNumber - 1) * pageSize;
            var items = await query
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync(cancellationToken);


            return (items.AsReadOnly(), totalCount);
        }

    }
}
