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
        public static void ConfigureLunchOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LunchOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("lunch_order_pkey");

                entity.ToTable("lunch_order");

                entity.HasIndex(e => e.State, "lunch_order_state_index");

                entity.HasIndex(e => e.SupplierId, "lunch_order_supplier_id_index");

                entity.HasIndex(e => new { e.UserId, e.ProductId, e.Date }, "lunch_order_user_product_date");

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
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.DisplayToppings).HasColumnName("display_toppings");
                entity.Property(e => e.LunchLocationId).HasColumnName("lunch_location_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.Notified).HasColumnName("notified");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Category).WithMany(p => p.LunchOrders)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_order_category_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_order_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_order_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_order_currency_id_fkey");

                entity.HasOne(d => d.LunchLocation).WithMany(p => p.LunchOrders)
                    .HasForeignKey(d => d.LunchLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_order_lunch_location_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.LunchOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("lunch_order_product_id_fkey");

                entity.HasOne(d => d.Supplier).WithMany(p => p.LunchOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_order_supplier_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_order_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_order_write_uid_fkey");

                //entity.HasMany(d => d.Toppings).WithMany(p => p.Orders)
                entity.HasMany<LunchTopping>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "LunchOrderTopping",
                        r => r.HasOne<LunchTopping>().WithMany()
                            .HasForeignKey("ToppingId")
                            .HasConstraintName("lunch_order_topping_topping_id_fkey"),
                        l => l.HasOne<LunchOrder>().WithMany()
                            .HasForeignKey("OrderId")
                            .HasConstraintName("lunch_order_topping_order_id_fkey"),
                        j =>
                        {
                            j.HasKey("OrderId", "ToppingId").HasName("lunch_order_topping_pkey");
                            j.ToTable("lunch_order_topping");
                            j.HasIndex(new[] { "ToppingId", "OrderId" }, "lunch_order_topping_topping_id_order_id_idx");
                        });
            });
        }
    }
}