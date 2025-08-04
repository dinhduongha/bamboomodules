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
        public static void ConfigureProductSupplierinfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSupplierinfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_supplierinfo_pkey");

                entity.ToTable("product_supplierinfo");

                entity.HasIndex(e => e.TenantId, "product_supplierinfo_company_id_index");

                entity.HasIndex(e => e.ProductTmplId, "product_supplierinfo_product_tmpl_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.DateEnd).HasColumnName("date_end");
                entity.Property(e => e.DateStart).HasColumnName("date_start");
                entity.Property(e => e.Delay).HasColumnName("delay");
                entity.Property(e => e.MinQty).HasColumnName("min_qty");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.ProductCode).HasColumnName("product_code");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductName).HasColumnName("product_name");
                entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_supplierinfo_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_supplierinfo_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("product_supplierinfo_currency_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_supplierinfo_partner_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductSupplierinfos)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_supplierinfo_product_id_fkey");

                entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductSupplierinfos)
                    .HasForeignKey(d => d.ProductTmplId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_supplierinfo_product_tmpl_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_supplierinfo_write_uid_fkey");
            });
        }
    }
}