using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("res_groups_users_rel")]
public partial class ResGroupsUsersRel: Entity
{

    [Column("gid")]
    public Guid GroupId { get ; set ; }

    [Column("uid")]
    public Guid UserId { get; set; }
    public override object[] GetKeys()
    {
        return new object[] { GroupId, UserId };
    }
}
