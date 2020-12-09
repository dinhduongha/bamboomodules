using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class Country : FullAuditedEntity<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        
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

        //[Column(TypeName = "jsonb")]
        //public CountryExtraData ExtraData { get; set; }
        public byte[] Image { get; set; }
    }

}