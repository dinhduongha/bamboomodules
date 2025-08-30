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

[Table("res_partner_bank")]
//[Index("PartnerId", Name = "res_partner_bank__partner_id_index")]
//[Index("SanitizedAccNumber", "PartnerId", Name = "res_partner_bank_unique_number", IsUnique = true)]
public partial class ResPartnerBank: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("bank_id")]
    public Guid? BankId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("acc_number")]
    public string? AccNumber { get; set; }

    [Column("sanitized_acc_number")]
    public string? SanitizedAccNumber { get; set; }

    [Column("acc_holder_name")]
    public string? AccHolderName { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("allow_out_payment")]
    public bool? AllowOutPayment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("aba_routing")]
    public string? AbaRouting { get; set; }

    [Column("has_iban_warning")]
    public bool? HasIbanWarning { get; set; }

    [Column("has_money_transfer_warning")]
    public bool? HasMoneyTransferWarning { get; set; }

    [Column("proxy_type")]
    public string? ProxyType { get; set; }

    [Column("proxy_value")]
    public string? ProxyValue { get; set; }

    [Column("include_reference")]
    public bool? IncludeReference { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BankAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BankAccount")] // One2many
    public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PartnerBankId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PartnerBank")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PartnerBankId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PartnerBank")] // One2many
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PartnerBankId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PartnerBank")] // One2many
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResPartnerBankId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResPartnerBank")] // One2many
    public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfig { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BankId")]
    public virtual ResBank? Bank { get; set; }

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
    // [One2many] [ForeignKey("BankAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BankAccount")] // One2many
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
