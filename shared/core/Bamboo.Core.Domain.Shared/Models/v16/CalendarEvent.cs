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

[Table("calendar_event")]
//[Index("AccessToken", Name = "calendar_event_access_token_index")]
//[Index("OpportunityId", Name = "calendar_event_opportunity_id_index")]
public partial class CalendarEvent: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("videocall_channel_id")]
    public Guid? VideocallChannelId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("recurrence_id")]
    public Guid? RecurrenceId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("videocall_location")]
    public string? VideocallLocation { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("privacy")]
    public string? Privacy { get; set; }

    [Column("show_as")]
    public string? ShowAs { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("start_date")]
    public DateTime? StartDate { get; set; }

    [Column("stop_date")]
    public DateTime? StopDate { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("allday")]
    public bool? Allday { get; set; }

    [Column("recurrency")]
    public bool? Recurrency { get; set; }

    [Column("follow_recurrence")]
    public bool? FollowRecurrence { get; set; }

    [Column("start", TypeName = "timestamp without time zone")]
    public DateTime? Start { get; set; }

    [Column("stop", TypeName = "timestamp without time zone")]
    public DateTime? Stop { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("opportunity_id")]
    public Guid? OpportunityId { get; set; }

    [Column("applicant_id")]
    public Guid? ApplicantId { get; set; }

    [Column("google_id")]
    public string? GoogleId { get; set; }

    [Column("need_sync")]
    public bool? NeedSync { get; set; }

    [Column("microsoft_id")]
    public string? MicrosoftId { get; set; }

    [Column("microsoft_recurrence_master_id")]
    public string? MicrosoftRecurrenceMasterId { get; set; }

    [Column("need_sync_m")]
    public bool? NeedSyncM { get; set; }

    // [Many2one]
    [ForeignKey("ApplicantId")]
    // [InverseProperty("CalendarEvent")] //Many2one
    public virtual HrApplicant? Applicant { get; set; }

    // [One2many]
    [ForeignKey("EventId")]
    [InverseProperty("Event")]
    public virtual ICollection<CalendarAttendee> CalendarAttendee { get; set; }

    // [One2many]
    [ForeignKey("BaseEventId")]
    [InverseProperty("BaseEvent")]
    public virtual ICollection<CalendarRecurrence> CalendarRecurrence { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CalendarEventCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("MeetingId")]
    [InverseProperty("Meeting")]
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    [ForeignKey("CalendarEventId")]
    [InverseProperty("CalendarEvent")]
    public virtual ICollection<MailActivity> MailActivity { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("CalendarEvent")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("OpportunityId")]
    // [InverseProperty("CalendarEvent")] //Many2one
    public virtual CrmLead? Opportunity { get; set; }

    // [Many2one]
    [ForeignKey("RecurrenceId")]
    // [InverseProperty("CalendarEvent")] //Many2one
    public virtual CalendarRecurrence? Recurrence { get; set; }

    // [Many2one]
    [ForeignKey("ResModelId")]
    // [InverseProperty("CalendarEvent")] //Many2one
    public virtual IrModel? ResModelNavigation { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("CalendarEventUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("VideocallChannelId")]
    // [InverseProperty("CalendarEvent")] //Many2one
    public virtual MailChannel? VideocallChannel { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CalendarEventWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("CalendarEventId")] //Many2many
    // [InverseProperty("CalendarEvent")] //Many2many
    public virtual ICollection<CalendarAlarm> CalendarAlarm { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CalendarEventId")]
    // [InverseProperty("CalendarEvent")]
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("EventId")] //Many2many
    // [InverseProperty("Event")] //Many2many
    public virtual ICollection<CalendarEventType> Type { get; set; }
}
