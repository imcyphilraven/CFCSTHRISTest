/*
 * 
 * File: BaseAuditableEntity.cs
 * 
 * Summary:
 * This file defines the BaseAuditableEntity class, which serves as a base class for entities that require auditing features.
 * 
 * Important Notes:
 *   - The class inherits from BaseEntity, which is assumed to provide a unique identifier for entities.
 *   - The class includes properties for tracking creation, update, and deletion metadata.
 *   - The IsActive property indicates whether the entity is currently active.
 * 
 * 
 * Change Log:
 * Date         Author                  Description
 * 2025-11-19   Cyphil Raven Midsapak   Initial creation of the BaseAuditableEntity class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTimeOffset CreatedDate{ get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        public DateTimeOffset? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }

        public DateTimeOffset? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
