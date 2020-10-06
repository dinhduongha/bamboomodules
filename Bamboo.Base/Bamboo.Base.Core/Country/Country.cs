using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

using Bamboo.Common;
using Bamboo.Base.Shared;

namespace Bamboo.Base.Core
{
    public class Country : FullAuditedEntity<long>, IMustHaveTenant, IExtraData, IPassivable
    {
        public int TenantId { get; set; }
        
        public string Name { get; set; }
        
        public string Code { get; set; }
        
        public string AddressFormat { get; set; }

        public string AddressViewId { get; set; }

        public long CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        public bool IsActive { get; set; }
        public string PhoneCode { get; set; }

        public bool NamePosition { get; set; }

        public string VATLabel { get; set; }

        public long CountryGroupId { get; set; }
        [NotMapped]
        public CountryGroup CountryGroup { get; set; }

        [ForeignKey("CountryId")]
        [NotMapped]
        public ICollection<CountryState> CountryStates { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
        public CountryExtraData ExtraData { get; set; }
#else
        [NotMapped]
        public CountryExtraData ExtraData { get; set; }
#endif
        public byte[] Image { get; set; }
    }

}