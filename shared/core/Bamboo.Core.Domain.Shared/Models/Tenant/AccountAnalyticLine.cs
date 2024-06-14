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

[Table("account_analytic_line")]
//[Index("AccountId", Name = "account_analytic_line_account_id_index")]
//[Index("Date", Name = "account_analytic_line_date_index")]
//[Index("MoveLineId", Name = "account_analytic_line_move_line_id_index")]
//[Index("UserId", Name = "account_analytic_line_user_id_index")]
public partial class AccountAnalyticLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("plan_id")]
    public Guid? PlanId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("unit_amount")]
    public double? UnitAmount { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("general_account_id")]
    public Guid? GeneralAccountId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("move_line_id")]
    public Guid? MoveLineId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [Column("so_line")]
    public Guid? SoLine { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual AccountAnalyticAccount? Account { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAnalyticLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("GeneralAccountId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual AccountAccount? GeneralAccount { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("MoveLineId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual AccountMoveLine? MoveLine { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PlanId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual AccountAnalyticPlan? Plan { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("SoLine")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual SaleOrderLine? SoLineNavigation { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("AccountAnalyticLineUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAnalyticLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("MoAnalyticAccountLine")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorderMoAnalyticAccountLines { get; } = new List<MrpWorkorder>();

    //[InverseProperty("WcAnalyticAccountLine")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorderWcAnalyticAccountLines { get; } = new List<MrpWorkorder>();

    //[InverseProperty("AnalyticAccountLine")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

}
