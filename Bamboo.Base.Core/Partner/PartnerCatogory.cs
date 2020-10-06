using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

using Bamboo.Common;
using Bamboo.Base.Shared;

namespace Bamboo.Base.Core
{
    public class PartnerCategory : FullAuditedEntity<Guid>, IMustHaveTenant, IExtraData, IPassivable
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Parent { get; set; }

        public bool IsActive { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
        public PartnerCategoryExtraData ExtraData { get; set; }
#else
        [NotMapped]
        public PartnerCategoryExtraData ExtraData { get; set; }
#endif

        [NotMapped]
        public ICollection<PartnerCategory> Children { get; set; }

        [NotMapped]
        public ICollection<Partner> Partners { get; set; }
    }
}