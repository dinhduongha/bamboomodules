using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChannelId, "hr_resume_line__channel_id_index").HasFilter("(channel_id IS NOT NULL)");

                        entity.HasIndex(e => e.EmployeeId, "hr_resume_line__employee_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateEnd).HasColumnName("date_end");
                        entity.Property(e => e.DateStart).HasColumnName("date_start");
                        entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.DisplayType).HasColumnName("display_type");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.ExpirationStatus).HasColumnName("expiration_status");
                        entity.Property(e => e.LineTypeId).HasColumnName("line_type_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.SurveyId).HasColumnName("survey_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Channel).WithMany(p => p.HrResumeLine)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_resume_line_channel_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrResumeLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_resume_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_resume_line_create_uid_fkey");

                        entity.HasOne(d => d.Department).WithMany(p => p.HrResumeLine)
                            .HasForeignKey(d => d.DepartmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_resume_line_department_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrResumeLine)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_resume_line_employee_id_fkey");

                        entity.HasOne(d => d.LineType).WithMany(p => p.HrResumeLine)
                            .HasForeignKey(d => d.LineTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_resume_line_line_type_id_fkey");

                        entity.HasOne(d => d.Survey).WithMany(p => p.HrResumeLine)
                            .HasForeignKey(d => d.SurveyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_resume_line_survey_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrResumeLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_resume_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_resume_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}