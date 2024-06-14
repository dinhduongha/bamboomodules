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

[Table("crm_team_member")]
//[Index("CrmTeamId", Name = "crm_team_member_crm_team_id_index")]
//[Index("UserId", Name = "crm_team_member_user_id_index")]
public partial class CrmTeamMember: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("crm_team_id")]
    public Guid? CrmTeamId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("assignment_max")]
    public long? AssignmentMax { get; set; }

    [Column("assignment_domain")]
    public string? AssignmentDomain { get; set; }

    [Column("assignment_optout")]
    public bool? AssignmentOptout { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmTeamMemberCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CrmTeamId")]
    //[InverseProperty("CrmTeamMembers")]
    [NotMapped]
    public virtual CrmTeam? CrmTeam { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("CrmTeamMembers")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("CrmTeamMemberUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmTeamMemberWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
