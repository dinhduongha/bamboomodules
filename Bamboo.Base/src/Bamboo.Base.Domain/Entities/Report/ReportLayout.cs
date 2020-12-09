using Bamboo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class ReportLayout : FullAuditedAggregateRoot<long>, IHasExtraProperties
    { 
        public ReportLayout()
        {

        }
        public ReportLayout(long id)
            :base(id)
        {

        }
        //public Guid? TenantId { get; set; }

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public string ViewId { get; set; }

        public string Image { get; set; } // Image Url
        public string Pdf { get; set; } // Pdf Url

        public string Name { get; set; } // Image Url

        public string Description { get; set; } // Image Url

        //[Column(TypeName = "jsonb")]
        //public PartnerTitleExtraData ExtraData { get; set; }
#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}