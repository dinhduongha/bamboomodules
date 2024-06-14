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

[Table("account_bank_statement")]
//[Index("FirstLineIndex", Name = "account_bank_statement_first_line_index_index")]
public partial class AccountBankStatement: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
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

    [Column("name")]
    public string? Name { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("first_line_index")]
    public string? FirstLineIndex { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("balance_start")]
    public decimal? BalanceStart { get; set; }

    [Column("balance_end")]
    public decimal? BalanceEnd { get; set; }

    [Column("balance_end_real")]
    public decimal? BalanceEndReal { get; set; }

    [Column("is_complete")]
    public bool? IsComplete { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }
 
    [ForeignKey("TenantId")]
    //[InverseProperty("AccountBankStatements")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountBankStatementCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("AccountBankStatements")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountBankStatementWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Statement")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLines { get; } = new List<AccountBankStatementLine>();

    //[InverseProperty("Statement")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    [ForeignKey("AccountBankStatementId")]
    //[InverseProperty("AccountBankStatements")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachments { get; } = new List<IrAttachment>();
}
