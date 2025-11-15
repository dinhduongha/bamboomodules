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

[Table("payment_transaction")]
//[Index("CompanyId", Name = "payment_transaction__company_id_index")]
//[Index("Operation", Name = "payment_transaction__operation_index")]
//[Index("State", Name = "payment_transaction__state_index")]
//[Index("Reference", Name = "payment_transaction_reference_uniq", IsUnique = true)]
public partial class PaymentTransaction : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("provider_id")]
    public Guid? ProviderId { get; set; }

    [Column("payment_method_id")]
    public Guid? PaymentMethodId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("token_id")]
    public Guid? TokenId { get; set; }

    [Column("source_transaction_id")]
    public Guid? SourceTransactionId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("partner_state_id")]
    public Guid? PartnerStateId { get; set; }

    [Column("partner_country_id")]
    public Guid? PartnerCountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("provider_reference")]
    public string? ProviderReference { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("operation")]
    public string? Operation { get; set; }

    [Column("landing_route")]
    public string? LandingRoute { get; set; }

    [Column("partner_name")]
    public string? PartnerName { get; set; }

    [Column("partner_lang")]
    public string? PartnerLang { get; set; }

    [Column("partner_email")]
    public string? PartnerEmail { get; set; }

    [Column("partner_address")]
    public string? PartnerAddress { get; set; }

    [Column("partner_zip")]
    public string? PartnerZip { get; set; }

    [Column("partner_city")]
    public string? PartnerCity { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("state_message")]
    public string? StateMessage { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("is_post_processed")]
    public bool? IsPostProcessed { get; set; }

    [Column("tokenize")]
    public bool? Tokenize { get; set; }

    [Column("last_state_change", TypeName = "timestamp without time zone")]
    public DateTime? LastStateChange { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("payment_id")]
    public Guid? PaymentId { get; set; }

    [Column("pos_order_id")]
    public Guid? PosOrderId { get; set; }

    [Column("is_donation")]
    public bool? IsDonation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentTransactionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentTransaction")] // One2many
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

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
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SourceTransactionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SourceTransaction")] // One2many
    public virtual ICollection<PaymentTransaction> InverseSourceTransaction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerCountryId")]
    public virtual ResCountry? PartnerCountry { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerStateId")]
    public virtual ResCountryState? PartnerState { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentId")]
    public virtual AccountPayment? Payment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentMethodId")]
    public virtual PaymentMethod? PaymentMethod { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PosOrderId")]
    public virtual PosOrder? PosOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProviderId")]
    public virtual PaymentProvider? Provider { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SourceTransactionId")]
    public virtual PaymentTransaction? SourceTransaction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TokenId")]
    public virtual PaymentToken? Token { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TransactionId")] //Many2many // Hidden
    // [InverseProperty("Transaction")] //Many2many // Hidden
    public virtual ICollection<AccountMove> Invoice { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PaymentTransactionId")] //Many2many // Hidden
    // [InverseProperty("PaymentTransaction")] //Many2many // Hidden
    public virtual ICollection<PaymentCaptureWizard> PaymentCaptureWizard { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("TransactionId")] // Many2many // Normal
    // [InverseProperty("Transaction")] // Many2many // Normal
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }
}
