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

[Table("ir_sequence")]
public partial class IrSequence: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("number_next")]
    public long? NumberNext { get; set; }

    [Column("number_increment")]
    public long? NumberIncrement { get; set; }

    [Column("padding")]
    public long? Padding { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("implementation")]
    public string? Implementation { get; set; }

    [Column("prefix")]
    public string? Prefix { get; set; }

    [Column("suffix")]
    public string? Suffix { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("use_date_range")]
    public bool? UseDateRange { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SequenceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Sequence")] // One2many
    public virtual ICollection<IrSequenceDateRange> IrSequenceDateRange { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SequenceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Sequence")] // One2many
    public virtual ICollection<PosConfig> PosConfigSequence { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SequenceLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SequenceLine")] // One2many
    public virtual ICollection<PosConfig> PosConfigSequenceLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("BatchPaymentSequenceId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("BatchPaymentSequence")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SequenceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SequenceNavigation")] // One2many
    public virtual ICollection<StockPickingType> StockPickingType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
