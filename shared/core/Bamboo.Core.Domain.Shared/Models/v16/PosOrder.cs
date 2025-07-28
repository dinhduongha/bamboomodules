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
//[Index("AccountMove", Name = "pos_order_account_move_index")]
//[Index("DateOrder", Name = "pos_order_date_order_index")]
//[Index("SessionId", Name = "pos_order_session_id_index")]
public partial class PosOrder: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("sequence_number")]
    public long SequenceNumber { get; set; }

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
    public Guid? CreatorId { get; set; }

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

    // v16-Compat
    [Column("note")]
    public string? Note { get; set; }

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

    // v16-Compat
    [Column("to_ship")]
    public bool? ToShip { get; set; }

    [Column("is_tipped")]
    public bool? IsTipped { get; set; }

    [Column("has_deleted_line")]
    public bool? HasDeletedLine { get; set; }

    [Column("date_order", TypeName = "timestamp without time zone")]
    public DateTime? DateOrder { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("next_online_payment_amount")]
    public decimal? NextOnlinePaymentAmount { get; set; }

    [Column("crm_team_id")]
    public Guid? CrmTeamId { get; set; }

    [Column("table_id")]
    public Guid? TableId { get; set; }

    [Column("customer_count")]
    public long? CustomerCount { get; set; }

    [Column("takeaway")]
    public bool? Takeaway { get; set; }

    [Column("table_stand_number")]
    public string? TableStandNumber { get; set; }

    [Column("use_self_order_online_payment")]
    public bool? UseSelfOrderOnlinePayment { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("cashier")]
    public string? Cashier { get; set; }

    [ForeignKey("AccountMove")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual AccountMove? AccountMoveNavigation { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosOrderCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CrmTeamId")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual CrmTeam? CrmTeam { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("FiscalPositionId")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual AccountFiscalPosition? FiscalPosition { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PricelistId")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual ProductPricelist? Pricelist { get; set; }

    [ForeignKey("ProcurementGroupId")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual ProcurementGroup? ProcurementGroup { get; set; }

    [ForeignKey("SaleJournal")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual AccountJournal? SaleJournalNavigation { get; set; }

    [ForeignKey("SessionId")]
    //[InverseProperty("PosOrders")]
    [NotMapped]
    public virtual PosSession? Session { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("PosOrderUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosOrderWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
    
    //[InverseProperty("Order")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; set; } 

    //[InverseProperty("PosOrder")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPayments { get; set; } 

    //[InverseProperty("PosOrder")]
    [NotMapped]
    public virtual ICollection<ProcurementGroup> ProcurementGroups { get; set; } 

    //[InverseProperty("PosOrder")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; set; } 

}
