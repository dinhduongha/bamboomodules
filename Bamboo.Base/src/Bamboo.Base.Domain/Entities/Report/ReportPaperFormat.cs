using Bamboo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class ReportPaperFormat : FullAuditedAggregateRoot<long>, IHasExtraProperties
    { 
        public ReportPaperFormat()
        {

        }
        public ReportPaperFormat(long id)
            :base(id)
        {

        }
        //public Guid? TenantId { get; set; }

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Format { get; set; }

        public double MarginTop { get; set; }

        public double MarginBottom { get; set; }

        public double MarginLeft { get; set; }

        public double MarginRight { get; set; }

        public double PapeHeight { get; set; }

        public double PapeWidth { get; set; }

        public string Orientation { get; set; }

        public bool HeaderLine { get; set; }

        public double HeaderSpacing { get; set; }

        public int Dpi { get; set; }

        //[Column(TypeName = "jsonb")]
        //public PartnerTitleExtraData ExtraData { get; set; }
#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}