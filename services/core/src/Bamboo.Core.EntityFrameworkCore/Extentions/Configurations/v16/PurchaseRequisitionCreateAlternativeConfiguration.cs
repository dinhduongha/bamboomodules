using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePurchaseRequisitionCreateAlternative(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PurchaseRequisitionCreateAlternative>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("purchase_requisition_create_alternative_pkey");

                        entity.ToTable("purchase_requisition_create_alternative");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CopyProducts).HasColumnName("copy_products");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.OriginPoId).HasColumnName("origin_po_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PurchaseRequisitionCreateAlternativeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_create_alternative_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_create_alternative_create_uid_fkey");

                        entity.HasOne(d => d.OriginPo).WithMany(p => p.PurchaseRequisitionCreateAlternative)
                            .HasForeignKey(d => d.OriginPoId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_create_alternative_origin_po_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.PurchaseRequisitionCreateAlternative) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("purchase_requisition_create_alternative_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("purchase_requisition_create_alternative_partner_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PurchaseRequisitionCreateAlternativeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_create_alternative_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_create_alternative_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}