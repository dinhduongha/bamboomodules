using Bamboo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class PartnerTitle : FullAuditedEntity<Guid>, IMultiTenant, IHasExtraProperties
    { 
        public PartnerTitle()
            :base(CoreUtils.NewGuid())
        {

        }
        public PartnerTitle(Guid id)
            :base(id)
        {

        }
        public Guid? TenantId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
        public long Sequence { get; set; }


        public string Name { get; set; }
        public string Shortcut { get; set; }


        //[Column(TypeName = "jsonb")]
        //public PartnerTitleExtraData ExtraData { get; set; }
        [Column(TypeName = "jsonb")]
        public ExtraPropertyDictionary ExtraProperties { get; }
    }
}