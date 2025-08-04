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
        public static void ConfigureWebsiteSaleExtraField(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebsiteSaleExtraField>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("website_sale_extra_field_pkey");

                entity.ToTable("website_sale_extra_field");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.FieldId).HasColumnName("field_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_sale_extra_field_create_uid_fkey");

                entity.HasOne(d => d.Field).WithMany(p => p.WebsiteSaleExtraFields)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_sale_extra_field_field_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.WebsiteSaleExtraFields)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_sale_extra_field_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_sale_extra_field_write_uid_fkey");
            });
        }
    }
}