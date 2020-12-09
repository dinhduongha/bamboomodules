using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Common;

namespace Bamboo.Base.Entities
{

    public class PartnerIndustry : FullAuditedAggregateRoot<long>, IHasExtraProperties
    {
        public PartnerIndustry(long id)
            :base(id)
        {
        }

        protected PartnerIndustry() 
        {
        }

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}