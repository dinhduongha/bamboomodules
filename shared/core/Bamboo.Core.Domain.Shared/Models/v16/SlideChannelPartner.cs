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

[Table("slide_channel_partner")]
//[Index("ChannelId", Name = "slide_channel_partner__channel_id_index")]
//[Index("PartnerId", Name = "slide_channel_partner__partner_id_index")]
//[Index("ChannelId", "PartnerId", Name = "slide_channel_partner_channel_partner_uniq", IsUnique = true)]
public partial class SlideChannelPartner: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("completion")]
    public long? Completion { get; set; }

    [Column("completed_slides_count")]
    public long? CompletedSlidesCount { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("member_status")]
    public string? MemberStatus { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("last_invitation_date", TypeName = "timestamp without time zone")]
    public DateTime? LastInvitationDate { get; set; }

    [Column("completed")]
    public bool? Completed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("survey_certification_success")]
    public bool? SurveyCertificationSuccess { get; set; }

    // [Many2one]
    [ForeignKey("ChannelId")]
    // [InverseProperty("SlideChannelPartner")] //Many2one
    public virtual SlideChannel? Channel { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SlideChannelPartnerCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("SlideChannelPartner")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SlideChannelPartnerWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
