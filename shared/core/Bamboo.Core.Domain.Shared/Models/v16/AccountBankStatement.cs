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
//[Index("Date", Name = "account_bank_statement__date_index")]
//[Index("JournalId", "FirstLineIndex", Name = "account_bank_statement_first_line_index_idx")]
//[Index("JournalId", "Date", "Id", Name = "account_bank_statement_journal_id_date_desc_id_desc_idx", IsDescending = new[] { false, true, true })]
public partial class AccountBankStatement: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("StatementId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Statement")] // One2many
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("StatementId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Statement")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("AccountBankStatementId")] // Many2many // Normal
    // [InverseProperty("AccountBankStatement")] // Many2many // Normal
    public virtual ICollection<IrAttachment> IrAttachment { get; set; }
}
