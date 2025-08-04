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
        public static void ConfigureMailActivityPlan(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailActivityPlan>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_activity_plan_pkey");

                entity.ToTable("mail_activity_plan");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.ResModelId).HasColumnName("res_model_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_plan_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_plan_create_uid_fkey");

                entity.HasOne(d => d.Department).WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_activity_plan_department_id_fkey");

                entity.HasOne(d => d.ResModelNavigation).WithMany(p => p.MailActivityPlans)
                    .HasForeignKey(d => d.ResModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_activity_plan_res_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_plan_write_uid_fkey");
            });
        }
    }
}