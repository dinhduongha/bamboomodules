using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


using Bamboo.Common;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class CountryState : FullAuditedEntity<Guid>, IMultiTenant, IHasExtraProperties
    {
        public Guid? TenantId {get; set;}
        public string Name { get; set; }
        public string Code { get; set; }
        public long CountryId { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "jsonb")]
        public ExtraPropertyDictionary ExtraProperties { get; }
    }

}