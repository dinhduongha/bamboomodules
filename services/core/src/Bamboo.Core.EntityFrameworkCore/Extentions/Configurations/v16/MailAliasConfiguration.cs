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
        public static void ConfigureMailAlias(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailAlias>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_alias_pkey");

            entity.ToTable("mail_alias");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.AliasFullName, "mail_alias__alias_full_name_index").HasFilter("(alias_full_name IS NOT NULL)");

            entity.HasIndex(e => e.AliasName, "mail_alias_alias_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AliasBouncedContent)
                .HasColumnType("jsonb")
                .HasColumnName("alias_bounced_content");
            entity.Property(e => e.AliasContact).HasColumnName("alias_contact");
            entity.Property(e => e.AliasDefaults).HasColumnName("alias_defaults");
            entity.Property(e => e.AliasDomainId).HasColumnName("alias_domain_id");
            entity.Property(e => e.AliasForceThreadId).HasColumnName("alias_force_thread_id");
            entity.Property(e => e.AliasFullName).HasColumnName("alias_full_name");
            entity.Property(e => e.AliasIncomingLocal).HasColumnName("alias_incoming_local");
            entity.Property(e => e.AliasModelId).HasColumnName("alias_model_id");
            entity.Property(e => e.AliasName).HasColumnName("alias_name");
            entity.Property(e => e.AliasParentModelId).HasColumnName("alias_parent_model_id");
            entity.Property(e => e.AliasParentThreadId).HasColumnName("alias_parent_thread_id");
            entity.Property(e => e.AliasStatus).HasColumnName("alias_status");
            entity.Property(e => e.AliasUserId).HasColumnName("alias_user_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.AliasDomain).WithMany(p => p.MailAlias)
                .HasForeignKey(d => d.AliasDomainId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("mail_alias_alias_domain_id_fkey");

            entity.HasOne(d => d.AliasModel).WithMany(p => p.MailAliasAliasModel)
                .HasForeignKey(d => d.AliasModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_alias_alias_model_id_fkey");

            entity.HasOne(d => d.AliasParentModel).WithMany(p => p.MailAliasAliasParentModel)
                .HasForeignKey(d => d.AliasParentModelId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_alias_alias_parent_model_id_fkey");

            entity.HasOne(d => d.AliasUser).WithMany()
                .HasForeignKey(d => d.AliasUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_alias_alias_user_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailAliasCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_alias_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailAliasWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_alias_write_uid_fkey");
            });
        }
    }
}
