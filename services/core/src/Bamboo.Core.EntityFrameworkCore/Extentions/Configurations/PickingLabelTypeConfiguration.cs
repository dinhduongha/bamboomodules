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
        public static void ConfigurePickingLabelType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PickingLabelType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("picking_label_type_pkey");

                entity.ToTable("picking_label_type");

                entity.HasIndex(e => e.TenantId, "picking_label_type_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LabelType).HasColumnName("label_type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("picking_label_type_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("picking_label_type_write_uid_fkey");

                //entity.HasMany(d => d.MrpProductions).WithMany(p => p.PickingLabelTypes)
                entity.HasMany<MrpProduction>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MrpProductionPickingLabelTypeRel",
                        r => r.HasOne<MrpProduction>().WithMany()
                            .HasForeignKey("MrpProductionId")
                            .HasConstraintName("mrp_production_picking_label_type_rel_mrp_production_id_fkey"),
                        l => l.HasOne<PickingLabelType>().WithMany()
                            .HasForeignKey("PickingLabelTypeId")
                            .HasConstraintName("mrp_production_picking_label_type_re_picking_label_type_id_fkey"),
                        j =>
                        {
                            j.HasKey("PickingLabelTypeId", "MrpProductionId").HasName("mrp_production_picking_label_type_rel_pkey");
                            j.ToTable("mrp_production_picking_label_type_rel");
                            j.HasIndex(new[] { "MrpProductionId", "PickingLabelTypeId" }, "mrp_production_picking_label__mrp_production_id_picking_lab_idx");
                            j.IndexerProperty<Guid>("PickingLabelTypeId").HasColumnName("picking_label_type_id");
                            j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                        });

                //entity.HasMany(d => d.StockPickings).WithMany(p => p.PickingLabelTypes)
                entity.HasMany<StockPicking>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PickingLabelTypeStockPickingRel",
                        r => r.HasOne<StockPicking>().WithMany()
                            .HasForeignKey("StockPickingId")
                            .HasConstraintName("picking_label_type_stock_picking_rel_stock_picking_id_fkey"),
                        l => l.HasOne<PickingLabelType>().WithMany()
                            .HasForeignKey("PickingLabelTypeId")
                            .HasConstraintName("picking_label_type_stock_picking_rel_picking_label_type_id_fkey"),
                        j =>
                        {
                            j.HasKey("PickingLabelTypeId", "StockPickingId").HasName("picking_label_type_stock_picking_rel_pkey");
                            j.ToTable("picking_label_type_stock_picking_rel");
                            j.HasIndex(new[] { "StockPickingId", "PickingLabelTypeId" }, "picking_label_type_stock_pick_stock_picking_id_picking_labe_idx");
                        });
            });
        }
    }
}