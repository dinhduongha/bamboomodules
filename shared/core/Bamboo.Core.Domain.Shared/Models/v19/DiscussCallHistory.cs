using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("discuss_call_history")]
//[Index("ChannelId", Name = "discuss_call_history__channel_id_index")]
//[Index("StartCallMessageId", Name = "discuss_call_history__start_call_message_id_index")]
//[Index("StartDt", Name = "discuss_call_history__start_dt_index")]
//[Index("StartCallMessageId", Name = "discuss_call_history_message_id_unique_constraint", IsUnique = true)]
public partial class DiscussCallHistory : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("start_call_message_id")]
    public Guid? StartCallMessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("start_dt", TypeName = "timestamp without time zone")]
    public DateTime? StartDt { get; set; }

    [Column("end_dt", TypeName = "timestamp without time zone")]
    public DateTime? EndDt { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ChannelId")]
    public virtual DiscussChannel? Channel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StartCallMessageId")]
    public virtual MailMessage? StartCallMessage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DiscussCallHistoryId")] // Many2many // Normal
    // [InverseProperty("DiscussCallHistory")] // Many2many // Normal
    public virtual ICollection<ImLivechatChannelMemberHistory> ImLivechatChannelMemberHistory { get; set; }
}
