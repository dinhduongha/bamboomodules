using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


using Bamboo.Common;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class CountryState : FullAuditedAggregateRoot<Guid>, IMultiTenant, IHasExtraProperties
    {
        public CountryState(Guid id): base(id) { }
        protected CountryState() { }

        public Guid? TenantId {get; set;}
        public string Name { get; set; }
        public string Code { get; set; }
        public long CountryId { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }

}