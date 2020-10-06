using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;

using Abp.Domain.Entities.Auditing;

using Bamboo.Common;
using Bamboo.Base.Shared;

namespace Bamboo.Base.Core
{
    public class CountryGroup : FullAuditedEntity<long>, IMustHaveTenant, IExtraData
    {
        public int TenantId {get; set;}
        public string Name { get; set; }
    }
}