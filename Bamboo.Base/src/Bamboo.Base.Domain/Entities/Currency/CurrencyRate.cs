using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


using Bamboo.Common;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class CurrencyRate : FullAuditedEntity<Guid>, IMultiTenant
    {
        public CurrencyRate()
            : base(CoreUtils.NewGuid())
        {

        }
        public CurrencyRate(Guid id)
            :base(id)
        {

        }
        public Guid? TenantId {get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
        public long Sequence { get; set; }


        public long CurrencyId { get; set; }
        public double Rate { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public DateTimeOffset? Date { get; set; }
    }

}