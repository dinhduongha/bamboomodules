using Bamboo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class Partner : FullAuditedAggregateRoot<Guid>, IMultiTenant, IHasExtraProperties
    {
        protected Partner()
        {

        }
        public Partner(Guid id)
            :base(id)
        {

        }

        public Guid? TenantId { get; set; }

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public string Name { get; set; }
        public string DisplayName { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Title { get; set; }

        public Guid? ParentId { get; set; }
        public string ParentName { get; set; }

        public string Ref { get; set; }

        public long LanguageId { get; set; }
        public string Tz { get; set; }

        public int ActiveLangCount { get; set; }

        public string TZOffset { get; set; }

        public Guid? UserId { get; set; }

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

        public long? CountryId { get; set; }

        public double PartnerLatitude { get; set; }

        public double PartnerLongitude { get; set; }

        public string Email { get; set; }

        public string EmailFormatted { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public bool IsCompany { get; set; }

        public long? Industry { get; set; }

        public int CompanyTypeId { get; set; }

        public Guid? CompanyId { get; set; }

        public long Color { get; set; }

        [NotMapped]
        public ICollection<Guid> Users { get; set; }

        public bool PartnerShare { get; set; }

        public string ContactAddress { get; set; }

        public Guid? CommercialPartner { get; set; }

        public string CommercialCompanyName { get; set; }

        public string CompanyName { get; set; }

        public byte[] Image { get; set; }

        public byte[] ImageMedium { get; set; }

        public byte[] ImageSmall { get; set; }

        //[Column(TypeName = "jsonb")]
        //public PartnerExtraData ExtraData { get; set; }

        [NotMapped]
        public ICollection<Partner> Children { get; set; }

        [NotMapped]
        public ICollection<Bank> Banks { get; set; }

        [NotMapped]
        public ICollection<PartnerCategory> Categories { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}