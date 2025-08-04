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
        public static void ConfigureHrPlanActivityType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrPlanActivityType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_plan_activity_type_pkey");

                entity.ToTable("hr_plan_activity_type");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.PlanId).HasColumnName("plan_id");
                entity.Property(e => e.Responsible).HasColumnName("responsible");
                entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");
                entity.Property(e => e.Summary).HasColumnName("summary");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.ActivityType).WithMany(p => p.HrPlanActivityTypes)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_plan_activity_type_activity_type_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_plan_activity_type_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_plan_activity_type_create_uid_fkey");

                entity.HasOne(d => d.Plan).WithMany(p => p.HrPlanActivityTypes)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_plan_activity_type_plan_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.ResponsibleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_plan_activity_type_responsible_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_plan_activity_type_write_uid_fkey");
            });
        }
    }
}