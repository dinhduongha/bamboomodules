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

[Table("followup_print")]
public partial class FollowupPrint: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("followup_id")]
    public Guid? FollowupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_subject")]
    public string? EmailSubject { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("email_body")]
    public string? EmailBody { get; set; }

    [Column("summary")]
    public string? Summary { get; set; }

    [Column("email_conf")]
    public bool? EmailConf { get; set; }

    [Column("partner_lang")]
    public bool? PartnerLang { get; set; }

    [Column("test_print")]
    public bool? TestPrint { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("FollowupId")]
    public virtual FollowupFollowup? Followup { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("OsvMemoryId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("OsvMemory")] // One2many
    public virtual ICollection<PartnerStatRel> PartnerStatRel { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
