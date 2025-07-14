using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("mrp_account_wip_accounting")]
public partial class MrpAccountWipAccounting: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }

    [Column("reversal_date")]
    public DateOnly? ReversalDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpAccountWipAccountingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("MrpAccountWipAccountings")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    //[InverseProperty("WipAccounting")]
    [NotMapped]
    public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLines { get; set; } = new List<MrpAccountWipAccountingLine>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpAccountWipAccountingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("MrpAccountWipAccountingId")]
    //[InverseProperty("MrpAccountWipAccountings")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } = new List<MrpProduction>();
}
