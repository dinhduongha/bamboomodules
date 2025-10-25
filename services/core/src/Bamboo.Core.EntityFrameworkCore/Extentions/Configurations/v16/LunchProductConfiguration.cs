using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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

                        entity.HasOne(d => d.Category).WithMany(p => p.LunchProduct)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("lunch_product_category_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.LunchProduct) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lunch_product_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lunch_product_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LunchProductCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lunch_product_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lunch_product_create_uid_fkey");

                        entity.HasOne(d => d.Supplier).WithMany(p => p.LunchProduct)
                            .HasForeignKey(d => d.SupplierId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("lunch_product_supplier_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LunchProductWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lunch_product_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lunch_product_write_uid_fkey");

                        // entity.HasMany(d => d.User).WithMany(p => p.Product)
                        entity.HasMany(d => d.User).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "LunchProductFavoriteUserRel",
                                r => r.HasOne<ResUsers>().WithMany()
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
                                    j.IndexerProperty<Guid>("ProductId").HasColumnName("product_id");
                                    j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}