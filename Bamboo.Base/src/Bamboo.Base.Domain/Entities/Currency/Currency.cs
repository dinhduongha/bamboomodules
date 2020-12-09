using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Bamboo.Common;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class Currency : FullAuditedEntity<Guid>, IMultiTenant, IHasExtraProperties
    { 
        public Currency()
            :base(CoreUtils.NewGuid())
        {

        }
        public Currency(Guid id)
            :base(id)
        {

        }
        public Guid? TenantId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
        public long Sequence { get; set; }


        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Rate { get; set; }

        [NotMapped]
        [ForeignKey("CurrencyId")]
        public ICollection<CurrencyRate> Rates { get; set; }

        public double Rounding { get; set; }
        public int DecimalPlaces { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }

        public DateTimeOffset Date { get; set; }

        //[Column(TypeName = "jsonb")]
        //public CurrencyExtraData ExtraData { get; set; }
        [Column(TypeName = "jsonb")]
        public ExtraPropertyDictionary ExtraProperties { get; }
    }

}