using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Module("base")]
[Table("res_partner_bank")]
//[Index("PartnerId", Name = "res_partner_bank_partner_id_index")]
//[Index("SanitizedAccNumber", "PartnerId", Name = "res_partner_bank_unique_number", IsUnique = true)]
public partial class ResPartnerBank: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("bank_id")]
    public Guid? BankId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

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

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("ResPartnerBanks")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("BankId")]
    //[InverseProperty("ResPartnerBanks")]
    [NotMapped]
    public virtual ResBank? Bank { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ResPartnerBanks")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResPartnerBankCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("ResPartnerBanks")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ResPartnerBanks")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResPartnerBankWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE COLLECTIONS
    //[InverseProperty("BankAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } 

    //[InverseProperty("PartnerBank")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } 

    //[InverseProperty("PartnerBank")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; set; } 

    //[InverseProperty("PartnerBank")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; set; } 

    //[InverseProperty("ResPartnerBank")]
    [NotMapped]
    public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfigs { get; set; } 

    //[InverseProperty("BankAccount")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } 
}
