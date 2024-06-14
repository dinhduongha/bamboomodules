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

[Table("website_visitor")]
//[Index("AccessToken", Name = "website_visitor_access_token_unique", IsUnique = true)]
public partial class WebsiteVisitor: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("lang_id")]
    public long? LangId { get; set; }

    [Column("visit_count")]
    public long? VisitCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("timezone")]
    public string? Timezone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("last_connection_datetime", TypeName = "timestamp without time zone")]
    public DateTime? LastConnectionDatetime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("WebsiteVisitors")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsiteVisitorCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LangId")]
    //[InverseProperty("WebsiteVisitors")]
    [NotMapped]
    public virtual ResLang? Lang { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("WebsiteVisitors")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("WebsiteVisitors")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsiteVisitorWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Visitor")]
    [NotMapped]
    public virtual ICollection<WebsiteTrack> WebsiteTracks { get; } = new List<WebsiteTrack>();

    [ForeignKey("WebsiteVisitorId")]
    //[InverseProperty("WebsiteVisitors")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();
}
