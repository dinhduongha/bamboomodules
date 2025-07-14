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

[Table("link_tracker")]
public partial class LinkTracker: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("count")]
    public long? Count { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("label")]
    public string? Label { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("mass_mailing_id")]
    public Guid? MassMailingId { get; set; }

    [ForeignKey("CampaignId")]
    //[InverseProperty("LinkTrackers")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

    //[InverseProperty("LinkTracker")]
    [NotMapped]
    public virtual ICollection<CardCampaign> CardCampaigns { get; set; } = new List<CardCampaign>();

    [ForeignKey("CreatorId")]
    //[InverseProperty("LinkTrackerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Link")]
    [NotMapped]
    public virtual ICollection<LinkTrackerClick> LinkTrackerClicks { get; set; } = new List<LinkTrackerClick>();

    //[InverseProperty("Link")]
    [NotMapped]
    public virtual ICollection<LinkTrackerCode> LinkTrackerCodes { get; set; } = new List<LinkTrackerCode>();

    [ForeignKey("MassMailingId")]
    //[InverseProperty("LinkTrackers")]
    [NotMapped]
    public virtual MailingMailing? MassMailing { get; set; }

    [ForeignKey("MediumId")]
    //[InverseProperty("LinkTrackers")]
    [NotMapped]
    public virtual UtmMedium? Medium { get; set; }

    [ForeignKey("SourceId")]
    //[InverseProperty("LinkTrackers")]
    [NotMapped]
    public virtual UtmSource? Source { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LinkTrackerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
