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

[Table("account_tax_group")]
public partial class AccountTaxGroup: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("tax_payable_account_id")]
    public Guid? TaxPayableAccountId { get; set; }

    [Column("tax_receivable_account_id")]
    public Guid? TaxReceivableAccountId { get; set; }

    [Column("advance_tax_payment_account_id")]
    public Guid? AdvanceTaxPaymentAccountId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("pos_receipt_label")]
    public string? PosReceiptLabel { get; set; }

    // v
    //[Column("preceding_subtotal")]16-Compat
    //public string? PrecedingSubtotal { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("preceding_subtotal", TypeName = "jsonb")]
    public string? PrecedingSubtotal { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("TaxGroupId")]
    [InverseProperty("TaxGroup")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many]
    [ForeignKey("TaxGroupId")]
    [InverseProperty("TaxGroup")]
    public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [Many2one]
    [ForeignKey("AdvanceTaxPaymentAccountId")]
    // [InverseProperty("AccountTaxGroupAdvanceTaxPaymentAccount")] //Many2one
    public virtual AccountAccount? AdvanceTaxPaymentAccount { get; set; }


    // [One2many]
    [ForeignKey("TaxGroupId")]
    [InverseProperty("TaxGroup")]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplate { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountTaxGroup")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("AccountTaxGroup")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountTaxGroupCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("TaxPayableAccountId")]
    // [InverseProperty("AccountTaxGroupTaxPayableAccount")] //Many2one
    public virtual AccountAccount? TaxPayableAccount { get; set; }

    // [Many2one]
    [ForeignKey("TaxReceivableAccountId")]
    // [InverseProperty("AccountTaxGroupTaxReceivableAccount")] //Many2one
    public virtual AccountAccount? TaxReceivableAccount { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountTaxGroupWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
