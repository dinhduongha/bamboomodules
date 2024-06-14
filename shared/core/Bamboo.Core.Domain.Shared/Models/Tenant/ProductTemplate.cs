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

[Table("product_template")]
//[Index("TenantId", Name = "product_template_company_id_index")]
//[Index("IsPublished", Name = "product_template_is_published_index")]
//[Index("WebsiteId", Name = "product_template_website_id_index")]
public partial class ProductTemplate: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("categ_id")]
    public long? CategId { get; set; }

    [Column("uom_id")]
    public Guid? UomId { get; set; }

    [Column("uom_po_id")]
    public Guid? UomPoId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("detailed_type")]
    public string? DetailedType { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("default_code")]
    public string? DefaultCode { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("description_purchase", TypeName = "jsonb")]
    public string? DescriptionPurchase { get; set; }

    [Column("description_sale", TypeName = "jsonb")]
    public string? DescriptionSale { get; set; }

    [Column("list_price")]
    public decimal? ListPrice { get; set; }

    [Column("volume")]
    public decimal? Volume { get; set; }

    [Column("weight")]
    public decimal? Weight { get; set; }

    [Column("sale_ok")]
    public bool? SaleOk { get; set; }

    [Column("purchase_ok")]
    public bool? PurchaseOk { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("can_image_1024_be_zoomed")]
    public bool? CanImage1024BeZoomed { get; set; }

    [Column("has_configurable_attributes")]
    public bool? HasConfigurableAttributes { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("service_type")]
    public string? ServiceType { get; set; }

    [Column("sale_line_warn")]
    public string? SaleLineWarn { get; set; }

    [Column("expense_policy")]
    public string? ExpensePolicy { get; set; }

    [Column("invoice_policy")]
    public string? InvoicePolicy { get; set; }

    [Column("sale_line_warn_msg")]
    public string? SaleLineWarnMsg { get; set; }

    [Column("tracking")]
    public string? Tracking { get; set; }

    [Column("description_picking", TypeName = "jsonb")]
    public string? DescriptionPicking { get; set; }

    [Column("description_pickingout", TypeName = "jsonb")]
    public string? DescriptionPickingout { get; set; }

    [Column("description_pickingin", TypeName = "jsonb")]
    public string? DescriptionPickingin { get; set; }

    [Column("sale_delay")]
    public double? SaleDelay { get; set; }

    [Column("pos_categ_id")]
    public long? PosCategId { get; set; }

    [Column("available_in_pos")]
    public bool? AvailableInPos { get; set; }

    [Column("to_weight")]
    public bool? ToWeight { get; set; }

    [Column("purchase_method")]
    public string? PurchaseMethod { get; set; }

    [Column("purchase_line_warn")]
    public string? PurchaseLineWarn { get; set; }

    [Column("purchase_line_warn_msg")]
    public string? PurchaseLineWarnMsg { get; set; }

    [Column("produce_delay")]
    public double? ProduceDelay { get; set; }

    [Column("days_to_prepare_mo")]
    public double? DaysToPrepareMo { get; set; }

    [Column("service_tracking")]
    public string? ServiceTracking { get; set; }

    [Column("can_be_expensed")]
    public bool? CanBeExpensed { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("website_size_x")]
    public long? WebsiteSizeX { get; set; }

    [Column("website_size_y")]
    public long? WebsiteSizeY { get; set; }

    [Column("website_ribbon_id")]
    public Guid? WebsiteRibbonId { get; set; }

    [Column("website_sequence")]
    public long? WebsiteSequence { get; set; }

    [Column("base_unit_id")]
    public Guid? BaseUnitId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [Column("website_description", TypeName = "jsonb")]
    public string? WebsiteDescription { get; set; }

    [Column("compare_list_price")]
    public decimal? CompareListPrice { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("rating_last_value")]
    public double? RatingLastValue { get; set; }

    [Column("base_unit_count")]
    public double? BaseUnitCount { get; set; }

    [Column("out_of_stock_message", TypeName = "jsonb")]
    public string? OutOfStockMessage { get; set; }

    [Column("allow_out_of_stock_order")]
    public bool? AllowOutOfStockOrder { get; set; }

    [Column("show_availability")]
    public bool? ShowAvailability { get; set; }

    [Column("available_threshold")]
    public double? AvailableThreshold { get; set; }

    [ForeignKey("BaseUnitId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual WebsiteBaseUnit? BaseUnit { get; set; }

    [ForeignKey("CategId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual ProductCategory? Categ { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PosCategId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual PosCategory? PosCateg { get; set; }

    [ForeignKey("UomId")]
    //[InverseProperty("ProductTemplateUoms")]
    [NotMapped]
    public virtual UomUom? Uom { get; set; }

    [ForeignKey("UomPoId")]
    //[InverseProperty("ProductTemplateUomPos")]
    [NotMapped]
    public virtual UomUom? UomPo { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("WebsiteRibbonId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual ProductRibbon? WebsiteRibbon { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; } = new List<MrpBomLine>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; } = new List<MrpBom>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; } = new List<ProductPricelistItem>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; } = new List<ProductProduct>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; } = new List<ProductReplenish>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; } = new List<ProductSupplierinfo>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusions { get; } = new List<ProductTemplateAttributeExclusion>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLines { get; } = new List<ProductTemplateAttributeLine>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; } = new List<ProductTemplateAttributeValue>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<StockChangeProductQty> StockChangeProductQties { get; } = new List<StockChangeProductQty>();

    //[InverseProperty("ProductTmpl")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReports { get; } = new List<StockRulesReport>();

    [ForeignKey("ProductTemplateId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTags { get; } = new List<AccountAccountTag>();

    //[ForeignKey("SrcId")]
    //[InverseProperty("Srcs")]
    [NotMapped]
    public virtual ICollection<ProductProduct> Dests { get; } = new List<ProductProduct>();

    //[ForeignKey("SrcId")]
    //[InverseProperty("SrcsNavigation")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> Dests1 { get; } = new List<ProductTemplate>();

    //[ForeignKey("SrcId")]
    //[InverseProperty("Srcs")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> DestsNavigation { get; } = new List<ProductTemplate>();

    [ForeignKey("ProductTemplateId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual ICollection<ProductAttribute> ProductAttributes { get; } = new List<ProductAttribute>();

    [ForeignKey("ProductTemplateId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayouts { get; } = new List<ProductLabelLayout>();

    [ForeignKey("ProductTemplateId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual ICollection<ProductPublicCategory> ProductPublicCategories { get; } = new List<ProductPublicCategory>();

    [ForeignKey("ProductTemplateId")]
    //[InverseProperty("ProductTemplates")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTags { get; } = new List<ProductTag>();

    [ForeignKey("ProductId")]
    //[InverseProperty("Products")]
    [NotMapped]
    public virtual ICollection<StockRoute> Routes { get; } = new List<StockRoute>();

    //[ForeignKey("DestId")]
    //[InverseProperty("DestsNavigation")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> Srcs { get; } = new List<ProductTemplate>();

    //[ForeignKey("DestId")]
    //[InverseProperty("Dests1")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> SrcsNavigation { get; } = new List<ProductTemplate>();

    //[ForeignKey("ProdId")]
    //[InverseProperty("Prods")]
    [NotMapped]
    public virtual ICollection<AccountTax> Taxes { get; } = new List<AccountTax>();

    //[ForeignKey("ProdId")]
    //[InverseProperty("ProdsNavigation")]
    [NotMapped]
    public virtual ICollection<AccountTax> TaxesNavigation { get; } = new List<AccountTax>();
}
