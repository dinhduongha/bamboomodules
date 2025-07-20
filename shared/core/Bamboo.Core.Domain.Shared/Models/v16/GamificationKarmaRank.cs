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

[Table("gamification_karma_rank")]
public partial class GamificationKarmaRank: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("karma_min")]
    public long? KarmaMin { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("description_motivational", TypeName = "jsonb")]
    public string? DescriptionMotivational { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationKarmaRankCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("NextRank")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUserNextRanks { get; set; } = new List<ResUser>();

    //[InverseProperty("Rank")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUserRanks { get; set; } = new List<ResUser>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationKarmaRankWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
