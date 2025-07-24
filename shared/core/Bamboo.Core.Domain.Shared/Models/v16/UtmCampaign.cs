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

[Table("utm_campaign")]
//[Index("Name", Name = "utm_campaign_unique_name", IsUnique = true)]
public partial class UtmCampaign: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [JsonField]
    [Column("title", TypeName = "jsonb")]
    public string? Title { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_auto_campaign")]
    public bool? IsAutoCampaign { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    /// <summary>
    /// Total A/B test percentage
    /// </summary>
    [Column("ab_testing_total_pc")]
    public int? AbTestingTotalPc { get; set; }


    [Column("ab_testing_winner_mailing_id")]
    public Guid? AbTestingWinnerMailingId { get; set; }

    [Column("ab_testing_winner_selection")]
    public string? AbTestingWinnerSelection { get; set; }

    [Column("ab_testing_completed")]
    public bool? AbTestingCompleted { get; set; }

    [Column("ab_testing_schedule_datetime", TypeName = "timestamp without time zone")]
    public DateTime? AbTestingScheduleDatetime { get; set; }

    [Column("ab_testing_sms_winner_selection")]
    public string? AbTestingSmsWinnerSelection { get; set; }

    [ForeignKey("AbTestingWinnerMailingId")]
    //[InverseProperty("UtmCampaigns")]
    [NotMapped]
    public virtual MailingMailing? AbTestingWinnerMailing { get; set; }

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    [ForeignKey("TenantId")]
    //[InverseProperty("UtmCampaigns")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("UtmCampaignCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("StageId")]
    //[InverseProperty("UtmCampaigns")]
    [NotMapped]
    public virtual UtmStage? Stage { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("UtmCampaignUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("UtmCampaignWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    // v16-Compat
    //[InverseProperty("Campaign")]
    // [NotMapped]
    // public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } = new List<CrmLead>();

    //[InverseProperty("UtmCampaign")]
    [NotMapped]
    public virtual ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } = new List<HrApplicant>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<LinkTrackerClick> LinkTrackerClicks { get; set; } = new List<LinkTrackerClick>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<LinkTracker> LinkTrackers { get; set; } = new List<LinkTracker>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; set; } = new List<MailComposeMessage>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<MailingMailing> MailingMailings { get; set; } = new List<MailingMailing>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<MailingTrace> MailingTraces { get; set; } = new List<MailingTrace>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    //[InverseProperty("UtmCampaign")]
    [NotMapped]
    public virtual ICollection<SmsComposer> SmsComposers { get; set; } = new List<SmsComposer>();

    [ForeignKey("TagId")]
    //[InverseProperty("Tags")]
    [NotMapped]
    public virtual ICollection<UtmTag> Campaigns { get; set; } = new List<UtmTag>();
}
