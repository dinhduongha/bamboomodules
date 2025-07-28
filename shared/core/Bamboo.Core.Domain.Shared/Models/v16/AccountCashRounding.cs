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

[Table("account_cash_rounding")]
public partial class AccountCashRounding : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("strategy")]
    public string? Strategy { get; set; }

    [Column("rounding_method")]
    public string? RoundingMethod { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("profit_account_id", TypeName = "jsonb")]
    public string? ProfitAccountId { get; set; }

    [JsonField]
    [Column("loss_account_id", TypeName = "jsonb")]
    public string? LossAccountId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("rounding")]
    public double? Rounding { get; set; }

    //[InverseProperty("InvoiceCashRounding")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } 

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountCashRoundingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("RoundingMethodNavigation")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; set; } 

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountCashRoundingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
