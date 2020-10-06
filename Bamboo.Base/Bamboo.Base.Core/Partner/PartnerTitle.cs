using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

using Bamboo.Common;
using Bamboo.Base.Shared;

namespace Bamboo.Base.Core
{
    public class PartnerTitle : FullAuditedEntity<Guid>, IMustHaveTenant, IExtraData
    { 
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
        public PartnerTitleExtraData ExtraData { get; set; }
#else
        [NotMapped]
        public PartnerTitleExtraData ExtraData { get; set; }
#endif
    }
}