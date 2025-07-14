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

[Table("mrp_account_wip_accounting_line")]
public partial class MrpAccountWipAccountingLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("wip_accounting_id")]
    public Guid? WipAccountingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("label")]
    public string? Label { get; set; }

    [Column("debit")]
    public decimal? Debit { get; set; }

    [Column("credit")]
    public decimal? Credit { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("MrpAccountWipAccountingLines")]
    [NotMapped]
    public virtual AccountAccount? Account { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpAccountWipAccountingLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("MrpAccountWipAccountingLines")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("WipAccountingId")]
    //[InverseProperty("MrpAccountWipAccountingLines")]
    [NotMapped]
    public virtual MrpAccountWipAccounting? WipAccounting { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpAccountWipAccountingLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
