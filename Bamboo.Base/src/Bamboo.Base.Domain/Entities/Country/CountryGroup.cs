using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Bamboo.Common;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    public class CountryGroup : FullAuditedEntity<Guid>, IMultiTenant    {
        public Guid? TenantId {get; set;}
        public string Name { get; set; }
    }
}