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

[Table("account_fiscal_position_tax_template")]
public partial class AccountFiscalPositionTaxTemplate: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("position_id")]
    public Guid? PositionId { get; set; }

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

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountFiscalPositionTaxTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PositionId")]
    //[InverseProperty("AccountFiscalPositionTaxTemplates")]
    [NotMapped]
    public virtual AccountFiscalPositionTemplate? Position { get; set; }

    [ForeignKey("TaxDestId")]
    //[InverseProperty("AccountFiscalPositionTaxTemplateTaxDests")]
    [NotMapped]
    public virtual AccountTaxTemplate? TaxDest { get; set; }

    [ForeignKey("TaxSrcId")]
    //[InverseProperty("AccountFiscalPositionTaxTemplateTaxSrcs")]
    [NotMapped]
    public virtual AccountTaxTemplate? TaxSrc { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountFiscalPositionTaxTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
