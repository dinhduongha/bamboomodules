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
        public static void ConfigureProjectUpdate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUpdate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("project_update_pkey");

                entity.ToTable("project_update");

                entity.HasIndex(e => e.TenantId, "project_update_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.EmailCc).HasColumnName("email_cc");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Progress).HasColumnName("progress");
                entity.Property(e => e.ProjectId).HasColumnName("project_id");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_update_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProjectUpdates)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_update_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Project).WithMany(p => p.ProjectUpdates)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("project_update_project_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("project_update_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_update_write_uid_fkey");
            });
        }
    }
}