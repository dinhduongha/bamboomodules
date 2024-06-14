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
public partial class CalendarEvent: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("opportunity_id")]
    public Guid? OpportunityId { get; set; }

    [Column("applicant_id")]
    public Guid? ApplicantId { get; set; }

    [ForeignKey("ApplicantId")]
    //[InverseProperty("CalendarEvents")]
    [NotMapped]
    public virtual HrApplicant? Applicant { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CalendarEventCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("CalendarEvents")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("OpportunityId")]
    //[InverseProperty("CalendarEvents")]
    [NotMapped]
    public virtual CrmLead? Opportunity { get; set; }

    [ForeignKey("RecurrenceId")]
    //[InverseProperty("CalendarEvents")]
    [NotMapped]
    public virtual CalendarRecurrence? Recurrence { get; set; }

    [ForeignKey("ResModelId")]
    //[InverseProperty("CalendarEvents")]
    [NotMapped]
    public virtual IrModel? ResModelNavigation { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("CalendarEventUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("VideocallChannelId")]
    //[InverseProperty("CalendarEvents")]
    [NotMapped]
    public virtual MailChannel? VideocallChannel { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CalendarEventWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<CalendarAttendee> CalendarAttendees { get; } = new List<CalendarAttendee>();

    //[InverseProperty("BaseEvent")]
    [NotMapped]
    public virtual ICollection<CalendarRecurrence> CalendarRecurrences { get; } = new List<CalendarRecurrence>();

    //[InverseProperty("Meeting")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; } = new List<HrLeave>();

    //[InverseProperty("CalendarEvent")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivities { get; } = new List<MailActivity>();

    [ForeignKey("CalendarEventId")]
    //[InverseProperty("CalendarEvents")]
    [NotMapped]
    public virtual ICollection<CalendarAlarm> CalendarAlarms { get; } = new List<CalendarAlarm>();

    [ForeignKey("CalendarEventId")]
    //[InverseProperty("CalendarEvents")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

    [ForeignKey("EventId")]
    //[InverseProperty("Events")]
    [NotMapped]
    public virtual ICollection<CalendarEventType> Types { get; } = new List<CalendarEventType>();
}
