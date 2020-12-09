using Bamboo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    /// <summary>
    /// res_partner_bank
    /// </summary>
    public class PartnerBank : FullAuditedAggregateRoot<Guid>, IMultiTenant, IHasExtraProperties
    {
        protected PartnerBank() { }
        public PartnerBank(Guid id)
            : base(id) { }

        public Guid? TenantId { get; set; }

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public bool IsActive { get; set; }
       
        public string Name { get; set; } // Account holder name

        public string AccountNumber { get; set; }

        public string SanitizedAccountNumber { get; set; }

        public string AccountType { get; set; }

        public Guid PartnerId { get; set; }

        [NotMapped]
        [ForeignKey("PartnerId")]
        public Partner Partner { get; set; }

        public Guid BankId { get; set; }

        [NotMapped]
        public string BankName { get; set; }
        [NotMapped]
        public string BankBIC { get; set; }

        public long CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        [NotMapped]
        public Currency Currency { get; set; }

        public string Description { get; set; }

        //[Column(TypeName = "jsonb")]
        //public BankAccountExtraData ExtraData { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }

    }
}