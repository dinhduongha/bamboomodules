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
        public static void ConfigureAccountGroupTemplate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountGroupTemplate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_group_template_pkey");

            entity.ToTable("account_group_template");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.ChartTemplateId).HasColumnName("chart_template_id");
            entity.Property(e => e.CodePrefixEnd).HasColumnName("code_prefix_end");
            entity.Property(e => e.CodePrefixStart).HasColumnName("code_prefix_start");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.ChartTemplate).WithMany(p => p.AccountGroupTemplate)
                .HasForeignKey(d => d.ChartTemplateId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_group_template_chart_template_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountGroupTemplateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_group_template_create_uid_fkey");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("account_group_template_parent_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountGroupTemplateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_group_template_write_uid_fkey");
            });
        }
    }
}