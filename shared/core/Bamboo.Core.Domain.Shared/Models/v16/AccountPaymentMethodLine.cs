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

[Table("account_payment_method_line")]
public partial class AccountPaymentMethodLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("payment_method_id")]
    public Guid? PaymentMethodId { get; set; }

    [Column("payment_account_id")]
    public Guid? PaymentAccountId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("payment_provider_id")]
    public Guid? PaymentProviderId { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PreferredPaymentMethodLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PreferredPaymentMethodLine")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PaymentMethodLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentMethodLine")] // One2many
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PaymentMethodLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentMethodLine")] // One2many
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PaymentMethodLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentMethodLine")] // One2many
    public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("PaymentAccountId")]
    public virtual AccountAccount? PaymentAccount { get; set; }

    // [Many2one]
    [ForeignKey("PaymentMethodId")]
    public virtual AccountPaymentMethod? PaymentMethod { get; set; }

    // [Many2one]
    [ForeignKey("PaymentProviderId")]
    public virtual PaymentProvider? PaymentProvider { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden

    [NotMapped] //Many2many // Hidden // Peer relationship (ResCompany) is commented out
    // [ForeignKey("AccountPaymentMethodLineId")] //Many2many // Hidden
    // [InverseProperty("AccountPaymentMethodLine")] //Many2many // Hidden
    public virtual ICollection<ResCompany> ResCompany { get; set; }
}
