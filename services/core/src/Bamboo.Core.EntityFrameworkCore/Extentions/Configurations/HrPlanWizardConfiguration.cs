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
        public static void ConfigureHrPlanWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrPlanWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_plan_wizard_pkey");

                entity.ToTable("hr_plan_wizard");

                entity.HasIndex(e => e.TenantId, "hr_plan_wizard_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.PlanId).HasColumnName("plan_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_plan_wizard_create_uid_fkey");

                entity.HasOne(d => d.Plan).WithMany(p => p.HrPlanWizards)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_plan_wizard_plan_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_plan_wizard_write_uid_fkey");

                //entity.HasMany(d => d.PlanWizards).WithMany(p => p.Employees)
                entity.HasMany<HrEmployee>().WithMany()
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
                        });
            });
        }
    }
}