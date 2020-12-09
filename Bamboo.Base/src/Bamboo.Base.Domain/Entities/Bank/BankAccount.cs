using Bamboo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class BankAccount : FullAuditedEntity<Guid>, IMultiTenant, IHasExtraProperties
    {
        public BankAccount()
    : base(CoreUtils.NewGuid()) { }
        public BankAccount(Guid id)
            : base(id) { }

        public Guid? TenantId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
        public long Sequence { get; set; }

        public string AccountType { get; set; }

        public string Name { get; set; }

        public string SanitizedAccountNumber { get; set; }

        public Guid BankId { get; set; }
        public string BankName { get; set; }
        public string BankBIC { get; set; }

        public long CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        public Guid? PartnerId { get; set; }

        [ForeignKey("PartnerId")]
        public Partner Partner { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        //[Column(TypeName = "jsonb")]
        //public BankAccountExtraData ExtraData { get; set; }

        [Column(TypeName = "jsonb")]
        public ExtraPropertyDictionary ExtraProperties { get; }

    }
}