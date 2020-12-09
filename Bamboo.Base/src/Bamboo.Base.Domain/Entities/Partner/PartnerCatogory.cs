using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Data;
using Bamboo.Common;

namespace Bamboo.Base.Entities
{
    public class PartnerCategory : FullAuditedEntity<Guid>, IMultiTenant, IHasExtraProperties
    {
        public PartnerCategory()
            :base(CoreUtils.NewGuid())
        {
        }
        public Guid? TenantId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
        public long Sequence { get; set; }


        public string Name { get; set; }
        public string Color { get; set; }
        public string Parent { get; set; }
        public bool IsActive { get; set; }
        

        //[Column(TypeName = "jsonb")]
        //public PartnerCategoryExtraData ExtraData { get; set; }

        [NotMapped]
        public ICollection<PartnerCategory> Children { get; set; }

        [NotMapped]
        public ICollection<Partner> Partners { get; set; }

        [Column(TypeName = "jsonb")]
        public ExtraPropertyDictionary ExtraProperties { get; }
    }
}