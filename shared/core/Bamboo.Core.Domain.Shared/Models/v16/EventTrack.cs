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

[Table("event_track")]
//[Index("IsPublished", Name = "event_track__is_published_index")]
//[Index("StageId", Name = "event_track__stage_id_index")]
public partial class EventTrack: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("website_cta_delay")]
    public long? WebsiteCtaDelay { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [Column("kanban_state_label")]
    public string? KanbanStateLabel { get; set; }

    [Column("partner_name")]
    public string? PartnerName { get; set; }

    [Column("partner_email")]
    public string? PartnerEmail { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("partner_function")]
    public string? PartnerFunction { get; set; }

    [Column("partner_company_name")]
    public string? PartnerCompanyName { get; set; }

    [Column("contact_email")]
    public string? ContactEmail { get; set; }

    [Column("contact_phone")]
    public string? ContactPhone { get; set; }

    [Column("website_cta_title")]
    public string? WebsiteCtaTitle { get; set; }

    [Column("website_cta_url")]
    public string? WebsiteCtaUrl { get; set; }

    [JsonField]
    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [JsonField]
    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [JsonField]
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [JsonField]
    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("partner_biography")]
    public string? PartnerBiography { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("wishlisted_by_default")]
    public bool? WishlistedByDefault { get; set; }

    [Column("website_cta")]
    public bool? WebsiteCta { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("youtube_video_url")]
    public string? YoutubeVideoUrl { get; set; }

    [Column("is_youtube_replay")]
    public bool? IsYoutubeReplay { get; set; }

    [Column("quiz_id")]
    public Guid? QuizId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    public virtual EventEvent? Event { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("EventTrackId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EventTrack")] // One2many
    public virtual ICollection<EventQuiz> EventQuiz { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TrackId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Track")] // One2many
    public virtual ICollection<EventTrackVisitor> EventTrackVisitor { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    public virtual EventTrackLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("QuizId")]
    public virtual EventQuiz? Quiz { get; set; }

    // [Many2one]
    [ForeignKey("StageId")]
    public virtual EventTrackStage? Stage { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EventTrackId")] // Many2many // Normal
    // [InverseProperty("EventTrack")] // Many2many // Normal
    public virtual ICollection<EventTrackTag> EventTrackTag { get; set; }
}
