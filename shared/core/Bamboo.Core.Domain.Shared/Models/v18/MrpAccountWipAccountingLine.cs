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

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("wip_accounting_id")]
    public Guid? WipAccountingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("label")]
    public string? Label { get; set; }

    [Column("debit")]
    public decimal? Debit { get; set; }

    [Column("credit")]
    public decimal? Credit { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccountId")]
    // [InverseProperty("MrpAccountWipAccountingLine")] //Many2one
    public virtual AccountAccount? Account { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MrpAccountWipAccountingLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("MrpAccountWipAccountingLine")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("WipAccountingId")]
    // [InverseProperty("MrpAccountWipAccountingLine")] //Many2one
    public virtual MrpAccountWipAccounting? WipAccounting { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MrpAccountWipAccountingLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
