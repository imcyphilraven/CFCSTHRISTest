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
        public DateTimeOffset CreatedDate{ get;  set; }
        public string CreatedBy { get;  set; } = null!;

        public DateTimeOffset? UpdatedDate { get;  set; }
        public string? UpdatedBy { get;  set; }

        public DateTimeOffset? DeletedDate { get;   set; }
        public string? DeletedBy { get;  set; }

        public string? DeletedReason { get;  set; }

        public bool IsActive { get;  set; } = true;


        public void SoftDelete(string? user = null, string? reason = null)
        {
            IsActive = false;
            DeletedBy = user;
            DeletedDate = DateTimeOffset.UtcNow;
            DeletedReason = reason;

            MarkUpdated(user);
        }

        public void MarkUpdated(string? user = null)
        {
            UpdatedBy = user;
            UpdatedDate = DateTimeOffset.UtcNow;
        }

        public void Reactivate(string? user = null)
        {
            IsActive = true;
            DeletedBy = user;
            DeletedDate = DateTimeOffset.UtcNow;

            MarkUpdated(user);
        }
    }
}
