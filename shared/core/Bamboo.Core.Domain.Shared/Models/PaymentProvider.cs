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

[Table("payment_provider")]
//[Index("TenantId", Name = "payment_provider_company_id_index")]
public partial class PaymentProvider: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("redirect_form_view_id")]
    public Guid? RedirectFormViewId { get; set; }

    [Column("inline_form_view_id")]
    public Guid? InlineFormViewId { get; set; }

    [Column("token_inline_form_view_id")]
    public Guid? TokenInlineFormViewId { get; set; }

    [Column("express_checkout_form_view_id")]
    public Guid? ExpressCheckoutFormViewId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("module_id")]
    public Guid? ModuleId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("module_state")]
    public string? ModuleState { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("display_as", TypeName = "jsonb")]
    public string? DisplayAs { get; set; }

    [Column("pre_msg", TypeName = "jsonb")]
    public string? PreMsg { get; set; }

    [Column("pending_msg", TypeName = "jsonb")]
    public string? PendingMsg { get; set; }

    [Column("auth_msg", TypeName = "jsonb")]
    public string? AuthMsg { get; set; }

    [Column("done_msg", TypeName = "jsonb")]
    public string? DoneMsg { get; set; }

    [Column("cancel_msg", TypeName = "jsonb")]
    public string? CancelMsg { get; set; }

    [Column("maximum_amount")]
    public decimal? MaximumAmount { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("allow_tokenization")]
    public bool? AllowTokenization { get; set; }

    [Column("capture_manually")]
    public bool? CaptureManually { get; set; }

    [Column("allow_express_checkout")]
    public bool? AllowExpressCheckout { get; set; }

    [Column("fees_active")]
    public bool? FeesActive { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("fees_dom_fixed")]
    public double? FeesDomFixed { get; set; }

    [Column("fees_dom_var")]
    public double? FeesDomVar { get; set; }

    [Column("fees_int_fixed")]
    public double? FeesIntFixed { get; set; }

    [Column("fees_int_var")]
    public double? FeesIntVar { get; set; }

    [Column("so_reference_type")]
    public string? SoReferenceType { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("PaymentProviders")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PaymentProviderCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ExpressCheckoutFormViewId")]
    //[InverseProperty("PaymentProviderExpressCheckoutFormViews")]
    [NotMapped]
    public virtual IrUiView? ExpressCheckoutFormView { get; set; }

    [ForeignKey("InlineFormViewId")]
    //[InverseProperty("PaymentProviderInlineFormViews")]
    [NotMapped]
    public virtual IrUiView? InlineFormView { get; set; }

    [ForeignKey("ModuleId")]
    //[InverseProperty("PaymentProviders")]
    [NotMapped]
    public virtual IrModuleModule? Module { get; set; }

    [ForeignKey("RedirectFormViewId")]
    //[InverseProperty("PaymentProviderRedirectFormViews")]
    [NotMapped]
    public virtual IrUiView? RedirectFormView { get; set; }

    [ForeignKey("TokenInlineFormViewId")]
    //[InverseProperty("PaymentProviderTokenInlineFormViews")]
    [NotMapped]
    public virtual IrUiView? TokenInlineFormView { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("PaymentProviders")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PaymentProviderWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("PaymentProvider")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLines { get; } = new List<AccountPaymentMethodLine>();

    //[InverseProperty("Provider")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokens { get; } = new List<PaymentToken>();

    //[InverseProperty("Provider")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

    [ForeignKey("PaymentId")]
    //[InverseProperty("Payments")]
    [NotMapped]
    public virtual ICollection<ResCountry> Countries { get; } = new List<ResCountry>();

    [ForeignKey("PaymentProviderId")]
    //[InverseProperty("PaymentProviders")]
    [NotMapped]
    public virtual ICollection<PaymentIcon> PaymentIcons { get; } = new List<PaymentIcon>();
}
