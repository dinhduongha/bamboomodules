using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

using Bamboo.Common;
using Bamboo.Base.Shared;

namespace Bamboo.Base.Core
{
    public class BankAccount : FullAuditedEntity<Guid>, IMustHaveTenant, IExtraData, IPassivable
    {
        public override Guid Id { get; set; }

        public int TenantId {get; set;}

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

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
        public BankAccountExtraData ExtraData { get; set; }
#else
        [NotMapped]
        public BankAccountExtraData ExtraData { get; set; }

        [Column("ExtraData")]
        public string Extra {get;set;}
#endif
    }
}