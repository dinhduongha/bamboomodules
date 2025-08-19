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
public partial class UtmCampaign: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("ab_testing_winner_mailing_id")]
    public Guid? AbTestingWinnerMailingId { get; set; }

    [Column("ab_testing_total_pc")]
    public long? AbTestingTotalPc { get; set; }

    [Column("ab_testing_winner_selection")]
    public string? AbTestingWinnerSelection { get; set; }

    [Column("ab_testing_completed")]
    public bool? AbTestingCompleted { get; set; }

    [Column("ab_testing_schedule_datetime", TypeName = "timestamp without time zone")]
    public DateTime? AbTestingScheduleDatetime { get; set; }

    [Column("ab_testing_sms_winner_selection")]
    public string? AbTestingSmsWinnerSelection { get; set; }

    // [Many2one]
    [ForeignKey("AbTestingWinnerMailingId")]
    // [InverseProperty("UtmCampaign")] //Many2one
    public virtual MailingMailing? AbTestingWinnerMailing { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("UtmCampaign")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("UtmCampaignCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [ForeignKey("UtmCampaignId")]
    [InverseProperty("UtmCampaign")]
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<LinkTracker> LinkTracker { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<LinkTrackerClick> LinkTrackerClick { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<MailingTrace> MailingTrace { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    [ForeignKey("UtmCampaignId")]
    [InverseProperty("UtmCampaign")]
    public virtual ICollection<SmsComposer> SmsComposer { get; set; }

    // [Many2one]
    [ForeignKey("StageId")]
    // [InverseProperty("UtmCampaign")] //Many2one
    public virtual UtmStage? Stage { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("UtmCampaignUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("UtmCampaignWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("TagId")] //Many2many
    // [InverseProperty("Tag")] //Many2many
    public virtual ICollection<UtmTag> Campaign { get; set; }
}
