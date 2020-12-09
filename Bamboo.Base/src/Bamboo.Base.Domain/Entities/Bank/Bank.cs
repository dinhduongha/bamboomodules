using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Data;

using Bamboo.Common;

namespace Bamboo.Base.Entities
{
    public class Bank : FullAuditedEntity<Guid>, IHasExtraProperties
    {
        public Bank()
            : base(CoreUtils.NewGuid()) { }
        public Bank(Guid id)
            : base(id) { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
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
        public ExtraPropertyDictionary ExtraProperties { get; }
    }
}