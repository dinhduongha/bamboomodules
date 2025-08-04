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
        public static void ConfigureProjectMilestone(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectMilestone>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("project_milestone_pkey");

                entity.ToTable("project_milestone");

                entity.HasIndex(e => e.TenantId, "project_milestone_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Deadline).HasColumnName("deadline");
                entity.Property(e => e.IsReached).HasColumnName("is_reached");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ProjectId).HasColumnName("project_id");
                entity.Property(e => e.QuantityPercentage).HasColumnName("quantity_percentage");
                entity.Property(e => e.ReachedDate).HasColumnName("reached_date");
                entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_milestone_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProjectMilestones)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_milestone_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Project).WithMany(p => p.ProjectMilestones)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("project_milestone_project_id_fkey");

                entity.HasOne(d => d.SaleLine).WithMany(p => p.ProjectMilestones)
                    .HasForeignKey(d => d.SaleLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_milestone_sale_line_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_milestone_write_uid_fkey");
            });
        }
    }
}