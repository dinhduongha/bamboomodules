using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectUpdate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectUpdate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_update_pkey");

                        entity.ToTable("project_update");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AllocatedTime).HasColumnName("allocated_time");
                        entity.Property(e => e.ClosedTaskCount).HasColumnName("closed_task_count");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.EmailCc).HasColumnName("email_cc");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Progress).HasColumnName("progress");
                        entity.Property(e => e.ProjectId).HasColumnName("project_id");
                        entity.Property(e => e.Status).HasColumnName("status");
                        entity.Property(e => e.TaskCount).HasColumnName("task_count");
                        entity.Property(e => e.TimesheetTime).HasColumnName("timesheet_time");
                        entity.Property(e => e.UomId).HasColumnName("uom_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectUpdateCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_update_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_update_create_uid_fkey");

                        entity.HasOne(d => d.Project).WithMany(p => p.ProjectUpdate)
                            .HasForeignKey(d => d.ProjectId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_update_project_id_fkey");

                        // entity.HasOne(d => d.Uom).WithMany(p => p.ProjectUpdate) .HasForeignKey(d => d.UomId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_update_uom_id_fkey");
                        entity.HasOne(d => d.Uom).WithMany()
                            .HasForeignKey(d => d.UomId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_update_uom_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.ProjectUpdateUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("project_update_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_update_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectUpdateWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_update_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_update_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}