using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpWorkcenterProductivityLoss(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpWorkcenterProductivityLoss>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_workcenter_productivity_loss_pkey");

                        entity.ToTable("mrp_workcenter_productivity_loss");

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
                        entity.Property(e => e.LossId).HasColumnName("loss_id");
                        entity.Property(e => e.LossType).HasColumnName("loss_type");
                        entity.Property(e => e.Manual).HasColumnName("manual");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpWorkcenterProductivityLossCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_productivity_loss_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_productivity_loss_create_uid_fkey");

                        entity.HasOne(d => d.Loss).WithMany(p => p.MrpWorkcenterProductivityLoss)
                            .HasForeignKey(d => d.LossId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_productivity_loss_loss_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpWorkcenterProductivityLossWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_productivity_loss_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_productivity_loss_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}