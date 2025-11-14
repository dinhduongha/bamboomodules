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

[Table("followup_line")]
//[Index("FollowupId", "Delay", Name = "followup_line_days_uniq", IsUnique = true)]
public partial class FollowupLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("followup_id")]
    public Guid? FollowupId { get; set; }

    [Column("delay")]
    public long? Delay { get; set; }

    [Column("manual_action_responsible_id")]
    public Guid? ManualActionResponsibleId { get; set; }

    [Column("email_template_id")]
    public Guid? EmailTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [JsonField(IsSparse = false)] // Description
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [Column("manual_action_note")]
    public string? ManualActionNote { get; set; }

    [Column("send_email")]
    public bool? SendEmail { get; set; }

    [Column("send_letter")]
    public bool? SendLetter { get; set; }

    [Column("manual_action")]
    public bool? ManualAction { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("FollowupLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FollowupLine")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EmailTemplateId")]
    public virtual MailTemplate? EmailTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FollowupId")]
    public virtual FollowupFollowup? Followup { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ManualActionResponsibleId")]
    public virtual ResUsers? ManualActionResponsible { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
