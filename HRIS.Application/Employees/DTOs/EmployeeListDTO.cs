/*
 * File: EmployeeListDTO.cs
 
 * Summary:
     * This file contains the definition of the EmployeeListDTO class, which is a Data Transfer Object (DTO)
     * This will be used for data transfer related to employee listings.
     * 
     
 * Important Notes:
     * Aligned with the PageResults.
     * Nullable properties are indicated with '?' to handle optional data.
     
 * Change Log: 2025-11-28 - @imcyphilraven - Created file and defined EmployeeListDTO class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.DTOs
{
    public class EmployeeListDTO
    {
        public Guid EmployeeId { get; set; }
        public string EmploymentId { get; set; } = null!;
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
