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

[Table("account_fiscal_position_account")]
//[Index("PositionId", "AccountSrcId", "AccountDestId", Name = "account_fiscal_position_account_account_src_dest_uniq", IsUnique = true)]
public partial class AccountFiscalPositionAccount: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("position_id")]
    public Guid? PositionId { get; set; }

    [Column("account_src_id")]
    public Guid? AccountSrcId { get; set; }

    [Column("account_dest_id")]
    public Guid? AccountDestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccountDestId")]
    // [InverseProperty("AccountFiscalPositionAccountAccountDest")] //Many2one
    public virtual AccountAccount? AccountDest { get; set; }

    // [Many2one]
    [ForeignKey("AccountSrcId")]
    // [InverseProperty("AccountFiscalPositionAccountAccountSrc")] //Many2one
    public virtual AccountAccount? AccountSrc { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountFiscalPositionAccount")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountFiscalPositionAccountCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("PositionId")]
    // [InverseProperty("AccountFiscalPositionAccount")] //Many2one
    public virtual AccountFiscalPosition? Position { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountFiscalPositionAccountWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
