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
        public static void ConfigureCrmTeamMember(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmTeamMember>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_team_member_pkey");

            entity.ToTable("crm_team_member");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.CrmTeamId, "crm_team_member_crm_team_id_index");

            entity.HasIndex(e => e.UserId, "crm_team_member_user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AssignmentDomain).HasColumnName("assignment_domain");
            entity.Property(e => e.AssignmentMax).HasColumnName("assignment_max");
            entity.Property(e => e.AssignmentOptout).HasColumnName("assignment_optout");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CrmTeamId).HasColumnName("crm_team_id");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmTeamMemberCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("crm_team_member_create_uid_fkey");

            entity.HasOne(d => d.CrmTeam).WithMany(p => p.CrmTeamMember)
                .HasForeignKey(d => d.CrmTeamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("crm_team_member_crm_team_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrmTeamMember)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("crm_team_member_message_main_attachment_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.CrmTeamMemberUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("crm_team_member_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmTeamMemberWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("crm_team_member_write_uid_fkey");
            });
        }
    }
}