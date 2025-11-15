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

[Table("account_report")]
public partial class AccountReport : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("root_report_id")]
    public Guid? RootReportId { get; set; }

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

    [Column("chart_template")]
    public string? ChartTemplate { get; set; }

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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ReportId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Report")] // One2many
    public virtual ICollection<AccountReportColumn> AccountReportColumn { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ReportId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Report")] // One2many
    public virtual ICollection<AccountReportLine> AccountReportLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RootReportId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RootReport")] // One2many
    public virtual ICollection<AccountReport> InverseRootReport { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RootReportId")]
    public virtual AccountReport? RootReport { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SubReportId")] // Many2many // Normal
    // [InverseProperty("SubReport")] // Many2many // Normal
    public virtual ICollection<AccountReport> MainReport { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MainReportId")] // Many2many // Normal
    // [InverseProperty("MainReport")] // Many2many // Normal
    public virtual ICollection<AccountReport> SubReport { get; set; }
}
