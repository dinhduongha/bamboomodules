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
        public static void ConfigureLunchProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LunchProduct>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("lunch_product_pkey");

                entity.ToTable("lunch_product");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.NewUntil).HasColumnName("new_until");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Category).WithMany(p => p.LunchProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("lunch_product_category_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_product_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_product_create_uid_fkey");

                entity.HasOne(d => d.Supplier).WithMany(p => p.LunchProducts)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("lunch_product_supplier_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_product_write_uid_fkey");

                //entity.HasMany(d => d.Users).WithMany(p => p.Products)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "LunchProductFavoriteUserRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("lunch_product_favorite_user_rel_user_id_fkey"),
                        l => l.HasOne<LunchProduct>().WithMany()
                            .HasForeignKey("ProductId")
                            .HasConstraintName("lunch_product_favorite_user_rel_product_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProductId", "UserId").HasName("lunch_product_favorite_user_rel_pkey");
                            j.ToTable("lunch_product_favorite_user_rel");
                            j.HasIndex(new[] { "UserId", "ProductId" }, "lunch_product_favorite_user_rel_user_id_product_id_idx");
                        });
            });
        }
    }
}