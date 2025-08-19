using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountFiscalPositionTemplate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountFiscalPositionTemplate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_fiscal_position_template_pkey");

            entity.ToTable("account_fiscal_position_template");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AutoApply).HasColumnName("auto_apply");
            entity.Property(e => e.ChartTemplateId).HasColumnName("chart_template_id");
            entity.Property(e => e.CountryGroupId).HasColumnName("country_group_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasColumnType("jsonb")
                .HasColumnName("note");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.VatRequired).HasColumnName("vat_required");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            entity.Property(e => e.ZipFrom).HasColumnName("zip_from");
            entity.Property(e => e.ZipTo).HasColumnName("zip_to");

            entity.HasOne(d => d.ChartTemplate).WithMany(p => p.AccountFiscalPositionTemplate)
                .HasForeignKey(d => d.ChartTemplateId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_fiscal_position_template_chart_template_id_fkey");

            entity.HasOne(d => d.CountryGroup).WithMany(p => p.AccountFiscalPositionTemplate)
                .HasForeignKey(d => d.CountryGroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_fiscal_position_template_country_group_id_fkey");

            // entity.HasOne(d => d.Country).WithMany(p => p.AccountFiscalPositionTemplate)
            entity.HasOne(d => d.Country).WithMany()
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_fiscal_position_template_country_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountFiscalPositionTemplateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_fiscal_position_template_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountFiscalPositionTemplateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_fiscal_position_template_write_uid_fkey");

            // entity.HasMany(d => d.ResCountryState).WithMany(p => p.AccountFiscalPositionTemplate)
            entity.HasMany(d => d.ResCountryState).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AccountFiscalPositionTemplateResCountryStateRel",
                    r => r.HasOne<ResCountryState>().WithMany()
                        .HasForeignKey("ResCountryStateId")
                        .HasConstraintName("account_fiscal_position_template_res__res_country_state_id_fkey"),
                    l => l.HasOne<AccountFiscalPositionTemplate>().WithMany()
                        .HasForeignKey("AccountFiscalPositionTemplateId")
                        .HasConstraintName("account_fiscal_position_templ_account_fiscal_position_temp_fkey"),
                    j =>
                    {
                        j.HasKey("AccountFiscalPositionTemplateId", "ResCountryStateId").HasName("account_fiscal_position_template_res_country_state_rel_pkey");
                        j.ToTable("account_fiscal_position_template_res_country_state_rel");
                        j.HasIndex(new[] { "ResCountryStateId", "AccountFiscalPositionTemplateId" }, "account_fiscal_position_templ_res_country_state_id_account__idx");
                        j.IndexerProperty<Guid>("AccountFiscalPositionTemplateId").HasColumnName("account_fiscal_position_template_id");
                        j.IndexerProperty<Guid>("ResCountryStateId").HasColumnName("res_country_state_id");
                    });
            });
        }
    }
}