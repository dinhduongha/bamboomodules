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
public partial class AccountAnalyticLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    // v16-Compat
    [Column("plan_id")]
    public Guid? PlanId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("unit_amount")]
    public double? UnitAmount { get; set; }

    [Column("x_plan2_id")]
    public Guid? XPlan2Id { get; set; }

    [Column("x_plan3_id")]
    public Guid? XPlan3Id { get; set; }

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

    // v16-Compat
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

    //[InverseProperty("AnalyticAccountLine")]
    //public virtual ICollection<StockMove> StockMoves { get; set; } 

    // [ForeignKey("AccountAnalyticLineId")]
    // //[InverseProperty("AnalyticAccountLine")]
    // [NotMapped]
    // public virtual ICollection<StockMove> StockMoves { get; set; } 

    [ForeignKey("UserId")]
    //[InverseProperty("AccountAnalyticLineUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAnalyticLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("XPlan2Id")]
    //[InverseProperty("AccountAnalyticLineXPlan2s")]
    [NotMapped]
    public virtual AccountAnalyticAccount? XPlan2 { get; set; }

    [ForeignKey("XPlan3Id")]
    //[InverseProperty("AccountAnalyticLineXPlan3s")]
    [NotMapped]
    public virtual AccountAnalyticAccount? XPlan3 { get; set; }

    // v16-Compat
    //[InverseProperty("MoAnalyticAccountLine")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorderMoAnalyticAccountLines { get; set; } 

    // v16-Compat
    //[InverseProperty("WcAnalyticAccountLine")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorderWcAnalyticAccountLines { get; set; } 

    [ForeignKey("AccountAnalyticLineId")]
    //[InverseProperty("AccountAnalyticLines")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; set; } 

    [ForeignKey("AccountAnalyticLineId")]
    //[InverseProperty("AccountAnalyticLinesNavigation")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkordersNavigation { get; set; } 
}
