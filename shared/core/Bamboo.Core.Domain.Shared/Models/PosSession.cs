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
public partial class PosSession: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CashJournalId")]
    //[InverseProperty("PosSessions")]
    [NotMapped]
    public virtual AccountJournal? CashJournal { get; set; }

    [ForeignKey("ConfigId")]
    //[InverseProperty("PosSessions")]
    [NotMapped]
    public virtual PosConfig? Config { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosSessionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("PosSessions")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("PosSessions")]
    [NotMapped]
    public virtual AccountMove? Move { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("PosSessionUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosSessionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
    
    //[InverseProperty("PosSession")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLines { get; } = new List<AccountBankStatementLine>();

    //[InverseProperty("PosSession")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; } = new List<AccountPayment>();

    //[InverseProperty("Session")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; } = new List<PosOrder>();

    //[InverseProperty("Session")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPayments { get; } = new List<PosPayment>();

    //[InverseProperty("PosSession")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; } = new List<StockPicking>();

}
