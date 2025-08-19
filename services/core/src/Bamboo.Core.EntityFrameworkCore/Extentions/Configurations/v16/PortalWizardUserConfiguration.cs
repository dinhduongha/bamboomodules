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
        public static void ConfigurePortalWizardUser(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PortalWizardUser>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("portal_wizard_user_pkey");

            entity.ToTable("portal_wizard_user");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

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
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.WizardId).HasColumnName("wizard_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.PortalWizardUserCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("portal_wizard_user_create_uid_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.PortalWizardUser)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("portal_wizard_user_partner_id_fkey");

            entity.HasOne(d => d.Wizard).WithMany(p => p.PortalWizardUser)
                .HasForeignKey(d => d.WizardId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("portal_wizard_user_wizard_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.PortalWizardUserWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("portal_wizard_user_write_uid_fkey");
            });
        }
    }
}