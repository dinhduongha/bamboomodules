using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSpreadsheetDashboard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SpreadsheetDashboard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("spreadsheet_dashboard_pkey");

                        entity.ToTable("spreadsheet_dashboard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DashboardGroupId).HasColumnName("dashboard_group_id");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.SampleDashboardFilePath).HasColumnName("sample_dashboard_file_path");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.SpreadsheetDashboard) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("spreadsheet_dashboard_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("spreadsheet_dashboard_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SpreadsheetDashboardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("spreadsheet_dashboard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("spreadsheet_dashboard_create_uid_fkey");

                        entity.HasOne(d => d.DashboardGroup).WithMany(p => p.SpreadsheetDashboard)
                            .HasForeignKey(d => d.DashboardGroupId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("spreadsheet_dashboard_dashboard_group_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SpreadsheetDashboardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("spreadsheet_dashboard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("spreadsheet_dashboard_write_uid_fkey");

                        // entity.HasMany(d => d.IrModel).WithMany(p => p.SpreadsheetDashboard)
                        entity.HasMany(d => d.IrModel).WithMany(p => p.SpreadsheetDashboard)
                            .UsingEntity<Dictionary<string, object>>(
                                "IrModelSpreadsheetDashboardRel",
                                r => r.HasOne<IrModel>().WithMany()
                                    .HasForeignKey("IrModelId")
                                    .HasConstraintName("ir_model_spreadsheet_dashboard_rel_ir_model_id_fkey"),
                                l => l.HasOne<SpreadsheetDashboard>().WithMany()
                                    .HasForeignKey("SpreadsheetDashboardId")
                                    .HasConstraintName("ir_model_spreadsheet_dashboard_re_spreadsheet_dashboard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SpreadsheetDashboardId", "IrModelId").HasName("ir_model_spreadsheet_dashboard_rel_pkey");
                                    j.ToTable("ir_model_spreadsheet_dashboard_rel");
                                    j.HasIndex(new[] { "IrModelId", "SpreadsheetDashboardId" }, "ir_model_spreadsheet_dashboar_ir_model_id_spreadsheet_dashb_idx");
                                    j.IndexerProperty<Guid>("SpreadsheetDashboardId").HasColumnName("spreadsheet_dashboard_id");
                                    j.IndexerProperty<Guid>("IrModelId").HasColumnName("ir_model_id");
                                });

                        // entity.HasMany(d => d.ResGroups).WithMany(p => p.SpreadsheetDashboard)
                        entity.HasMany(d => d.ResGroups).WithMany(p => p.SpreadsheetDashboard)
                            .UsingEntity<Dictionary<string, object>>(
                                "ResGroupsSpreadsheetDashboardRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("ResGroupsId")
                                    .HasConstraintName("res_groups_spreadsheet_dashboard_rel_res_groups_id_fkey"),
                                l => l.HasOne<SpreadsheetDashboard>().WithMany()
                                    .HasForeignKey("SpreadsheetDashboardId")
                                    .HasConstraintName("res_groups_spreadsheet_dashboard__spreadsheet_dashboard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SpreadsheetDashboardId", "ResGroupsId").HasName("res_groups_spreadsheet_dashboard_rel_pkey");
                                    j.ToTable("res_groups_spreadsheet_dashboard_rel");
                                    j.HasIndex(new[] { "ResGroupsId", "SpreadsheetDashboardId" }, "res_groups_spreadsheet_dashbo_res_groups_id_spreadsheet_das_idx");
                                    j.IndexerProperty<Guid>("SpreadsheetDashboardId").HasColumnName("spreadsheet_dashboard_id");
                                    j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}