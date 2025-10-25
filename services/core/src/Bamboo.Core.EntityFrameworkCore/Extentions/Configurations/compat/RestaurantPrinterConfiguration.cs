using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureRestaurantPrinter(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RestaurantPrinter>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("restaurant_printer_pkey");

                        entity.ToTable("restaurant_printer");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EpsonPrinterIp).HasColumnName("epson_printer_ip");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PrinterType).HasColumnName("printer_type");
                        entity.Property(e => e.ProxyIp).HasColumnName("proxy_ip");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.RestaurantPrinterCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("restaurant_printer_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("restaurant_printer_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.RestaurantPrinterWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("restaurant_printer_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("restaurant_printer_write_uid_fkey");

                        // entity.HasMany(d => d.Category).WithMany(p => p.Printer)
                        entity.HasMany(d => d.Category).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "RestaurantPrinterCategoryRel",
                                r => r.HasOne<PosCategory>().WithMany()
                                    .HasForeignKey("CategoryId")
                                    .HasConstraintName("restaurant_printer_category_rel_category_id_fkey"),
                                l => l.HasOne<RestaurantPrinter>().WithMany()
                                    .HasForeignKey("PrinterId")
                                    .HasConstraintName("restaurant_printer_category_rel_printer_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PrinterId", "CategoryId").HasName("restaurant_printer_category_rel_pkey");
                                    j.ToTable("restaurant_printer_category_rel");
                                    j.HasIndex(new[] { "CategoryId", "PrinterId" }, "restaurant_printer_category_rel_category_id_printer_id_idx");
                                    j.IndexerProperty<Guid>("PrinterId").HasColumnName("printer_id");
                                    j.IndexerProperty<Guid>("CategoryId").HasColumnName("category_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}