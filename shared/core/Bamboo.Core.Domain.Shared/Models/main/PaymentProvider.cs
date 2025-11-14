using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField] // PreMsg
    [Column("pre_msg", TypeName = "jsonb")]
    public JsonElement? PreMsg { get; set; }

    [JsonField] // PendingMsg
    [Column("pending_msg", TypeName = "jsonb")]
    public JsonElement? PendingMsg { get; set; }

    [JsonField] // AuthMsg
    [Column("auth_msg", TypeName = "jsonb")]
    public JsonElement? AuthMsg { get; set; }

    [JsonField] // DoneMsg
    [Column("done_msg", TypeName = "jsonb")]
    public JsonElement? DoneMsg { get; set; }

    [JsonField] // CancelMsg
    [Column("cancel_msg", TypeName = "jsonb")]
    public JsonElement? CancelMsg { get; set; }

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

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentProviderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentProvider")] // One2many
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpressCheckoutFormViewId")]
    public virtual IrUiView? ExpressCheckoutFormView { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("InlineFormViewId")]
    public virtual IrUiView? InlineFormView { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ModuleId")]
    public virtual IrModuleModule? Module { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProviderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Provider")] // One2many
    public virtual ICollection<PaymentToken> PaymentToken { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProviderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Provider")] // One2many
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RedirectFormViewId")]
    public virtual IrUiView? RedirectFormView { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TokenInlineFormViewId")]
    public virtual IrUiView? TokenInlineFormView { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCountry) is commented out
    // [ForeignKey("PaymentId")] // Many2many // Normal
    // [InverseProperty("Payment")] // Many2many // Normal
    public virtual ICollection<ResCountry> Country { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCurrency) is commented out
    // [ForeignKey("PaymentProviderId")] // Many2many // Normal
    // [InverseProperty("PaymentProvider")] // Many2many // Normal
    public virtual ICollection<ResCurrency> Currency { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PaymentProviderId")] //Many2many // Hidden
    // [InverseProperty("PaymentProvider")] //Many2many // Hidden
    public virtual ICollection<PaymentMethod> PaymentMethod { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PaymentProviderId")] //Many2many // Hidden
    // [InverseProperty("PaymentProvider")] //Many2many // Hidden
    public virtual ICollection<PosPaymentMethod> PosPaymentMethod { get; set; }
}
