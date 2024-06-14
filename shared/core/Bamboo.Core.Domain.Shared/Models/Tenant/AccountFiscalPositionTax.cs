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

[Table("account_fiscal_position_tax")]
//[Index("PositionId", "TaxSrcId", "TaxDestId", Name = "account_fiscal_position_tax_tax_src_dest_uniq", IsUnique = true)]
public partial class AccountFiscalPositionTax: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("position_id")]
    public Guid? PositionId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("tax_src_id")]
    public Guid? TaxSrcId { get; set; }

    [Column("tax_dest_id")]
    public Guid? TaxDestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountFiscalPositionTaxes")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountFiscalPositionTaxCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PositionId")]
    //[InverseProperty("AccountFiscalPositionTaxes")]
    [NotMapped]
    public virtual AccountFiscalPosition? Position { get; set; }

    [ForeignKey("TaxDestId")]
    //[InverseProperty("AccountFiscalPositionTaxTaxDests")]
    [NotMapped]
    public virtual AccountTax? TaxDest { get; set; }

    [ForeignKey("TaxSrcId")]
    //[InverseProperty("AccountFiscalPositionTaxTaxSrcs")]
    [NotMapped]
    public virtual AccountTax? TaxSrc { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountFiscalPositionTaxWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
