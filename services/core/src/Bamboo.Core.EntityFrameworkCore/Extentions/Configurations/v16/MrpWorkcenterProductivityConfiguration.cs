using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpWorkcenterProductivity(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpWorkcenterProductivity>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_workcenter_productivity_pkey");

                        entity.ToTable("mrp_workcenter_productivity");

                        entity.HasIndex(e => e.TenantId, "mrp_workcenter_productivity__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.WorkcenterId, "mrp_workcenter_productivity__workcenter_id_index");

                        entity.HasIndex(e => e.WorkorderId, "mrp_workcenter_productivity__workorder_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountMoveLineId).HasColumnName("account_move_line_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateEnd)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_end");
                        entity.Property(e => e.DateStart)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_start");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Duration).HasColumnName("duration");
                        entity.Property(e => e.LossId).HasColumnName("loss_id");
                        entity.Property(e => e.LossType).HasColumnName("loss_type");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.WorkcenterId).HasColumnName("workcenter_id");
                        entity.Property(e => e.WorkorderId).HasColumnName("workorder_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AccountMoveLine).WithMany(p => p.MrpWorkcenterProductivity)
                            .HasForeignKey(d => d.AccountMoveLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_productivity_account_move_line_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.MrpWorkcenterProductivity) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_workcenter_productivity_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_workcenter_productivity_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpWorkcenterProductivityCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_productivity_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_productivity_create_uid_fkey");

                        entity.HasOne(d => d.Loss).WithMany(p => p.MrpWorkcenterProductivity)
                            .HasForeignKey(d => d.LossId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_workcenter_productivity_loss_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.MrpWorkcenterProductivityUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_productivity_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_productivity_user_id_fkey");

                        entity.HasOne(d => d.Workcenter).WithMany(p => p.MrpWorkcenterProductivity)
                            .HasForeignKey(d => d.WorkcenterId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_workcenter_productivity_workcenter_id_fkey");

                        entity.HasOne(d => d.Workorder).WithMany(p => p.MrpWorkcenterProductivity)
                            .HasForeignKey(d => d.WorkorderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_productivity_workorder_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpWorkcenterProductivityWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_productivity_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_productivity_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}