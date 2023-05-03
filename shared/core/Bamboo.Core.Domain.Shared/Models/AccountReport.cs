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

[Table("account_report")]
public partial class AccountReport: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("root_report_id")]
    public Guid? RootReportId { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("load_more_limit")]
    public long? LoadMoreLimit { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("availability_condition")]
    public string? AvailabilityCondition { get; set; }

    [Column("default_opening_date_filter")]
    public string? DefaultOpeningDateFilter { get; set; }

    [Column("filter_multi_company")]
    public string? FilterMultiCompany { get; set; }

    [Column("filter_hierarchy")]
    public string? FilterHierarchy { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("only_tax_exigible")]
    public bool? OnlyTaxExigible { get; set; }

    [Column("search_bar")]
    public bool? SearchBar { get; set; }

    [Column("filter_date_range")]
    public bool? FilterDateRange { get; set; }

    [Column("filter_show_draft")]
    public bool? FilterShowDraft { get; set; }

    [Column("filter_unreconciled")]
    public bool? FilterUnreconciled { get; set; }

    [Column("filter_unfold_all")]
    public bool? FilterUnfoldAll { get; set; }

    [Column("filter_period_comparison")]
    public bool? FilterPeriodComparison { get; set; }

    [Column("filter_growth_comparison")]
    public bool? FilterGrowthComparison { get; set; }

    [Column("filter_journals")]
    public bool? FilterJournals { get; set; }

    [Column("filter_analytic")]
    public bool? FilterAnalytic { get; set; }

    [Column("filter_account_type")]
    public bool? FilterAccountType { get; set; }

    [Column("filter_partner")]
    public bool? FilterPartner { get; set; }

    [Column("filter_fiscal_position")]
    public bool? FilterFiscalPosition { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ChartTemplateId")]
    //[InverseProperty("AccountReports")]
    [NotMapped]
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("AccountReports")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountReportCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("RootReportId")]
    //[InverseProperty("InverseRootReport")]
    [NotMapped]
    public virtual AccountReport? RootReport { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountReportWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Report")]
    [NotMapped]
    public virtual ICollection<AccountReportColumn> AccountReportColumns { get; } = new List<AccountReportColumn>();

    //[InverseProperty("Report")]
    [NotMapped]
    public virtual ICollection<AccountReportLine> AccountReportLines { get; } = new List<AccountReportLine>();

    //[InverseProperty("RootReport")]
    [NotMapped]
    public virtual ICollection<AccountReport> InverseRootReport { get; } = new List<AccountReport>();

}
