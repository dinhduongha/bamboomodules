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
//[Index("AccessToken", Name = "calendar_event__access_token_index")]
//[Index("MicrosoftId", Name = "calendar_event__microsoft_id_index")]
//[Index("MsUniversalEventId", Name = "calendar_event__ms_universal_event_id_index")]
//[Index("OpportunityId", Name = "calendar_event__opportunity_id_index")]
public partial class CalendarEvent: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

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

    [Column("candidate_id")]
    public Guid? CandidateId { get; set; }

    [Column("google_id")]
    public string? GoogleId { get; set; }

    [Column("need_sync")]
    public bool? NeedSync { get; set; }

    [Column("guests_readonly")]
    public bool? GuestsReadonly { get; set; }

    [Column("microsoft_id")]
    public string? MicrosoftId { get; set; }

    [Column("ms_universal_event_id")]
    public string? MsUniversalEventId { get; set; }

    [Column("microsoft_recurrence_master_id")]
    public string? MicrosoftRecurrenceMasterId { get; set; }

    [Column("need_sync_m")]
    public bool? NeedSyncM { get; set; }

    // [Many2one]
    [ForeignKey("ApplicantId")]
    public virtual HrApplicant? Applicant { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<CalendarAttendee> CalendarAttendee { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("Record")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RecordNavigation")] // One2many
    public virtual ICollection<CalendarPopoverDeleteWizard> CalendarPopoverDeleteWizard { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("BaseEventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BaseEvent")] // One2many
    public virtual ICollection<CalendarRecurrence> CalendarRecurrence { get; set; }

    // [Many2one]
    [ForeignKey("CandidateId")]
    public virtual HrCandidate? Candidate { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MeetingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Meeting")] // One2many
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CalendarEventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CalendarEvent")] // One2many
    public virtual ICollection<MailActivity> MailActivity { get; set; }

    // [Many2one]
    [ForeignKey("OpportunityId")]
    public virtual CrmLead? Opportunity { get; set; }

    // [Many2one]
    [ForeignKey("RecurrenceId")]
    public virtual CalendarRecurrence? Recurrence { get; set; }

    // [Many2one]
    [ForeignKey("ResModelId")]
    public virtual IrModel? ResModelNavigation { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("VideocallChannelId")]
    public virtual DiscussChannel? VideocallChannel { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CalendarEventId")] // Many2many // Normal
    // [InverseProperty("CalendarEvent")] // Many2many // Normal
    public virtual ICollection<CalendarAlarm> CalendarAlarm { get; set; }

    // [Many2many] // Hidden

    [NotMapped] //Many2many // Hidden // Peer relationship (ResPartner) is commented out
    // [ForeignKey("CalendarEventId")] //Many2many // Hidden
    // [InverseProperty("CalendarEvent")] //Many2many // Hidden
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EventId")] // Many2many // Normal
    // [InverseProperty("Event")] // Many2many // Normal
    public virtual ICollection<CalendarEventType> Type { get; set; }
}
