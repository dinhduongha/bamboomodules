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
public partial class AccountFiscalPositionAccount: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("position_id")]
    public Guid? PositionId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("account_src_id")]
    public Guid? AccountSrcId { get; set; }

    [Column("account_dest_id")]
    public Guid? AccountDestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AccountDestId")]
    //[InverseProperty("AccountFiscalPositionAccountAccountDests")]
    [NotMapped]
    public virtual AccountAccount? AccountDest { get; set; }

    [ForeignKey("AccountSrcId")]
    //[InverseProperty("AccountFiscalPositionAccountAccountSrcs")]
    [NotMapped]
    public virtual AccountAccount? AccountSrc { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountFiscalPositionAccounts")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountFiscalPositionAccountCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PositionId")]
    //[InverseProperty("AccountFiscalPositionAccounts")]
    [NotMapped]
    public virtual AccountFiscalPosition? Position { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountFiscalPositionAccountWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
