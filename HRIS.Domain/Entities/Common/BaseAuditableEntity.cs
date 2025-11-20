/*
 * 
 * File: BaseAuditableEntity.cs
 * 
 * Summary:
 * This file defines the BaseAuditableEntity class, which serves as a base class for entities that require auditing features.
 * 
 * Important Notes:
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
        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public Guid? UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
