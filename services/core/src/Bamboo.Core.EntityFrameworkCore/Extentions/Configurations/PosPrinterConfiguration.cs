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
        public static void ConfigurePosPrinter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosPrinter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pos_printer_pkey");

                entity.ToTable("pos_printer");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_printer_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_printer_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_printer_write_uid_fkey");

                entity.HasMany(d => d.Categories).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PrinterCategoryRel",
                        r => r.HasOne<PosCategory>().WithMany()
                            .HasForeignKey("CategoryId")
                            .HasConstraintName("printer_category_rel_category_id_fkey"),
                        l => l.HasOne<PosPrinter>().WithMany()
                            .HasForeignKey("PrinterId")
                            .HasConstraintName("printer_category_rel_printer_id_fkey"),
                        j =>
                        {
                            j.HasKey("PrinterId", "CategoryId").HasName("printer_category_rel_pkey");
                            j.ToTable("printer_category_rel");
                            j.HasIndex(new[] { "CategoryId", "PrinterId" }, "printer_category_rel_category_id_printer_id_idx");
                            j.IndexerProperty<Guid>("PrinterId").HasColumnName("printer_id");
                            j.IndexerProperty<Guid>("CategoryId").HasColumnName("category_id");
                        });
            });
        }
    }
}