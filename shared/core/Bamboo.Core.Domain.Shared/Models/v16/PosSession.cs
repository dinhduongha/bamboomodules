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

[Table("pos_session")]
//[Index("ConfigId", Name = "pos_session_config_id_index")]
//[Index("MoveId", Name = "pos_session_move_id_index")]
//[Index("State", Name = "pos_session_state_index")]
//[Index("Name", Name = "pos_session_uniq_name", IsUnique = true)]
//[Index("UserId", Name = "pos_session_user_id_index")]
public partial class PosSession: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("config_id")]
    public Guid? ConfigId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("sequence_number")]
    public long? SequenceNumber { get; set; }

    [Column("login_number")]
    public long? LoginNumber { get; set; }

    [Column("cash_journal_id")]
    public Guid? CashJournalId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("opening_notes")]
    public string? OpeningNotes { get; set; }

    [Column("cash_register_balance_end_real")]
    public decimal? CashRegisterBalanceEndReal { get; set; }

    [Column("cash_register_balance_start")]
    public decimal? CashRegisterBalanceStart { get; set; }

    [Column("cash_real_transaction")]
    public decimal? CashRealTransaction { get; set; }

    [Column("rescue")]
    public bool? Rescue { get; set; }

    [Column("update_stock_at_closing")]
    public bool? UpdateStockAtClosing { get; set; }

    [Column("start_at", TypeName = "timestamp without time zone")]
    public DateTime? StartAt { get; set; }

    [Column("stop_at", TypeName = "timestamp without time zone")]
    public DateTime? StopAt { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("closing_notes")]
    public string? ClosingNotes { get; set; }

    // [One2many]
    [ForeignKey("PosSessionId")]
    [InverseProperty("PosSession")]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many]
    [ForeignKey("PosSessionId")]
    [InverseProperty("PosSession")]
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [Many2one]
    [ForeignKey("CashJournalId")]
    // [InverseProperty("PosSession")] //Many2one
    public virtual AccountJournal? CashJournal { get; set; }

    // [Many2one]
    [ForeignKey("ConfigId")]
    // [InverseProperty("PosSession")] //Many2one
    public virtual PosConfig? Config { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PosSessionCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("PosSession")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("PosSession")] //Many2one
    public virtual AccountMove? Move { get; set; }

    // [One2many]
    [ForeignKey("PosSessionId")]
    [InverseProperty("PosSession")]
    public virtual ICollection<PosDailySalesReportsWizard> PosDailySalesReportsWizard { get; set; }

    // [One2many]
    [ForeignKey("SessionId")]
    [InverseProperty("Session")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [ForeignKey("SessionId")]
    [InverseProperty("Session")]
    public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [One2many]
    [ForeignKey("PosSessionId")]
    [InverseProperty("PosSession")]
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("PosSessionUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PosSessionWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
