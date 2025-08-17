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
public partial class LinkTracker: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("count")]
    public long? Count { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("label")]
    public string? Label { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("mass_mailing_id")]
    public Guid? MassMailingId { get; set; }

    // [Many2one]
    [ForeignKey("CampaignId")]
    // [InverseProperty("LinkTracker")] //Many2one
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LinkTrackerCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("LinkId")]
    [InverseProperty("Link")]
    public virtual ICollection<LinkTrackerClick> LinkTrackerClick { get; set; }

    // [One2many]
    [ForeignKey("LinkId")]
    [InverseProperty("Link")]
    public virtual ICollection<LinkTrackerCode> LinkTrackerCode { get; set; }

    // [Many2one]
    [ForeignKey("MassMailingId")]
    // [InverseProperty("LinkTracker")] //Many2one
    public virtual MailingMailing? MassMailing { get; set; }

    // [Many2one]
    [ForeignKey("MediumId")]
    // [InverseProperty("LinkTracker")] //Many2one
    public virtual UtmMedium? Medium { get; set; }

    // [Many2one]
    [ForeignKey("SourceId")]
    // [InverseProperty("LinkTracker")] //Many2one
    public virtual UtmSource? Source { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LinkTrackerWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
