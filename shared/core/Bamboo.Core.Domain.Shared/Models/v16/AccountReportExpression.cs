using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("account_report_expression")]
//[Index("ReportLineId", "Label", Name = "account_report_expression_line_label_uniq", IsUnique = true)]
public partial class AccountReportExpression: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("report_line_id")]
    public Guid? ReportLineId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TargetReportExpressionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TargetReportExpression")] // One2many
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValue { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ReportLineId")]
    public virtual AccountReportLine? ReportLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
