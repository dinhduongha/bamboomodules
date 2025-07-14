using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("link_tracker_click")]
//[Index("LinkId", Name = "link_tracker_click__link_id_index")]
public partial class LinkTrackerClick: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("link_id")]
    public Guid? LinkId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("ip")]
    public string? Ip { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("mailing_trace_id")]
    public Guid? MailingTraceId { get; set; }

    [Column("mass_mailing_id")]
    public Guid? MassMailingId { get; set; }

    [ForeignKey("CampaignId")]
    //[InverseProperty("LinkTrackerClicks")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("LinkTrackerClicks")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("LinkTrackerClickCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LinkId")]
    //[InverseProperty("LinkTrackerClicks")]
    [NotMapped]
    public virtual LinkTracker? Link { get; set; }

    [ForeignKey("MailingTraceId")]
    //[InverseProperty("LinkTrackerClicks")]
    [NotMapped]
    public virtual MailingTrace? MailingTrace { get; set; }

    [ForeignKey("MassMailingId")]
    //[InverseProperty("LinkTrackerClicks")]
    [NotMapped]
    public virtual MailingMailing? MassMailing { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LinkTrackerClickWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
