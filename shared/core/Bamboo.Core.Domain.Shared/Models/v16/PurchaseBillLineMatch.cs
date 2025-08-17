using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
namespace Bamboo.Core.Models
{
    [Module("purchase", Depends = new[] { "account" })]
    [Model("purchase.bill.line.match", IsTransient = false, IsAuto = false)]
    [Table("purchase_bill_line_match")]
    public partial class PurchaseBillLineMatch : Entity<Guid>, IMultiTenant
    {
        
        //<editor-fold desc="ABP ENTITY PROPERTIES">
        [Key]
        public override Guid Id { get => base.Id; protected set => base.Id = value; }
        
        [Column("company_id")]
        public virtual Guid? TenantId { get; protected set; }
        
        [Column("create_date")]
        public DateTime CreationTime { get; set; }
        
        [Column("create_uid")]
        public Guid? CreatorId { get; set; }
        
        [Column("write_date")]
        public DateTime? LastModificationTime { get; set; }
        
        [Column("write_uid")]
        public Guid? LastModifierId { get; set; }
        
        [ForeignKey(nameof(CreatorId))]
        public virtual ResUsers? Creator { get; protected set; }
        
        [ForeignKey(nameof(LastModifierId))]
        public virtual ResUsers? LastModifier { get; protected set; }
        
        [ForeignKey(nameof(TenantId))]
        public virtual ResCompany? Company { get; set; }
        //</editor-fold>
        
        [Column("account_move_id")] public Guid? AccountMoveId { get; set; }
        [Many2one(RelatedModel = "account.move")]
        [ForeignKey(nameof(AccountMoveId))]
        public virtual AccountMove? AccountMove { get; set; }
        
        [Column("aml_id")] public Guid? AmlId { get; set; }
        [Many2one(RelatedModel = "account.move.line")]
        [ForeignKey(nameof(AmlId))]
        public virtual AccountMoveLine? Aml { get; set; }
        
        [Column("currency_id")] public Guid? CurrencyId { get; set; }
        [Many2one(RelatedModel = "res.currency")]
        [ForeignKey(nameof(CurrencyId))]
        public virtual ResCurrency? Currency { get; set; }
        
        [Column("line_amount_untaxed")]
        public decimal? LineAmountUntaxed { get; set; }
        
        [Column("line_qty")]
        public double? LineQty { get; set; }
        
        [Column("line_uom_id")] public Guid? LineUomId { get; set; }
        [Many2one(RelatedModel = "uom.uom")]
        [ForeignKey(nameof(LineUomId))]
        public virtual UomUom? LineUom { get; set; }
        
        [Column("partner_id")] public Guid? PartnerId { get; set; }
        [Many2one(RelatedModel = "res.partner")]
        [ForeignKey(nameof(PartnerId))]
        public virtual ResPartner? Partner { get; set; }
        
        [Column("pol_id")] public Guid? PolId { get; set; }
        [Many2one(RelatedModel = "purchase.order.line")]
        [ForeignKey(nameof(PolId))]
        public virtual PurchaseOrderLine? Pol { get; set; }
        
        [Column("product_id")] public Guid? ProductId { get; set; }
        [Many2one(RelatedModel = "product.product")]
        [ForeignKey(nameof(ProductId))]
        public virtual ProductProduct? Product { get; set; }
        
        [Column("product_uom_id")] public Guid? ProductUomId { get; set; }
        [Many2one(RelatedModel = "uom.uom")]
        [ForeignKey(nameof(ProductUomId))]
        public virtual UomUom? ProductUom { get; set; }
        
        [Column("purchase_order_id")] public Guid? PurchaseOrderId { get; set; }
        [Many2one(RelatedModel = "purchase.order")]
        [ForeignKey(nameof(PurchaseOrderId))]
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        
        [Column("qty_invoiced")]
        public double? QtyInvoiced { get; set; }
        
        [Column("state")]
        public string? State { get; set; }
    }
}