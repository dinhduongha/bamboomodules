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
public partial class AccountFinancialReport : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("level")]
    public long? Level { get; set; }

    [Column("account_report_id")]
    public Guid? AccountReportId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("AccountReportId")]
    //[InverseProperty("InverseAccountReport")]
    [NotMapped]
    public virtual AccountFinancialReport? AccountReport { get; set; }

    //[InverseProperty("AccountReport")]
    [NotMapped]
    public virtual ICollection<AccountingReport> AccountingReports { get; set; } = new List<AccountingReport>();

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountFinancialReportCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("AccountReport")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> InverseAccountReport { get; set; } = new List<AccountFinancialReport>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> InverseParent { get; set; } = new List<AccountFinancialReport>();

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual AccountFinancialReport? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountFinancialReportWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ReportId")]
    //[InverseProperty("Reports")]
    [NotMapped]
    public virtual ICollection<AccountAccountType> AccountTypes { get; set; } = new List<AccountAccountType>();

    [ForeignKey("ReportLineId")]
    //[InverseProperty("ReportLines2")]
    [NotMapped]
    public virtual ICollection<AccountAccount> Accounts { get; set; } = new List<AccountAccount>();
}
