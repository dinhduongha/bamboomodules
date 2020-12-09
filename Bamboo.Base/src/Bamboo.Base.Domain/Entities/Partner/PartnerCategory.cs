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
    public class PartnerCategoryRel : Entity, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public long CategoryId { get; set; }
        public Guid PartnerId { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { CategoryId, PartnerId };
        }

    }

    public class PartnerCategory : FullAuditedAggregateRoot<Guid>, IMultiTenant, IHasExtraProperties
    {
        public PartnerCategory(Guid id)
            :base(id)
        {
            PartnerCategoryRels = new List<PartnerCategoryRel>();
        }

        protected PartnerCategory() 
        {
            PartnerCategoryRels = new List<PartnerCategoryRel>();
        }

        public Guid? TenantId { get; set; }

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public string Name { get; set; }
        public long Color { get; set; }
        public Guid? ParentId { get; set; }
        public bool IsActive { get; set; }

        public string ParentPath { get; set; }

        //[Column(TypeName = "jsonb")]
        //public PartnerCategoryExtraData ExtraData { get; set; }

        public ICollection<PartnerCategoryRel> PartnerCategoryRels { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}