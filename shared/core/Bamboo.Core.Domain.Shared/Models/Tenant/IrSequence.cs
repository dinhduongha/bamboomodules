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
public partial class IrSequence: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("number_next")]
    public long? NumberNext { get; set; }

    [Column("number_increment")]
    public long? NumberIncrement { get; set; }

    [Column("padding")]
    public long? Padding { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("IrSequences")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrSequenceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrSequenceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("SecureSequence")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    //[InverseProperty("Sequence")]
    [NotMapped]
    public virtual ICollection<IrSequenceDateRange> IrSequenceDateRanges { get; } = new List<IrSequenceDateRange>();

    //[InverseProperty("SequenceLine")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigSequenceLines { get; } = new List<PosConfig>();

    //[InverseProperty("Sequence")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigSequences { get; } = new List<PosConfig>();

    //[InverseProperty("SequenceNavigation")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypes { get; } = new List<StockPickingType>();

}
