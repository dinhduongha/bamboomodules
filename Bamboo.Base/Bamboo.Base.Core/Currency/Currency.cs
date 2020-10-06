using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;

using Abp.Domain.Entities.Auditing;

using Bamboo.Common;
using Bamboo.Base.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bamboo.Base.Core
{
    public class Currency : FullAuditedEntity<long>, IMustHaveTenant, IExtraData, IPassivable
    { 
        public int TenantId { get; set; }
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

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
        public CurrencyExtraData ExtraData { get; set; }
#else
        [NotMapped]
        public CurrencyExtraData ExtraData { get; set; }
#endif
    }

}