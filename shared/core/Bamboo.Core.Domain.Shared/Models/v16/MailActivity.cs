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

[Table("mail_activity")]
//[Index("DateDeadline", Name = "mail_activity__date_deadline_index")]
//[Index("ResId", Name = "mail_activity__res_id_index")]
//[Index("ResModelId", Name = "mail_activity__res_model_id_index")]
//[Index("ResModel", Name = "mail_activity__res_model_index")]
//[Index("UserId", Name = "mail_activity__user_id_index")]
public partial class MailActivity: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("activity_type_id")]
    public Guid? ActivityTypeId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("request_partner_id")]
    public Guid? RequestPartnerId { get; set; }

    [Column("recommended_activity_type_id")]
    public Guid? RecommendedActivityTypeId { get; set; }

    [Column("previous_activity_type_id")]
    public Guid? PreviousActivityTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("res_name")]
    public string? ResName { get; set; }

    [Column("summary")]
    public string? Summary { get; set; }

    [Column("user_tz")]
    public string? UserTz { get; set; }

    [Column("date_deadline")]
    public DateTime? DateDeadline { get; set; }

    [Column("date_done")]
    public DateTime? DateDone { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("automated")]
    public bool? Automated { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("calendar_event_id")]
    public Guid? CalendarEventId { get; set; }

    // [Many2one]
    [ForeignKey("ActivityTypeId")]
    public virtual MailActivityType? ActivityType { get; set; }

    // [Many2one]
    [ForeignKey("CalendarEventId")]
    public virtual CalendarEvent? CalendarEvent { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("PreviousActivityTypeId")]
    public virtual MailActivityType? PreviousActivityType { get; set; }

    // [Many2one]
    [ForeignKey("RecommendedActivityTypeId")]
    public virtual MailActivityType? RecommendedActivityType { get; set; }

    // [Many2one]
    [ForeignKey("RequestPartnerId")]
    public virtual ResPartner? RequestPartner { get; set; }

    // [Many2one]
    [ForeignKey("ResModelId")]
    public virtual IrModel? ResModelNavigation { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("ActivityId")] // Many2many // Normal
    // [InverseProperty("Activity")] // Many2many // Normal
    public virtual ICollection<IrAttachment> Attachment { get; set; }
}
