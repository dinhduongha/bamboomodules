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
        public static void ConfigureMrpProductionSplit(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpProductionSplit>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_production_split_pkey");

                entity.ToTable("mrp_production_split");

                entity.HasIndex(e => e.TenantId, "mrp_production_split_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Counter).HasColumnName("counter");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ProductionId).HasColumnName("production_id");
                entity.Property(e => e.ProductionSplitMultiId).HasColumnName("production_split_multi_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_split_create_uid_fkey");

                entity.HasOne(d => d.Production).WithMany(p => p.MrpProductionSplits)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_split_production_id_fkey");

                entity.HasOne(d => d.ProductionSplitMulti).WithMany(p => p.MrpProductionSplits)
                    .HasForeignKey(d => d.ProductionSplitMultiId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_split_production_split_multi_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_split_write_uid_fkey");
            });
        }
    }
}