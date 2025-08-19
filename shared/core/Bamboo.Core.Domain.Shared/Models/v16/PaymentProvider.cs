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
//[Index("CompanyId", Name = "payment_provider__company_id_index")]
public partial class PaymentProvider: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("module_state")]
    public string? ModuleState { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("display_as", TypeName = "jsonb")]
    public string? DisplayAs { get; set; }

    [JsonField]
    [Column("pre_msg", TypeName = "jsonb")]
    public string? PreMsg { get; set; }

    [JsonField]
    [Column("pending_msg", TypeName = "jsonb")]
    public string? PendingMsg { get; set; }

    [JsonField]
    [Column("auth_msg", TypeName = "jsonb")]
    public string? AuthMsg { get; set; }

    [JsonField]
    [Column("done_msg", TypeName = "jsonb")]
    public string? DoneMsg { get; set; }

    [JsonField]
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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

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

    [Column("custom_mode")]
    public string? CustomMode { get; set; }

    [Column("qr_code")]
    public bool? QrCode { get; set; }

    [Column("authorize_login")]
    public string? AuthorizeLogin { get; set; }

    [Column("authorize_transaction_key")]
    public string? AuthorizeTransactionKey { get; set; }

    [Column("authorize_signature_key")]
    public string? AuthorizeSignatureKey { get; set; }

    [Column("authorize_client_key")]
    public string? AuthorizeClientKey { get; set; }

    // [One2many]
    [ForeignKey("PaymentProviderId")]
    [InverseProperty("PaymentProvider")]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PaymentProvider")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PaymentProviderCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ExpressCheckoutFormViewId")]
    // [InverseProperty("PaymentProviderExpressCheckoutFormView")] //Many2one
    public virtual IrUiView? ExpressCheckoutFormView { get; set; }

    // [Many2one]
    [ForeignKey("InlineFormViewId")]
    // [InverseProperty("PaymentProviderInlineFormView")] //Many2one
    public virtual IrUiView? InlineFormView { get; set; }

    // [Many2one]
    [ForeignKey("ModuleId")]
    // [InverseProperty("PaymentProvider")] //Many2one
    public virtual IrModuleModule? Module { get; set; }

    // [One2many]
    [ForeignKey("ProviderId")]
    [InverseProperty("Provider")]
    public virtual ICollection<PaymentToken> PaymentToken { get; set; }

    // [One2many]
    [ForeignKey("ProviderId")]
    [InverseProperty("Provider")]
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [Many2one]
    [ForeignKey("RedirectFormViewId")]
    // [InverseProperty("PaymentProviderRedirectFormView")] //Many2one
    public virtual IrUiView? RedirectFormView { get; set; }

    // [Many2one]
    [ForeignKey("TokenInlineFormViewId")]
    // [InverseProperty("PaymentProviderTokenInlineFormView")] //Many2one
    public virtual IrUiView? TokenInlineFormView { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("PaymentProvider")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PaymentProviderWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PaymentId")] //Many2many
    // [InverseProperty("Payment")] //Many2many
    public virtual ICollection<ResCountry> Country { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PaymentProviderId")] //Many2many
    // [InverseProperty("PaymentProvider")] //Many2many
    public virtual ICollection<ResCurrency> Currency { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PaymentProviderId")] //Many2many
    // [InverseProperty("PaymentProvider")] //Many2many
    public virtual ICollection<PaymentIcon> PaymentIcon { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PaymentProviderId")]
    // [InverseProperty("PaymentProvider")]
    public virtual ICollection<PaymentMethod> PaymentMethod { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PaymentProviderId")]
    // [InverseProperty("PaymentProvider")]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethod { get; set; }
}
