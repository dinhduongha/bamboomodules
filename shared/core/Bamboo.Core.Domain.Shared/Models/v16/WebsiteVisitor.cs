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
public partial class WebsiteVisitor: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("lang_id")]
    public Guid? LangId { get; set; }

    [Column("visit_count")]
    public long? VisitCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("timezone")]
    public string? Timezone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("last_connection_datetime", TypeName = "timestamp without time zone")]
    public DateTime? LastConnectionDatetime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("livechat_operator_id")]
    public Guid? LivechatOperatorId { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("WebsiteVisitor")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("WebsiteVisitorCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("LivechatVisitorId")]
    [InverseProperty("LivechatVisitor")]
    public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many]
    [ForeignKey("VisitorId")]
    [InverseProperty("Visitor")]
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many]
    [ForeignKey("VisitorId")]
    [InverseProperty("Visitor")]
    public virtual ICollection<EventTrackVisitor> EventTrackVisitor { get; set; }

    // [Many2one]
    [ForeignKey("LangId")]
    // [InverseProperty("WebsiteVisitor")] //Many2one
    public virtual ResLang? Lang { get; set; }

    // [Many2one]
    [ForeignKey("LivechatOperatorId")]
    // [InverseProperty("WebsiteVisitorLivechatOperator")] //Many2one
    public virtual ResPartner? LivechatOperator { get; set; }

    // [One2many]
    [ForeignKey("LivechatVisitorId")]
    [InverseProperty("LivechatVisitor")]
    public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("WebsiteVisitorPartner")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("WebsiteVisitor")] //Many2one
    public virtual Website? Website { get; set; }

    // [One2many]
    [ForeignKey("VisitorId")]
    [InverseProperty("Visitor")]
    public virtual ICollection<WebsiteTrack> WebsiteTrack { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("WebsiteVisitorWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("WebsiteVisitorId")]
    // [InverseProperty("WebsiteVisitor")]
    public virtual ICollection<CrmLead> CrmLead { get; set; }
}
