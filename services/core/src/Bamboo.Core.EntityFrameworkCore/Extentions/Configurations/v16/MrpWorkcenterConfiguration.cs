using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpWorkcenter(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpWorkcenter>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_workcenter_pkey");

                        entity.ToTable("mrp_workcenter");

                        entity.HasIndex(e => e.TenantId, "mrp_workcenter__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ResourceCalendarId, "mrp_workcenter__resource_calendar_id_index");

                        entity.HasIndex(e => e.ResourceId, "mrp_workcenter__resource_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AnalyticDistribution)
                            .HasColumnType("jsonb")
                            .HasColumnName("analytic_distribution");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CostsHour).HasColumnName("costs_hour");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultCapacity).HasColumnName("default_capacity");
                        entity.Property(e => e.ExpenseAccountId).HasColumnName("expense_account_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.OeeTarget).HasColumnName("oee_target");
                        entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                        entity.Property(e => e.ResourceId).HasColumnName("resource_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TimeEfficiency).HasColumnName("time_efficiency");
                        entity.Property(e => e.TimeStart).HasColumnName("time_start");
                        entity.Property(e => e.TimeStop).HasColumnName("time_stop");
                        entity.Property(e => e.WorkingState).HasColumnName("working_state");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.MrpWorkcenter) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpWorkcenterCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_create_uid_fkey");

                        // entity.HasOne(d => d.ExpenseAccount).WithMany(p => p.MrpWorkcenter) .HasForeignKey(d => d.ExpenseAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_expense_account_id_fkey");
                        entity.HasOne(d => d.ExpenseAccount).WithMany()
                            .HasForeignKey(d => d.ExpenseAccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_expense_account_id_fkey");

                        entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.MrpWorkcenter)
                            .HasForeignKey(d => d.ResourceCalendarId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_resource_calendar_id_fkey");

                        entity.HasOne(d => d.Resource).WithMany(p => p.MrpWorkcenter)
                            .HasForeignKey(d => d.ResourceId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_workcenter_resource_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpWorkcenterWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_write_uid_fkey");

                        // entity.HasMany(d => d.AlternativeWorkcenter).WithMany(p => p.Workcenter)
                        entity.HasMany(d => d.AlternativeWorkcenter).WithMany(p => p.Workcenter)
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpWorkcenterAlternativeRel",
                                r => r.HasOne<MrpWorkcenter>().WithMany()
                                    .HasForeignKey("AlternativeWorkcenterId")
                                    .HasConstraintName("mrp_workcenter_alternative_rel_alternative_workcenter_id_fkey"),
                                l => l.HasOne<MrpWorkcenter>().WithMany()
                                    .HasForeignKey("WorkcenterId")
                                    .HasConstraintName("mrp_workcenter_alternative_rel_workcenter_id_fkey"),
                                j =>
                                {
                                    j.HasKey("WorkcenterId", "AlternativeWorkcenterId").HasName("mrp_workcenter_alternative_rel_pkey");
                                    j.ToTable("mrp_workcenter_alternative_rel");
                                    j.HasIndex(new[] { "AlternativeWorkcenterId", "WorkcenterId" }, "mrp_workcenter_alternative_re_alternative_workcenter_id_wor_idx");
                                    j.IndexerProperty<Guid>("WorkcenterId").HasColumnName("workcenter_id");
                                    j.IndexerProperty<Guid>("AlternativeWorkcenterId").HasColumnName("alternative_workcenter_id");
                                });

                        // entity.HasMany(d => d.MrpWorkcenterTag).WithMany(p => p.MrpWorkcenter)
                        entity.HasMany(d => d.MrpWorkcenterTag).WithMany(p => p.MrpWorkcenter)
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpWorkcenterMrpWorkcenterTagRel",
                                r => r.HasOne<MrpWorkcenterTag>().WithMany()
                                    .HasForeignKey("MrpWorkcenterTagId")
                                    .HasConstraintName("mrp_workcenter_mrp_workcenter_tag_re_mrp_workcenter_tag_id_fkey"),
                                l => l.HasOne<MrpWorkcenter>().WithMany()
                                    .HasForeignKey("MrpWorkcenterId")
                                    .HasConstraintName("mrp_workcenter_mrp_workcenter_tag_rel_mrp_workcenter_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MrpWorkcenterId", "MrpWorkcenterTagId").HasName("mrp_workcenter_mrp_workcenter_tag_rel_pkey");
                                    j.ToTable("mrp_workcenter_mrp_workcenter_tag_rel");
                                    j.HasIndex(new[] { "MrpWorkcenterTagId", "MrpWorkcenterId" }, "mrp_workcenter_mrp_workcenter_mrp_workcenter_tag_id_mrp_wor_idx");
                                    j.IndexerProperty<Guid>("MrpWorkcenterId").HasColumnName("mrp_workcenter_id");
                                    j.IndexerProperty<Guid>("MrpWorkcenterTagId").HasColumnName("mrp_workcenter_tag_id");
                                });

                        // entity.HasMany(d => d.Workcenter).WithMany(p => p.AlternativeWorkcenter)
                        entity.HasMany(d => d.Workcenter).WithMany(p => p.AlternativeWorkcenter)
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpWorkcenterAlternativeRel",
                                r => r.HasOne<MrpWorkcenter>().WithMany()
                                    .HasForeignKey("WorkcenterId")
                                    .HasConstraintName("mrp_workcenter_alternative_rel_workcenter_id_fkey"),
                                l => l.HasOne<MrpWorkcenter>().WithMany()
                                    .HasForeignKey("AlternativeWorkcenterId")
                                    .HasConstraintName("mrp_workcenter_alternative_rel_alternative_workcenter_id_fkey"),
                                j =>
                                {
                                    j.HasKey("WorkcenterId", "AlternativeWorkcenterId").HasName("mrp_workcenter_alternative_rel_pkey");
                                    j.ToTable("mrp_workcenter_alternative_rel");
                                    j.HasIndex(new[] { "AlternativeWorkcenterId", "WorkcenterId" }, "mrp_workcenter_alternative_re_alternative_workcenter_id_wor_idx");
                                    j.IndexerProperty<Guid>("WorkcenterId").HasColumnName("workcenter_id");
                                    j.IndexerProperty<Guid>("AlternativeWorkcenterId").HasColumnName("alternative_workcenter_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}