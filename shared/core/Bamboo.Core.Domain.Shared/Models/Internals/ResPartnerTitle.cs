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

[Table("res_partner_title")]
public partial class ResPartnerTitle: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("shortcut", TypeName = "jsonb")]
    public string? Shortcut { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("Title")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TitleNavigation")] // One2many
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TitleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Title")] // One2many
    public virtual ICollection<MailingContact> MailingContact { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("Title")]
    [NotMapped] // One2many // Peer relationship (ResPartner) is commented out
    // [InverseProperty("TitleNavigation")] // One2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
