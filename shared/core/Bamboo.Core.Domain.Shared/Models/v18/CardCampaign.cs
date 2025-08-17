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

[Table("card_campaign")]
public partial class CardCampaign: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("card_template_id")]
    public Guid? CardTemplateId { get; set; }

    [Column("link_tracker_id")]
    public Guid? LinkTrackerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("preview_record_ref")]
    public string? PreviewRecordRef { get; set; }

    [Column("target_url")]
    public string? TargetUrl { get; set; }

    [Column("reward_target_url")]
    public string? RewardTargetUrl { get; set; }

    [Column("request_title")]
    public string? RequestTitle { get; set; }

    [Column("content_button")]
    public string? ContentButton { get; set; }

    [Column("content_header")]
    public string? ContentHeader { get; set; }

    [Column("content_header_path")]
    public string? ContentHeaderPath { get; set; }

    [Column("content_header_color")]
    public string? ContentHeaderColor { get; set; }

    [Column("content_sub_header")]
    public string? ContentSubHeader { get; set; }

    [Column("content_sub_header_path")]
    public string? ContentSubHeaderPath { get; set; }

    [Column("content_sub_header_color")]
    public string? ContentSubHeaderColor { get; set; }

    [Column("content_section")]
    public string? ContentSection { get; set; }

    [Column("content_section_path")]
    public string? ContentSectionPath { get; set; }

    [Column("content_sub_section1")]
    public string? ContentSubSection1 { get; set; }

    [Column("content_sub_section1_path")]
    public string? ContentSubSection1Path { get; set; }

    [Column("content_sub_section2")]
    public string? ContentSubSection2 { get; set; }

    [Column("content_sub_section2_path")]
    public string? ContentSubSection2Path { get; set; }

    [Column("content_image1_path")]
    public string? ContentImage1Path { get; set; }

    [Column("content_image2_path")]
    public string? ContentImage2Path { get; set; }

    [Column("post_suggestion")]
    public string? PostSuggestion { get; set; }

    [Column("reward_message")]
    public string? RewardMessage { get; set; }

    [Column("request_description")]
    public string? RequestDescription { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("content_header_dyn")]
    public bool? ContentHeaderDyn { get; set; }

    [Column("content_sub_header_dyn")]
    public bool? ContentSubHeaderDyn { get; set; }

    [Column("content_section_dyn")]
    public bool? ContentSectionDyn { get; set; }

    [Column("content_sub_section1_dyn")]
    public bool? ContentSubSection1Dyn { get; set; }

    [Column("content_sub_section2_dyn")]
    public bool? ContentSubSection2Dyn { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("image_preview")]
    public byte[]? ImagePreview { get; set; }

    // [One2many]
    [ForeignKey("CampaignId")]
    [InverseProperty("Campaign")]
    public virtual ICollection<CardCard> CardCard { get; set; }

    // [Many2one]
    [ForeignKey("CardTemplateId")]
    // [InverseProperty("CardCampaign")] //Many2one
    public virtual CardTemplate? CardTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CardCampaignCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LinkTrackerId")]
    // [InverseProperty("CardCampaign")] //Many2one
    public virtual LinkTracker? LinkTracker { get; set; }

    // [One2many]
    [ForeignKey("CardCampaignId")]
    [InverseProperty("CardCampaign")]
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("CardCampaignUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CardCampaignWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("CardCampaignId")] //Many2many
    // [InverseProperty("CardCampaign")] //Many2many
    public virtual ICollection<CardCampaignTag> CardCampaignTag { get; set; }
}
