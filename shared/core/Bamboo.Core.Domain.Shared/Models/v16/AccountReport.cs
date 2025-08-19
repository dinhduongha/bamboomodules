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
public partial class AccountReport: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("root_report_id")]
    public Guid? RootReportId { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("load_more_limit")]
    public long? LoadMoreLimit { get; set; }

    [Column("prefix_groups_threshold")]
    public long? PrefixGroupsThreshold { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    // v16-Compat
    //[Column("chart_template")]
    //public string? ChartTemplate { get; set; }

    [Column("availability_condition")]
    public string? AvailabilityCondition { get; set; }

    [Column("integer_rounding")]
    public string? IntegerRounding { get; set; }

    [Column("default_opening_date_filter")]
    public string? DefaultOpeningDateFilter { get; set; }

    [Column("currency_translation")]
    public string? CurrencyTranslation { get; set; }

    [Column("filter_multi_company")]
    public string? FilterMultiCompany { get; set; }

    [Column("filter_hide_0_lines")]
    public string? FilterHide0Lines { get; set; }

    [Column("filter_hierarchy")]
    public string? FilterHierarchy { get; set; }

    [Column("filter_account_type")]
    public string? FilterAccountType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("use_sections")]
    public bool? UseSections { get; set; }

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

    // v16-Compat
    //[Column("filter_account_type")]
    //public bool? FilterAccountType { get; set; }

    [Column("filter_partner")]
    public bool? FilterPartner { get; set; }

    [Column("filter_fiscal_position")]
    public bool? FilterFiscalPosition { get; set; }

    [Column("filter_aml_ir_filters")]
    public bool? FilterAmlIrFilters { get; set; }

    [Column("filter_budgets")]
    public bool? FilterBudgets { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("ReportId")]
    [InverseProperty("Report")]
    public virtual ICollection<AccountReportColumn> AccountReportColumn { get; set; }

    // [One2many]
    [ForeignKey("ReportId")]
    [InverseProperty("Report")]
    public virtual ICollection<AccountReportLine> AccountReportLine { get; set; }

    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    // [InverseProperty("AccountReport")] //Many2one
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("AccountReport")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountReportCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("RootReportId")]
    [InverseProperty("RootReport")]
    public virtual ICollection<AccountReport> InverseRootReport { get; set; }

    // [Many2one]
    [ForeignKey("RootReportId")]
    // [InverseProperty("InverseRootReport")] //Many2one
    public virtual AccountReport? RootReport { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountReportWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SubReportId")] //Many2many
    // [InverseProperty("SubReport")] //Many2many
    public virtual ICollection<AccountReport> MainReport { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MainReportId")] //Many2many
    // [InverseProperty("MainReport")] //Many2many
    public virtual ICollection<AccountReport> SubReport { get; set; }
}
