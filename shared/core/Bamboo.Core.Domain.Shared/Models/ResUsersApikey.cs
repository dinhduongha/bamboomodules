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

[Table("res_users_apikeys")]
//[Index("UserId", "Index", Name = "res_users_apikeys_user_id_index_idx")]
public partial class ResUsersApikey: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("scope")]
    public string? Scope { get; set; }

    [Column("index")]
    public string? Index { get; set; }

    [Column("key")]
    public string? Key { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("ResUsersApikeys")]
    [NotMapped]
    public virtual ResUser? User { get; set; }
}
