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

[Table("pos_order")]
//[Index("CompanyId", Name = "pos_order__company_id_index")]
//[Index("DateOrder", Name = "pos_order__date_order_index")]
//[Index("PosReference", Name = "pos_order__pos_reference_index")]
//[Index("SessionId", Name = "pos_order__session_id_index")]
//[Index("State", Name = "pos_order__state_index")]
public partial class PosOrder: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("sequence_number")]
    public long? SequenceNumber { get; set; }

    [Column("session_id")]
    public Guid? SessionId { get; set; }

    [Column("config_id")]
    public Guid? ConfigId { get; set; }

    [Column("account_move")]
    public Guid? AccountMove { get; set; }

    [Column("procurement_group_id")]
    public Guid? ProcurementGroupId { get; set; }

    [Column("nb_print")]
    public long? NbPrint { get; set; }

    [Column("sale_journal")]
    public Guid? SaleJournal { get; set; }

    [Column("fiscal_position_id")]
    public Guid? FiscalPositionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("last_order_preparation_change")]
    public string? LastOrderPreparationChange { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("floating_order_name")]
    public string? FloatingOrderName { get; set; }

    [Column("pos_reference")]
    public string? PosReference { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("ticket_code")]
    public string? TicketCode { get; set; }

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [Column("shipping_date")]
    public DateTime? ShippingDate { get; set; }

    [Column("general_note")]
    public string? GeneralNote { get; set; }

    [Column("amount_difference")]
    public decimal? AmountDifference { get; set; }

    [Column("amount_tax")]
    public decimal? AmountTax { get; set; }

    [Column("amount_total")]
    public decimal? AmountTotal { get; set; }

    [Column("amount_paid")]
    public decimal? AmountPaid { get; set; }

    [Column("amount_return")]
    public decimal? AmountReturn { get; set; }

    [Column("currency_rate")]
    public decimal? CurrencyRate { get; set; }

    [Column("tip_amount")]
    public decimal? TipAmount { get; set; }

    [Column("to_invoice")]
    public bool? ToInvoice { get; set; }

    [Column("to_ship")]
    public bool? ToShip { get; set; }

    [Column("is_tipped")]
    public bool? IsTipped { get; set; }

    [Column("has_deleted_line")]
    public bool? HasDeletedLine { get; set; }

    [Column("date_order", TypeName = "timestamp without time zone")]
    public DateTime? DateOrder { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("next_online_payment_amount")]
    public decimal? NextOnlinePaymentAmount { get; set; }

    [Column("crm_team_id")]
    public Guid? CrmTeamId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("cashier")]
    public string? Cashier { get; set; }

    [Column("table_id")]
    public Guid? TableId { get; set; }

    [Column("customer_count")]
    public long? CustomerCount { get; set; }

    [Column("multiprint_resume")]
    public string? MultiprintResume { get; set; }

    [Column("takeaway")]
    public bool? Takeaway { get; set; }

    [Column("table_stand_number")]
    public string? TableStandNumber { get; set; }

    [Column("use_self_order_online_payment")]
    public bool? UseSelfOrderOnlinePayment { get; set; }

    // [Column("employee_id")]
    // public Guid? EmployeeId { get; set; }

    // [Column("cashier")]
    // public string? Cashier { get; set; }

    // [Many2one]
    [ForeignKey("AccountMove")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual AccountMove? AccountMove1 { get; set; }

    // [One2many]
    [ForeignKey("ReversedPosOrderId")]
    [InverseProperty("ReversedPosOrder")]
    public virtual ICollection<AccountMove> AccountMoveNavigation { get; set; }

    // v16-Compat
    // [Many2one]
    //[ForeignKey("AccountMove")]
    // [InverseProperty("PosOrder")] //Many2one
    //public virtual AccountMove? AccountMoveNavigation { get; set; }

    // [One2many]
    [ForeignKey("PosOrderId")]
    [InverseProperty("PosOrder")]
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("ConfigId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual PosConfig? Config { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PosOrderCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CrmTeamId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual CrmTeam? CrmTeam { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("FiscalPositionId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual AccountFiscalPosition? FiscalPosition { get; set; }

    // [One2many]
    [ForeignKey("SourcePosOrderId")]
    [InverseProperty("SourcePosOrder")]
    public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [One2many]
    [ForeignKey("PosOrderId")]
    [InverseProperty("PosOrder")]
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [One2many]
    [ForeignKey("PosOrderId")]
    [InverseProperty("PosOrder")]
    public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [Many2one]
    [ForeignKey("PricelistId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual ProductPricelist? Pricelist { get; set; }

    // [Many2one]
    [ForeignKey("ProcurementGroupId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual ProcurementGroup? ProcurementGroup { get; set; }

    // [One2many]
    [ForeignKey("PosOrderId")]
    [InverseProperty("PosOrderNavigation")]
    public virtual ICollection<ProcurementGroup> ProcurementGroupNavigation { get; set; }

    // [Many2one]
    [ForeignKey("SaleJournal")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual AccountJournal? SaleJournalNavigation { get; set; }

    // [Many2one]
    [ForeignKey("SessionId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual PosSession? Session { get; set; }

    // [One2many]
    [ForeignKey("PosOrderId")]
    [InverseProperty("PosOrder")]
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [Many2one]
    [ForeignKey("TableId")]
    // [InverseProperty("PosOrder")] //Many2one
    public virtual RestaurantTable? Table { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("PosOrderUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PosOrderWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
