using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountReport(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountReport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_report_pkey");

                entity.ToTable("account_report");

                entity.HasIndex(e => e.TenantId, "account_report_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AvailabilityCondition).HasColumnName("availability_condition");
                entity.Property(e => e.ChartTemplate).HasColumnName("chart_template");
                entity.Property(e => e.ChartTemplateId).HasColumnName("chart_template_id");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyTranslation).HasColumnName("currency_translation");
                entity.Property(e => e.DefaultOpeningDateFilter).HasColumnName("default_opening_date_filter");
                entity.Property(e => e.FilterAccountType).HasColumnName("filter_account_type");
                entity.Property(e => e.FilterAmlIrFilters).HasColumnName("filter_aml_ir_filters");
                entity.Property(e => e.FilterAnalytic).HasColumnName("filter_analytic");
                entity.Property(e => e.FilterBudgets).HasColumnName("filter_budgets");
                entity.Property(e => e.FilterDateRange).HasColumnName("filter_date_range");
                entity.Property(e => e.FilterFiscalPosition).HasColumnName("filter_fiscal_position");
                entity.Property(e => e.FilterGrowthComparison).HasColumnName("filter_growth_comparison");
                entity.Property(e => e.FilterHide0Lines).HasColumnName("filter_hide_0_lines");
                entity.Property(e => e.FilterHierarchy).HasColumnName("filter_hierarchy");
                entity.Property(e => e.FilterJournals).HasColumnName("filter_journals");
                entity.Property(e => e.FilterMultiCompany).HasColumnName("filter_multi_company");
                entity.Property(e => e.FilterPartner).HasColumnName("filter_partner");
                entity.Property(e => e.FilterPeriodComparison).HasColumnName("filter_period_comparison");
                entity.Property(e => e.FilterShowDraft).HasColumnName("filter_show_draft");
                entity.Property(e => e.FilterUnfoldAll).HasColumnName("filter_unfold_all");
                entity.Property(e => e.FilterUnreconciled).HasColumnName("filter_unreconciled");
                entity.Property(e => e.IntegerRounding).HasColumnName("integer_rounding");
                entity.Property(e => e.LoadMoreLimit).HasColumnName("load_more_limit");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.OnlyTaxExigible).HasColumnName("only_tax_exigible");
                entity.Property(e => e.PrefixGroupsThreshold).HasColumnName("prefix_groups_threshold");
                entity.Property(e => e.RootReportId).HasColumnName("root_report_id");
                entity.Property(e => e.SearchBar).HasColumnName("search_bar");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.UseSections).HasColumnName("use_sections");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                // v16-Compat
                entity.HasOne(d => d.ChartTemplateObject).WithMany(p => p.AccountReports)
                    .HasForeignKey(d => d.ChartTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_chart_template_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_create_uid_fkey");

                entity.HasOne(d => d.RootReport).WithMany(p => p.InverseRootReport)
                    .HasForeignKey(d => d.RootReportId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_root_report_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_write_uid_fkey");

                entity.HasMany(d => d.MainReports).WithMany(p => p.SubReports)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReportSectionRel",
                        r => r.HasOne<AccountReport>().WithMany()
                            .HasForeignKey("MainReportId")
                            .HasConstraintName("account_report_section_rel_main_report_id_fkey"),
                        l => l.HasOne<AccountReport>().WithMany()
                            .HasForeignKey("SubReportId")
                            .HasConstraintName("account_report_section_rel_sub_report_id_fkey"),
                        j =>
                        {
                            j.HasKey("MainReportId", "SubReportId").HasName("account_report_section_rel_pkey");
                            j.ToTable("account_report_section_rel");
                            j.HasIndex(new[] { "SubReportId", "MainReportId" }, "account_report_section_rel_sub_report_id_main_report_id_idx");
                            j.IndexerProperty<Guid>("MainReportId").HasColumnName("main_report_id");
                            j.IndexerProperty<Guid>("SubReportId").HasColumnName("sub_report_id");
                        });

                entity.HasMany(d => d.SubReports).WithMany(p => p.MainReports)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReportSectionRel",
                        r => r.HasOne<AccountReport>().WithMany()
                            .HasForeignKey("SubReportId")
                            .HasConstraintName("account_report_section_rel_sub_report_id_fkey"),
                        l => l.HasOne<AccountReport>().WithMany()
                            .HasForeignKey("MainReportId")
                            .HasConstraintName("account_report_section_rel_main_report_id_fkey"),
                        j =>
                        {
                            j.HasKey("MainReportId", "SubReportId").HasName("account_report_section_rel_pkey");
                            j.ToTable("account_report_section_rel");
                            j.HasIndex(new[] { "SubReportId", "MainReportId" }, "account_report_section_rel_sub_report_id_main_report_id_idx");
                            j.IndexerProperty<Guid>("MainReportId").HasColumnName("main_report_id");
                            j.IndexerProperty<Guid>("SubReportId").HasColumnName("sub_report_id");
                        });
            });
        }
    }
}