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

[Table("loyalty_card_update_balance")]
public partial class LoyaltyCardUpdateBalance: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("card_id")]
    public Guid? CardId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("new_balance")]
    public double? NewBalance { get; set; }

    [ForeignKey("CardId")]
    //[InverseProperty("LoyaltyCardUpdateBalances")] //Many2One
    public virtual LoyaltyCard? Card { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("LoyaltyCardUpdateBalanceCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LoyaltyCardUpdateBalanceWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
