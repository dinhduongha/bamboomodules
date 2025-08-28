using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSaleOrderTemplateOption(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SaleOrderTemplateOption>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sale_order_template_option_pkey");

                        entity.ToTable("sale_order_template_option");

                        entity.HasIndex(e => e.TenantId, "sale_order_template_option__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.SaleOrderTemplateId, "sale_order_template_option__sale_order_template_id_index");

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
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.Quantity).HasColumnName("quantity");
                        entity.Property(e => e.SaleOrderTemplateId).HasColumnName("sale_order_template_id");
                        entity.Property(e => e.UomId).HasColumnName("uom_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.SaleOrderTemplateOption) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_order_template_option_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_order_template_option_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SaleOrderTemplateOptionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_order_template_option_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_order_template_option_create_uid_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.SaleOrderTemplateOption) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("sale_order_template_option_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("sale_order_template_option_product_id_fkey");

                        entity.HasOne(d => d.SaleOrderTemplate).WithMany(p => p.SaleOrderTemplateOption)
                            .HasForeignKey(d => d.SaleOrderTemplateId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("sale_order_template_option_sale_order_template_id_fkey");

                        // entity.HasOne(d => d.Uom).WithMany(p => p.SaleOrderTemplateOption) .HasForeignKey(d => d.UomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("sale_order_template_option_uom_id_fkey");
                        entity.HasOne(d => d.Uom).WithMany()
                            .HasForeignKey(d => d.UomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("sale_order_template_option_uom_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SaleOrderTemplateOptionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_order_template_option_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_order_template_option_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}