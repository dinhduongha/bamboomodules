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

[Table("res_partner_bank")]
//[Index("PartnerId", Name = "res_partner_bank_partner_id_index")]
//[Index("SanitizedAccNumber", "PartnerId", Name = "res_partner_bank_unique_number", IsUnique = true)]
public partial class ResPartnerBank: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("bank_id")]
    public Guid? BankId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("ResPartnerBanks")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ResPartnerBanks")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResPartnerBankWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("BankAccount")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    //[InverseProperty("BankAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    //[InverseProperty("PartnerBank")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("PartnerBank")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; } = new List<AccountPaymentRegister>();

    //[InverseProperty("PartnerBank")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; } = new List<AccountPayment>();

    //[InverseProperty("ResPartnerBank")]
    [NotMapped]
    public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfigs { get; } = new List<AccountSetupBankManualConfig>();

}
