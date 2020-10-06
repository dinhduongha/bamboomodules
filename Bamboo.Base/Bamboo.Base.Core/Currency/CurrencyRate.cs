using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;

using Abp.Domain.Entities.Auditing;

using Bamboo.Common;
using Bamboo.Base.Shared;

namespace Bamboo.Base.Core
{
    public class CurrencyRate : FullAuditedEntity<Guid>, IMustHaveTenant, IExtraData, IPassivable
    {
        public int TenantId {get; set;}
        public long CurrencyId { get; set; }
        public double Rate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Date { get; set; }
    }

}