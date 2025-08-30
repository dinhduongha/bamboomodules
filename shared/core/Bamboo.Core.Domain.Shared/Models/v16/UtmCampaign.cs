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

    [JsonField(IsSparse = false)] // Title
    [Column("title", TypeName = "jsonb")]
    public StringDictionary? Title { get; set; }

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

    [Column("ab_testing_winner_selection")]
    public string? AbTestingWinnerSelection { get; set; }

    [Column("ab_testing_completed")]
    public bool? AbTestingCompleted { get; set; }

    [Column("ab_testing_schedule_datetime", TypeName = "timestamp without time zone")]
    public DateTime? AbTestingScheduleDatetime { get; set; }

    [Column("ab_testing_sms_winner_selection")]
    public string? AbTestingSmsWinnerSelection { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AbTestingWinnerMailingId")]
    public virtual MailingMailing? AbTestingWinnerMailing { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("UtmCampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("UtmCampaign")] // One2many
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<LinkTracker> LinkTracker { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<LinkTrackerClick> LinkTrackerClick { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<MailingTrace> MailingTrace { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Campaign")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("UtmCampaignId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("UtmCampaign")] // One2many
    public virtual ICollection<SmsComposer> SmsComposer { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StageId")]
    public virtual UtmStage? Stage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("TagId")] // Many2many // Normal
    // [InverseProperty("Tag")] // Many2many // Normal
    public virtual ICollection<UtmTag> Campaign { get; set; }
}
