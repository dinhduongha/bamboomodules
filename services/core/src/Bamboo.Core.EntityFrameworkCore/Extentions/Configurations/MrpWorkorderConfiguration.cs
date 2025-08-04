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
        public static void ConfigureMrpWorkorder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpWorkorder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_workorder_pkey");

                entity.ToTable("mrp_workorder");

                entity.HasIndex(e => e.TenantId, "mrp_workorder_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CostsHour).HasColumnName("costs_hour");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateFinished)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_finished");
                entity.Property(e => e.DatePlannedFinished)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_planned_finished");
                entity.Property(e => e.DatePlannedStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_planned_start");
                entity.Property(e => e.DateStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_start");
                entity.Property(e => e.Duration).HasColumnName("duration");
                entity.Property(e => e.DurationExpected).HasColumnName("duration_expected");
                entity.Property(e => e.DurationPercent).HasColumnName("duration_percent");
                entity.Property(e => e.DurationUnit).HasColumnName("duration_unit");
                entity.Property(e => e.LeaveId).HasColumnName("leave_id");
                entity.Property(e => e.MoAnalyticAccountLineId).HasColumnName("mo_analytic_account_line_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OperationId).HasColumnName("operation_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                entity.Property(e => e.ProductionAvailability).HasColumnName("production_availability");
                entity.Property(e => e.ProductionDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("production_date");
                entity.Property(e => e.ProductionId).HasColumnName("production_id");
                entity.Property(e => e.QtyProduced).HasColumnName("qty_produced");
                entity.Property(e => e.QtyReportedFromPreviousWo).HasColumnName("qty_reported_from_previous_wo");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.WcAnalyticAccountLineId).HasColumnName("wc_analytic_account_line_id");
                entity.Property(e => e.WorkcenterId).HasColumnName("workcenter_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workorder_create_uid_fkey");

                entity.HasOne(d => d.Leave).WithMany(p => p.MrpWorkorders)
                    .HasForeignKey(d => d.LeaveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workorder_leave_id_fkey");

                entity.HasOne(d => d.MoAnalyticAccountLine).WithMany(p => p.MrpWorkorderMoAnalyticAccountLines)
                    .HasForeignKey(d => d.MoAnalyticAccountLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workorder_mo_analytic_account_line_id_fkey");

                entity.HasOne(d => d.Operation).WithMany(p => p.MrpWorkorders)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workorder_operation_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.MrpWorkorders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workorder_product_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpWorkorders)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_workorder_product_uom_id_fkey");

                entity.HasOne(d => d.Production).WithMany(p => p.MrpWorkorders)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_workorder_production_id_fkey");

                entity.HasOne(d => d.WcAnalyticAccountLine).WithMany(p => p.MrpWorkorderWcAnalyticAccountLines)
                    .HasForeignKey(d => d.WcAnalyticAccountLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workorder_wc_analytic_account_line_id_fkey");

                entity.HasOne(d => d.Workcenter).WithMany(p => p.MrpWorkorders)
                    .HasForeignKey(d => d.WorkcenterId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_workorder_workcenter_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workorder_write_uid_fkey");

                entity.HasMany(d => d.AccountAnalyticLines).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MrpWorkorderMoAnalyticRel",
                        r => r.HasOne<AccountAnalyticLine>().WithMany()
                            .HasForeignKey("AccountAnalyticLineId")
                            .HasConstraintName("mrp_workorder_mo_analytic_rel_account_analytic_line_id_fkey"),
                        l => l.HasOne<MrpWorkorder>().WithMany()
                            .HasForeignKey("MrpWorkorderId")
                            .HasConstraintName("mrp_workorder_mo_analytic_rel_mrp_workorder_id_fkey"),
                        j =>
                        {
                            j.HasKey("MrpWorkorderId", "AccountAnalyticLineId").HasName("mrp_workorder_mo_analytic_rel_pkey");
                            j.ToTable("mrp_workorder_mo_analytic_rel");
                            j.HasIndex(new[] { "AccountAnalyticLineId", "MrpWorkorderId" }, "mrp_workorder_mo_analytic_rel_account_analytic_line_id_mrp__idx");
                            j.IndexerProperty<Guid>("MrpWorkorderId").HasColumnName("mrp_workorder_id");
                            j.IndexerProperty<Guid>("AccountAnalyticLineId").HasColumnName("account_analytic_line_id");
                        });

                entity.HasMany(d => d.AccountAnalyticLinesNavigation).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MrpWorkorderWcAnalyticRel",
                        r => r.HasOne<AccountAnalyticLine>().WithMany()
                            .HasForeignKey("AccountAnalyticLineId")
                            .HasConstraintName("mrp_workorder_wc_analytic_rel_account_analytic_line_id_fkey"),
                        l => l.HasOne<MrpWorkorder>().WithMany()
                            .HasForeignKey("MrpWorkorderId")
                            .HasConstraintName("mrp_workorder_wc_analytic_rel_mrp_workorder_id_fkey"),
                        j =>
                        {
                            j.HasKey("MrpWorkorderId", "AccountAnalyticLineId").HasName("mrp_workorder_wc_analytic_rel_pkey");
                            j.ToTable("mrp_workorder_wc_analytic_rel");
                            j.HasIndex(new[] { "AccountAnalyticLineId", "MrpWorkorderId" }, "mrp_workorder_wc_analytic_rel_account_analytic_line_id_mrp__idx");
                            j.IndexerProperty<Guid>("MrpWorkorderId").HasColumnName("mrp_workorder_id");
                            j.IndexerProperty<Guid>("AccountAnalyticLineId").HasColumnName("account_analytic_line_id");
                        });

                //entity.HasMany(d => d.BlockedBies).WithMany(p => p.Workorders)
                entity.HasMany<MrpWorkorder>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MrpWorkorderDependenciesRel",
                        r => r.HasOne<MrpWorkorder>().WithMany()
                            .HasForeignKey("BlockedById")
                            .HasConstraintName("mrp_workorder_dependencies_rel_blocked_by_id_fkey"),
                        l => l.HasOne<MrpWorkorder>().WithMany()
                            .HasForeignKey("WorkorderId")
                            .HasConstraintName("mrp_workorder_dependencies_rel_workorder_id_fkey"),
                        j =>
                        {
                            j.HasKey("WorkorderId", "BlockedById").HasName("mrp_workorder_dependencies_rel_pkey");
                            j.ToTable("mrp_workorder_dependencies_rel");
                            j.HasIndex(new[] { "BlockedById", "WorkorderId" }, "mrp_workorder_dependencies_rel_blocked_by_id_workorder_id_idx");
                        });

                //entity.HasMany(d => d.Workorders).WithMany(p => p.BlockedBies)
                entity.HasMany<MrpWorkorder>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MrpWorkorderDependenciesRel",
                        r => r.HasOne<MrpWorkorder>().WithMany()
                            .HasForeignKey("WorkorderId")
                            .HasConstraintName("mrp_workorder_dependencies_rel_workorder_id_fkey"),
                        l => l.HasOne<MrpWorkorder>().WithMany()
                            .HasForeignKey("BlockedById")
                            .HasConstraintName("mrp_workorder_dependencies_rel_blocked_by_id_fkey"),
                        j =>
                        {
                            j.HasKey("WorkorderId", "BlockedById").HasName("mrp_workorder_dependencies_rel_pkey");
                            j.ToTable("mrp_workorder_dependencies_rel");
                            j.HasIndex(new[] { "BlockedById", "WorkorderId" }, "mrp_workorder_dependencies_rel_blocked_by_id_workorder_id_idx");
                        });
            });
        }
    }
}