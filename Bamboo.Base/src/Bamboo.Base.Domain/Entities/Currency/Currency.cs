using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Bamboo.Common;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    /// <summary>
    /// res_currency
    /// </summary>
    public class Currency : FullAuditedAggregateRoot<Guid>, IMultiTenant, IHasExtraProperties
    { 
        protected Currency(){}
        public Currency(Guid id)
            :base(id){}
        public Guid? TenantId { get; set; }

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }
        
        public double Rate { get; set; }

        public double Rounding { get; set; }
        
        public int DecimalPlaces { get; set; }
        
        public bool IsActive { get; set; }
        
        public string Position { get; set; }

        public string CurrencyUnitLabel { get; set; }

        public string CurrencySubUnitLabel { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Description { get; set; }

        //[NotMapped]
        //[ForeignKey("CurrencyId")]
        //public ICollection<CurrencyRate> Rates { get; set; }

        //[Column(TypeName = "jsonb")]
        //public CurrencyExtraData ExtraData { get; set; }
#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }

}