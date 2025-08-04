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
        public static void ConfigureHrResumeLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrResumeLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_resume_line_pkey");

                entity.ToTable("hr_resume_line");

                entity.HasIndex(e => e.TenantId, "hr_resume_line_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateEnd).HasColumnName("date_end");
                entity.Property(e => e.DateStart).HasColumnName("date_start");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.DisplayType).HasColumnName("display_type");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.LineTypeId).HasColumnName("line_type_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_resume_line_create_uid_fkey");

                entity.HasOne(d => d.Employee).WithMany(p => p.HrResumeLines)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("hr_resume_line_employee_id_fkey");

                entity.HasOne(d => d.LineType).WithMany(p => p.HrResumeLines)
                    .HasForeignKey(d => d.LineTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_resume_line_line_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_resume_line_write_uid_fkey");
            });
        }
    }
}