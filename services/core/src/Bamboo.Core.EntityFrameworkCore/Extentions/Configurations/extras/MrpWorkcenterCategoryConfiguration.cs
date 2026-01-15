using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpWorkcenterCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpWorkcenterCategory>(entity =>
                {
                    entity.HasKey(e => e.Id).HasName("mrp_workcenter_category_pkey");

                    entity.ToTable("mrp_workcenter_category");

                    entity.HasIndex(e => e.TenantId);

                    entity.HasIndex(e => e.OrganizationUnitId);
                    entity.HasIndex(e => e.Name, "mrp_workcenter_category__name_index");
                    // TODO: GIN must be string type
                    // entity.HasIndex(e => e.Name, "mrp_workcenter_category__name_index")
                    // .HasMethod("gin")
                    // .HasOperators(new[] { "gin_trgm_ops" });

                    entity.HasIndex(e => e.ParentId, "mrp_workcenter_category__parent_id_index");

                    entity.HasIndex(e => e.ParentPath, "mrp_workcenter_category__parent_path_index");

                    entity.Property(e => e.Id)
                    .HasDefaultValueSql("uuidv7()")
                    .HasColumnName("id");

                    entity.Property(e => e.TenantId).HasColumnName("company_id");

                    entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                    //entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                    entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                    entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                    entity.Property(e => e.Name).HasColumnName("name");
                    //entity.Property(e => e.PackagingReserveMethod).HasColumnName("packaging_reserve_method");
                    entity.Property(e => e.ParentId).HasColumnName("parent_id");
                    entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                    entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                    entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                    // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductCategoryCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_category_create_uid_fkey");
                    entity.HasOne(d => d.CreateU).WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workcenter_category_create_uid_fkey");

                    entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mrp_workcenter_category_parent_id_fkey");

                    // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductCategoryWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_category_write_uid_fkey");
                    entity.HasOne(d => d.WriteU).WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workcenter_category_write_uid_fkey");

                    entity.TryConfigureExtraProperties();
                    entity.TryConfigureObjectExtensions();
                    entity.TryConfigureConcurrencyStamp();
                });
        }
    }
}