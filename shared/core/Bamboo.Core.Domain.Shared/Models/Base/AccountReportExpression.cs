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

[Table("account_report_expression")]
public partial class AccountReportExpression: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("report_line_id")]
    public Guid? ReportLineId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("label")]
    public string? Label { get; set; }

    [Column("engine")]
    public string? Engine { get; set; }

    [Column("formula")]
    public string? Formula { get; set; }

    [Column("subformula")]
    public string? Subformula { get; set; }

    [Column("date_scope")]
    public string? DateScope { get; set; }

    [Column("figure_type")]
    public string? FigureType { get; set; }

    [Column("carryover_target")]
    public string? CarryoverTarget { get; set; }

    [Column("green_on_positive")]
    public bool? GreenOnPositive { get; set; }

    [Column("blank_if_zero")]
    public bool? BlankIfZero { get; set; }

    [Column("auditable")]
    public bool? Auditable { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountReportExpressionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ReportLineId")]
    //[InverseProperty("AccountReportExpressions")]
    [NotMapped]
    public virtual AccountReportLine? ReportLine { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountReportExpressionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("TargetReportExpression")]
    [NotMapped]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValues { get; } = new List<AccountReportExternalValue>();

    [ForeignKey("AccountReportExpressionId")]
    //[InverseProperty("AccountReportExpressions")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplates { get; } = new List<AccountTaxRepartitionLineTemplate>();

    [ForeignKey("AccountReportExpressionId")]
    //[InverseProperty("AccountReportExpressionsNavigation")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplatesNavigation { get; } = new List<AccountTaxRepartitionLineTemplate>();
}
