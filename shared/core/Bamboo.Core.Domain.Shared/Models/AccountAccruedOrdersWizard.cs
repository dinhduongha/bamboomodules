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

[Table("account_accrued_orders_wizard")]
public partial class AccountAccruedOrdersWizard: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("reversal_date")]
    public DateTime? ReversalDate { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("AccountAccruedOrdersWizards")]
    [NotMapped]
    public virtual AccountAccount? Account { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAccruedOrdersWizards")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAccruedOrdersWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountAccruedOrdersWizards")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAccruedOrdersWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
