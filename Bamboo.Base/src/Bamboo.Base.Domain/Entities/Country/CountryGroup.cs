using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Common;

namespace Bamboo.Base.Entities
{
    /// <summary>
    /// res_country_group_rel
    /// </summary>
    public class CountryGroupRel: Entity,IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public long CountryId { get; set; }
        public Guid GroupId { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { GroupId, CountryId };
        }

    }

    /// <summary>
    /// res_country_group
    /// </summary>
    public class CountryGroup : FullAuditedAggregateRoot<Guid>, IMultiTenant, IHasExtraProperties    
    {
        public CountryGroup(Guid id): base(id) 
        { 
            CountryGroupRel = new List<CountryGroupRel>(); 
        }
        protected CountryGroup() { }
        public Guid? TenantId {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        //[NotMapped]
        public ICollection<CountryGroupRel> CountryGroupRel { get; set; }
        public void AddToGroup(Country country)
        {
            CountryGroupRel.Add(new CountryGroupRel() { CountryId = country.Id, GroupId = this.Id });
        }
#if HAS_DB_POSTGRESQL
        [Column(TypeName = "jsonb")]
#endif
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}