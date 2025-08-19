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

[Table("account_bank_statement_line")]
//[Index("InternalIndex", Name = "account_bank_statement_line_internal_index_index")]
//[Index("UniqueImportId", Name = "account_bank_statement_line_unique_import_id", IsUnique = true)]
//[Index("MoveId", Name = "account_bank_statement_line__move_id_index")]
public partial class AccountBankStatementLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("statement_id")]
    public Guid? StatementId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("foreign_currency_id")]
    public Guid? ForeignCurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("account_number")]
    public string? AccountNumber { get; set; }

    [Column("partner_name")]
    public string? PartnerName { get; set; }

    [Column("transaction_type")]
    public string? TransactionType { get; set; }

    [Column("payment_ref")]
    public string? PaymentRef { get; set; }

    [Column("internal_index")]
    public string? InternalIndex { get; set; }

    [JsonField]
    [Column("transaction_details", TypeName = "jsonb")]
    public string? TransactionDetails { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("amount_currency")]
    public decimal? AmountCurrency { get; set; }

    [Column("is_reconciled")]
    public bool? IsReconciled { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("amount_residual")]
    public double? AmountResidual { get; set; }

    [Column("pos_session_id")]
    public Guid? PosSessionId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("unique_import_id")]
    public string? UniqueImportId { get; set; }

    // [One2many]
    [ForeignKey("StatementLineId")]
    [InverseProperty("StatementLine")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    [ForeignKey("StatementLineId")]
    [InverseProperty("StatementLine")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountBankStatementLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountBankStatementLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("AccountBankStatementLineCurrency")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("AccountBankStatementLine")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("ForeignCurrencyId")]
    // [InverseProperty("AccountBankStatementLineForeignCurrency")] //Many2one
    public virtual ResCurrency? ForeignCurrency { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("AccountBankStatementLine")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("AccountBankStatementLine")] //Many2one
    public virtual AccountMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("AccountBankStatementLine")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PosSessionId")]
    // [InverseProperty("AccountBankStatementLine")] //Many2one
    public virtual PosSession? PosSession { get; set; }

    // [Many2one]
    [ForeignKey("StatementId")]
    // [InverseProperty("AccountBankStatementLine")] //Many2one
    public virtual AccountBankStatement? Statement { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountBankStatementLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountBankStatementLineId")] //Many2many
    // [InverseProperty("AccountBankStatementLine")] //Many2many
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }
}
