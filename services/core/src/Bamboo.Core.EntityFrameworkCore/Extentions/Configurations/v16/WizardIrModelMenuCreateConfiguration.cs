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
        public static void ConfigureWizardIrModelMenuCreate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WizardIrModelMenuCreate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("wizard_ir_model_menu_create_pkey");

            entity.ToTable("wizard_ir_model_menu_create");

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
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.WizardIrModelMenuCreateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("wizard_ir_model_menu_create_create_uid_fkey");

            entity.HasOne(d => d.Menu).WithMany(p => p.WizardIrModelMenuCreate)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("wizard_ir_model_menu_create_menu_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.WizardIrModelMenuCreateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("wizard_ir_model_menu_create_write_uid_fkey");
            });
        }
    }
}