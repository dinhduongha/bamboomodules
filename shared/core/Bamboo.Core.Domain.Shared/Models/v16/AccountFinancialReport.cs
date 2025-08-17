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

[Table("account_financial_report")]
public partial class AccountFinancialReport: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("level")]
    public long? Level { get; set; }

    [Column("account_report_id")]
    public Guid? AccountReportId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("report_domain")]
    public string? ReportDomain { get; set; }

    [Column("sign")]
    public string? Sign { get; set; }

    [Column("display_detail")]
    public string? DisplayDetail { get; set; }

    [Column("style_overwrite")]
    public string? StyleOverwrite { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccountReportId")]
    // [InverseProperty("InverseAccountReport")] //Many2one
    public virtual AccountFinancialReport? AccountReport { get; set; }

    // [One2many]
    [ForeignKey("AccountReportId")]
    [InverseProperty("AccountReport")]
    public virtual ICollection<AccountingReport> AccountingReport { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountFinancialReportCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("AccountReportId")]
    [InverseProperty("AccountReport")]
    public virtual ICollection<AccountFinancialReport> InverseAccountReport { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<AccountFinancialReport> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual AccountFinancialReport? Parent { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountFinancialReportWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ReportLineId")] //Many2many
    // [InverseProperty("ReportLine2")] //Many2many
    public virtual ICollection<AccountAccount> Account { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ReportId")] //Many2many
    // [InverseProperty("Report")] //Many2many
    public virtual ICollection<AccountAccountType> AccountType { get; set; }
}
