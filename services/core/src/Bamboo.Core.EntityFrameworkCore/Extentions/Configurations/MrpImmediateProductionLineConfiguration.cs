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
        public static void ConfigureMrpImmediateProductionLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpImmediateProductionLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_immediate_production_line_pkey");

                entity.ToTable("mrp_immediate_production_line");

                entity.HasIndex(e => e.TenantId, "mrp_immediate_production_line_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ImmediateProductionId).HasColumnName("immediate_production_id");
                entity.Property(e => e.ProductionId).HasColumnName("production_id");
                entity.Property(e => e.ToImmediate).HasColumnName("to_immediate");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_immediate_production_line_create_uid_fkey");

                entity.HasOne(d => d.ImmediateProduction).WithMany(p => p.MrpImmediateProductionLines)
                    .HasForeignKey(d => d.ImmediateProductionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_immediate_production_line_immediate_production_id_fkey");

                entity.HasOne(d => d.Production).WithMany(p => p.MrpImmediateProductionLines)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mrp_immediate_production_line_production_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_immediate_production_line_write_uid_fkey");
            });
        }
    }
}