using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    /// <summary>
    /// res_country
    /// </summary>
    public class Country : FullAuditedAggregateRoot<long>, IMultiTenant, IHasExtraProperties
    {
        public Guid? TenantId { get; set; }
        
        public string Name { get; set; }
        
        public string Code { get; set; }
        
        public string AddressFormat { get; set; }

        public Guid? AddressViewId { get; set; }

        public long CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        [NotMapped]
        public Currency Currency { get; set; }

        public string PhoneCode { get; set; }

        public bool NamePosition { get; set; }

        public string VATLabel { get; set; }

        public bool StateRequired { get; set; }

        public bool ZipRequired { get; set; }

        public long CountryGroupId { get; set; }
        [NotMapped]
        public CountryGroup CountryGroup { get; set; }

        //[ForeignKey("CountryStateId")]
        [NotMapped]
        public ICollection<CountryState> CountryStates { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        //[Column(TypeName = "jsonb")]
        //public CountryExtraData ExtraData { get; set; }
        public byte[] Image { get; set; }
#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }

}