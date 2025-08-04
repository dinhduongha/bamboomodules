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
        public static void ConfigureProjectShareCollaboratorWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectShareCollaboratorWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("project_share_collaborator_wizard_pkey");

                entity.ToTable("project_share_collaborator_wizard");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessMode).HasColumnName("access_mode");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ParentWizardId).HasColumnName("parent_wizard_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.SendInvitation).HasColumnName("send_invitation");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_share_collaborator_wizard_create_uid_fkey");

                entity.HasOne(d => d.ParentWizard).WithMany()
                    .HasForeignKey(d => d.ParentWizardId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_share_collaborator_wizard_parent_wizard_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("project_share_collaborator_wizard_partner_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_share_collaborator_wizard_write_uid_fkey");
            });
        }
    }
}