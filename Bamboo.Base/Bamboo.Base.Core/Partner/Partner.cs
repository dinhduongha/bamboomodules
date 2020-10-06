using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

using Bamboo.Common;
using Bamboo.Base.Shared;

namespace Bamboo.Base.Core
{

    public class Partner : FullAuditedEntity<Guid>, IMustHaveTenant, IExtraData, IPassivable
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public Guid? Parent { get; set; }
        public string ParentName { get; set; }


        public string Ref { get; set; }

        public long LanguageId { get; set; }

        public int ActiveLangCount { get; set; }

        public string TZ { get; set; }

        public string TZOffset { get; set; }

        public long User { get; set; }

        public string VAT { get; set; }

        public string SameVATPartner { get; set; }

        public string Website { get; set; }

        public string Comment { get; set; }

        public double CreditLimit { get; set; }

        public string Barcode { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsEmployee { get; set; } = true;

        public string Function { get; set; }

        public string Type { get; set; }

        public string Street { get; set; }

        public string Street2 { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public Guid? StateId { get; set; }

        public Guid? CountryId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Email { get; set; }

        public string EmailFormatted { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public bool IsCompany { get; set; }

        public Guid? Industry { get; set; }

        public int CompanyTypeId { get; set; }

        public int CompanyId { get; set; }

        public string Color { get; set; }

        [NotMapped]
        public ICollection<long> Users { get; set; }

        public bool PartnerShare { get; set; }

        public string ContactAddress { get; set; }

        public Guid? CommercialPartner { get; set; }

        public string CommercialCompanyName { get; set; }

        public string CompanyName { get; set; }

        public byte[] Image { get; set; }

        public byte[] ImageMedium { get; set; }

        public byte[] ImageSmall { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
        public PartnerExtraData ExtraData { get; set; }
#else
        [NotMapped]
        public PartnerExtraData ExtraData { get; set; }
#endif

        [NotMapped]
        public ICollection<Partner> Children { get; set; }

        [NotMapped]
        public ICollection<Bank> Banks { get; set; }

        [NotMapped]
        public ICollection<PartnerCategory> Categories { get; set; }
    }
}