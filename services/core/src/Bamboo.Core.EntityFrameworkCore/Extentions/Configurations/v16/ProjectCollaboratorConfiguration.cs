using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectCollaborator(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectCollaborator>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_collaborator_pkey");

            entity.ToTable("project_collaborator");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.ProjectId, e.PartnerId }, "project_collaborator_unique_collaborator").IsUnique();

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
            entity.Property(e => e.LimitedAccess).HasColumnName("limited_access");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectCollaboratorCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("project_collaborator_create_uid_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.ProjectCollaborator)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("project_collaborator_partner_id_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectCollaborator)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("project_collaborator_project_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectCollaboratorWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("project_collaborator_write_uid_fkey");
            });
        }
    }
}
