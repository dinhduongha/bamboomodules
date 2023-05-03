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

[Table("account_report_external_value")]
public partial class AccountReportExternalValue: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("target_report_expression_id")]
    public Guid? TargetReportExpressionId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("foreign_vat_fiscal_position_id")]
    public Guid? ForeignVatFiscalPositionId { get; set; }

    [Column("carryover_origin_report_line_id")]
    public Guid? CarryoverOriginReportLineId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("carryover_origin_expression_label")]
    public string? CarryoverOriginExpressionLabel { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("value")]
    public double? Value { get; set; }

    [ForeignKey("CarryoverOriginReportLineId")]
    //[InverseProperty("AccountReportExternalValues")]
    [NotMapped]
    public virtual AccountReportLine? CarryoverOriginReportLine { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountReportExternalValues")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountReportExternalValueCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ForeignVatFiscalPositionId")]
    //[InverseProperty("AccountReportExternalValues")]
    [NotMapped]
    public virtual AccountFiscalPosition? ForeignVatFiscalPosition { get; set; }

    [ForeignKey("TargetReportExpressionId")]
    //[InverseProperty("AccountReportExternalValues")]
    [NotMapped]
    public virtual AccountReportExpression? TargetReportExpression { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountReportExternalValueWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
