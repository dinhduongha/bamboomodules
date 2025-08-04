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
        public static void ConfigureStockPickingType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockPickingType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_picking_type_pkey");

                entity.ToTable("stock_picking_type");

                entity.HasIndex(e => e.TenantId, "stock_picking_type_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AutoShowReceptionReport).HasColumnName("auto_show_reception_report");
                entity.Property(e => e.Barcode).HasColumnName("barcode");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreateBackorder).HasColumnName("create_backorder");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DefaultLocationDestId).HasColumnName("default_location_dest_id");
                entity.Property(e => e.DefaultLocationSrcId).HasColumnName("default_location_src_id");
                entity.Property(e => e.IsRepairable).HasColumnName("is_repairable");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PrintLabel).HasColumnName("print_label");
                entity.Property(e => e.ReservationDaysBefore).HasColumnName("reservation_days_before");
                entity.Property(e => e.ReservationDaysBeforePriority).HasColumnName("reservation_days_before_priority");
                entity.Property(e => e.ReservationMethod).HasColumnName("reservation_method");
                entity.Property(e => e.ReturnPickingTypeId).HasColumnName("return_picking_type_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.SequenceCode).HasColumnName("sequence_code");
                entity.Property(e => e.SequenceId).HasColumnName("sequence_id");
                entity.Property(e => e.ShowEntirePacks).HasColumnName("show_entire_packs");
                entity.Property(e => e.ShowOperations).HasColumnName("show_operations");
                entity.Property(e => e.ShowReserved).HasColumnName("show_reserved");
                entity.Property(e => e.UseAutoConsumeComponentsLots).HasColumnName("use_auto_consume_components_lots");
                entity.Property(e => e.UseCreateComponentsLots).HasColumnName("use_create_components_lots");
                entity.Property(e => e.UseCreateLots).HasColumnName("use_create_lots");
                entity.Property(e => e.UseExistingLots).HasColumnName("use_existing_lots");
                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_picking_type_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_type_create_uid_fkey");

                entity.HasOne(d => d.DefaultLocationDest).WithMany(p => p.StockPickingTypeDefaultLocationDests)
                    .HasForeignKey(d => d.DefaultLocationDestId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_type_default_location_dest_id_fkey");

                entity.HasOne(d => d.DefaultLocationSrc).WithMany(p => p.StockPickingTypeDefaultLocationSrcs)
                    .HasForeignKey(d => d.DefaultLocationSrcId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_type_default_location_src_id_fkey");

                entity.HasOne(d => d.ReturnPickingType).WithMany(p => p.InverseReturnPickingType)
                    .HasForeignKey(d => d.ReturnPickingTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_type_return_picking_type_id_fkey");

                entity.HasOne(d => d.SequenceNavigation).WithMany(p => p.StockPickingTypes)
                    .HasForeignKey(d => d.SequenceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_type_sequence_id_fkey");

                entity.HasOne(d => d.Warehouse).WithMany(p => p.StockPickingTypes)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("stock_picking_type_warehouse_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_type_write_uid_fkey");

                //entity.HasMany(d => d.Users).WithMany(p => p.PickingTypes)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PickingTypeFavoriteUserRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("picking_type_favorite_user_rel_user_id_fkey"),
                        l => l.HasOne<StockPickingType>().WithMany()
                            .HasForeignKey("PickingTypeId")
                            .HasConstraintName("picking_type_favorite_user_rel_picking_type_id_fkey"),
                        j =>
                        {
                            j.HasKey("PickingTypeId", "UserId").HasName("picking_type_favorite_user_rel_pkey");
                            j.ToTable("picking_type_favorite_user_rel");
                            j.HasIndex(new[] { "UserId", "PickingTypeId" }, "picking_type_favorite_user_rel_user_id_picking_type_id_idx");
                            j.IndexerProperty<Guid>("PickingTypeId").HasColumnName("picking_type_id");
                            j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                        });
            });
        }
    }
}