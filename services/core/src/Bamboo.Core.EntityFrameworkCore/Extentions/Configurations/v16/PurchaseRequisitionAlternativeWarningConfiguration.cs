using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePurchaseRequisitionAlternativeWarning(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PurchaseRequisitionAlternativeWarning>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("purchase_requisition_alternative_warning_pkey");

                        entity.ToTable("purchase_requisition_alternative_warning");

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
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PurchaseRequisitionAlternativeWarningCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_alternative_warning_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_alternative_warning_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PurchaseRequisitionAlternativeWarningWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_alternative_warning_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_alternative_warning_write_uid_fkey");

                        // entity.HasMany(d => d.PurchaseOrder).WithMany(p => p.PurchaseRequisitionAlternativeWarning)
                        entity.HasMany(d => d.PurchaseOrder).WithMany(p => p.PurchaseRequisitionAlternativeWarning)
                            .UsingEntity<Dictionary<string, object>>(
                                "WarningPurchaseOrderAlternativeRel",
                                r => r.HasOne<PurchaseOrder>().WithMany()
                                    .HasForeignKey("PurchaseOrderId")
                                    .HasConstraintName("warning_purchase_order_alternative_rel_purchase_order_id_fkey"),
                                l => l.HasOne<PurchaseRequisitionAlternativeWarning>().WithMany()
                                    .HasForeignKey("PurchaseRequisitionAlternativeWarningId")
                                    .HasConstraintName("warning_purchase_order_altern_purchase_requisition_alterna_fkey"),
                                j =>
                                {
                                    j.HasKey("PurchaseRequisitionAlternativeWarningId", "PurchaseOrderId").HasName("warning_purchase_order_alternative_rel_pkey");
                                    j.ToTable("warning_purchase_order_alternative_rel");
                                    j.HasIndex(new[] { "PurchaseOrderId", "PurchaseRequisitionAlternativeWarningId" }, "warning_purchase_order_altern_purchase_order_id_purchase_re_idx");
                                    j.IndexerProperty<Guid>("PurchaseRequisitionAlternativeWarningId").HasColumnName("purchase_requisition_alternative_warning_id");
                                    j.IndexerProperty<Guid>("PurchaseOrderId").HasColumnName("purchase_order_id");
                                });

                        // entity.HasMany(d => d.PurchaseOrderNavigation).WithMany(p => p.PurchaseRequisitionAlternativeWarningNavigation)
                        entity.HasMany(d => d.PurchaseOrderNavigation).WithMany(p => p.PurchaseRequisitionAlternativeWarningNavigation)
                            .UsingEntity<Dictionary<string, object>>(
                                "WarningPurchaseOrderRel",
                                r => r.HasOne<PurchaseOrder>().WithMany()
                                    .HasForeignKey("PurchaseOrderId")
                                    .HasConstraintName("warning_purchase_order_rel_purchase_order_id_fkey"),
                                l => l.HasOne<PurchaseRequisitionAlternativeWarning>().WithMany()
                                    .HasForeignKey("PurchaseRequisitionAlternativeWarningId")
                                    .HasConstraintName("warning_purchase_order_rel_purchase_requisition_alternativ_fkey"),
                                j =>
                                {
                                    j.HasKey("PurchaseRequisitionAlternativeWarningId", "PurchaseOrderId").HasName("warning_purchase_order_rel_pkey");
                                    j.ToTable("warning_purchase_order_rel");
                                    j.HasIndex(new[] { "PurchaseOrderId", "PurchaseRequisitionAlternativeWarningId" }, "warning_purchase_order_rel_purchase_order_id_purchase_requi_idx");
                                    j.IndexerProperty<Guid>("PurchaseRequisitionAlternativeWarningId").HasColumnName("purchase_requisition_alternative_warning_id");
                                    j.IndexerProperty<Guid>("PurchaseOrderId").HasColumnName("purchase_order_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}