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
        public static void ConfigureHrHolidaysSummaryEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrHolidaysSummaryEmployee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_holidays_summary_employee_pkey");

                entity.ToTable("hr_holidays_summary_employee");

                entity.HasIndex(e => e.TenantId, "hr_holidays_summary_employee_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateFrom).HasColumnName("date_from");
                entity.Property(e => e.HolidayType).HasColumnName("holiday_type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_holidays_summary_employee_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_holidays_summary_employee_write_uid_fkey");

                //entity.HasMany(d => d.Emps).WithMany(p => p.Sums)
                entity.HasMany<HrEmployee>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "SummaryEmpRel",
                        r => r.HasOne<HrEmployee>().WithMany()
                            .HasForeignKey("EmpId")
                            .HasConstraintName("summary_emp_rel_emp_id_fkey"),
                        l => l.HasOne<HrHolidaysSummaryEmployee>().WithMany()
                            .HasForeignKey("SumId")
                            .HasConstraintName("summary_emp_rel_sum_id_fkey"),
                        j =>
                        {
                            j.HasKey("SumId", "EmpId").HasName("summary_emp_rel_pkey");
                            j.ToTable("summary_emp_rel");
                            j.HasIndex(new[] { "EmpId", "SumId" }, "summary_emp_rel_emp_id_sum_id_idx");
                        });
            });
        }
    }
}