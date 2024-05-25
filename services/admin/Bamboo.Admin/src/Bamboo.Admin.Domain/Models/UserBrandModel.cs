using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Bamboo.Admin;

[Table("AbpUsers")]
public class UserBrandModel: Entity<Guid>
{
    public Guid? BrandId { get; set;}
}