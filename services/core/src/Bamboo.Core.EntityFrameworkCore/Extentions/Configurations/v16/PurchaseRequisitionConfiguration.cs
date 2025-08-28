using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePurchaseRequisition(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PurchaseRequisition>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("purchase_requisition_pkey");

                        entity.ToTable("purchase_requisition");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.DateEnd).HasColumnName("date_end");
                        entity.Property(e => e.DateStart).HasColumnName("date_start");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                        entity.Property(e => e.Reference).HasColumnName("reference");
                        entity.Property(e => e.RequisitionType).HasColumnName("requisition_type");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.VendorId).HasColumnName("vendor_id");
                        entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PurchaseRequisition) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("purchase_requisition_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("purchase_requisition_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PurchaseRequisitionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.PurchaseRequisition) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("purchase_requisition_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("purchase_requisition_currency_id_fkey");

                        entity.HasOne(d => d.PickingType).WithMany(p => p.PurchaseRequisition)
                            .HasForeignKey(d => d.PickingTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("purchase_requisition_picking_type_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.PurchaseRequisitionUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_user_id_fkey");

                        // entity.HasOne(d => d.Vendor).WithMany(p => p.PurchaseRequisition) .HasForeignKey(d => d.VendorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_vendor_id_fkey");
                        entity.HasOne(d => d.Vendor).WithMany()
                            .HasForeignKey(d => d.VendorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_vendor_id_fkey");

                        entity.HasOne(d => d.Warehouse).WithMany(p => p.PurchaseRequisition)
                            .HasForeignKey(d => d.WarehouseId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_warehouse_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PurchaseRequisitionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_requisition_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}