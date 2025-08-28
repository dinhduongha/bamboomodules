using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpBatchProduce(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpBatchProduce>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_batch_produce_pkey");

                        entity.ToTable("mrp_batch_produce");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ComponentSeparator).HasColumnName("component_separator");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LotName).HasColumnName("lot_name");
                        entity.Property(e => e.LotQty).HasColumnName("lot_qty");
                        entity.Property(e => e.LotsQuantitySeparator).HasColumnName("lots_quantity_separator");
                        entity.Property(e => e.LotsSeparator).HasColumnName("lots_separator");
                        entity.Property(e => e.ProductionId).HasColumnName("production_id");
                        entity.Property(e => e.ProductionText).HasColumnName("production_text");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpBatchProduceCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_batch_produce_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_batch_produce_create_uid_fkey");

                        entity.HasOne(d => d.Production).WithMany(p => p.MrpBatchProduce)
                            .HasForeignKey(d => d.ProductionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_batch_produce_production_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpBatchProduceWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_batch_produce_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_batch_produce_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}