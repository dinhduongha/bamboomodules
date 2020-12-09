using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

using Bamboo.Common;

namespace Bamboo.Base.Entities
{
    public class Bank : FullAuditedAggregateRoot<Guid>, IMultiTenant, IHasExtraProperties
    {
        protected Bank() { }
        public Bank(Guid id)
            : base(id) { }

        public Guid? TenantId { get; set; }

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public string Name { get; set; }

        public string SortName { get; set; }

        public string LongName { get; set; }

        public string Street { get; set; }

        public string Street2 { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public string BIC { get; set; }

        public string Description { get; set; }

        //[Column(TypeName = "jsonb")]
        //public BankExtraData ExtraData { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}