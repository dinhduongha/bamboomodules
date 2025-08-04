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
        public static void ConfigureMrpProductionSplitLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpProductionSplitLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_production_split_line_pkey");

                entity.ToTable("mrp_production_split_line");

                entity.HasIndex(e => e.TenantId, "mrp_production_split_line_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");
                entity.Property(e => e.MrpProductionSplitId).HasColumnName("mrp_production_split_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_split_line_create_uid_fkey");

                entity.HasOne(d => d.MrpProductionSplit).WithMany(p => p.MrpProductionSplitLines)
                    .HasForeignKey(d => d.MrpProductionSplitId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mrp_production_split_line_mrp_production_split_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_split_line_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_split_line_write_uid_fkey");
            });
        }
    }
}