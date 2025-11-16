using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureRestaurantTable(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RestaurantTable>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("restaurant_table_pkey");

                        entity.ToTable("restaurant_table");

                        entity.HasIndex(e => e.FloorId, "restaurant_table__floor_id_index").HasFilter("(floor_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FloorId).HasColumnName("floor_id");
                        entity.Property(e => e.Height).HasColumnName("height");
                        entity.Property(e => e.Identifier).HasColumnName("identifier");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.PositionH).HasColumnName("position_h");
                        entity.Property(e => e.PositionV).HasColumnName("position_v");
                        entity.Property(e => e.Seats).HasColumnName("seats");
                        entity.Property(e => e.Shape).HasColumnName("shape");
                        entity.Property(e => e.TableNumber).HasColumnName("table_number");
                        entity.Property(e => e.Width).HasColumnName("width");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.RestaurantTableCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("restaurant_table_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("restaurant_table_create_uid_fkey");

                        entity.HasOne(d => d.Floor).WithMany(p => p.RestaurantTable)
                            .HasForeignKey(d => d.FloorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("restaurant_table_floor_id_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("restaurant_table_parent_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.RestaurantTableWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("restaurant_table_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("restaurant_table_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}