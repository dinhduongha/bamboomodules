using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrPlanWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrPlanWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_plan_wizard_pkey");

                        entity.ToTable("hr_plan_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.PlanId).HasColumnName("plan_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrPlanWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_plan_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_plan_wizard_create_uid_fkey");

                        entity.HasOne(d => d.Plan).WithMany(p => p.HrPlanWizard)
                            .HasForeignKey(d => d.PlanId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_plan_wizard_plan_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrPlanWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_plan_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_plan_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.PlanWizard).WithMany(p => p.Employee)
                        entity.HasMany(d => d.PlanWizard).WithMany(p => p.Employee)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrEmployeeHrPlanWizardRel",
                                r => r.HasOne<HrEmployee>().WithMany()
                                    .HasForeignKey("PlanWizardId")
                                    .HasConstraintName("hr_employee_hr_plan_wizard_rel_plan_wizard_id_fkey"),
                                l => l.HasOne<HrPlanWizard>().WithMany()
                                    .HasForeignKey("EmployeeId")
                                    .HasConstraintName("hr_employee_hr_plan_wizard_rel_employee_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EmployeeId", "PlanWizardId").HasName("hr_employee_hr_plan_wizard_rel_pkey");
                                    j.ToTable("hr_employee_hr_plan_wizard_rel");
                                    j.HasIndex(new[] { "PlanWizardId", "EmployeeId" }, "hr_employee_hr_plan_wizard_rel_plan_wizard_id_employee_id_idx");
                                    j.IndexerProperty<Guid>("EmployeeId").HasColumnName("employee_id");
                                    j.IndexerProperty<Guid>("PlanWizardId").HasColumnName("plan_wizard_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}