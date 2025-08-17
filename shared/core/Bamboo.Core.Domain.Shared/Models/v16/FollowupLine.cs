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

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

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
    [ForeignKey("FollowupLineId")]
    [InverseProperty("FollowupLine")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("FollowupLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EmailTemplateId")]
    // [InverseProperty("FollowupLine")] //Many2one
    public virtual MailTemplate? EmailTemplate { get; set; }

    // [Many2one]
    [ForeignKey("FollowupId")]
    // [InverseProperty("FollowupLine")] //Many2one
    public virtual FollowupFollowup? Followup { get; set; }

    // [Many2one]
    [ForeignKey("ManualActionResponsibleId")]
    // [InverseProperty("FollowupLineManualActionResponsible")] //Many2one
    public virtual ResUsers? ManualActionResponsible { get; set; }

    // [One2many]
    [ForeignKey("LatestFollowupLevelIdWithoutLit")]
    [InverseProperty("LatestFollowupLevelIdWithoutLitNavigation")]
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("FollowupLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
