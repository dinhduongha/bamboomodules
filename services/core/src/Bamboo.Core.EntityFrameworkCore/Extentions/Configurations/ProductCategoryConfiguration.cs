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
        public static void ConfigureProductCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_category_pkey");

                entity.ToTable("product_category");

                entity.HasIndex(e => e.TenantId, "product_category_company_id_index");

                entity.HasIndex(e => e.Name, "product_category_name_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.ParentId, "product_category_parent_id_index");

                entity.HasIndex(e => e.ParentPath, "product_category_parent_path_index");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PackagingReserveMethod).HasColumnName("packaging_reserve_method");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                entity.Property(e => e.RemovalStrategyId).HasColumnName("removal_strategy_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_category_create_uid_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_category_parent_id_fkey");

                entity.HasOne(d => d.RemovalStrategy).WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.RemovalStrategyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_category_removal_strategy_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_category_write_uid_fkey");
            });
        }
    }
}