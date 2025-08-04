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
        public static void ConfigureWebsitePagePropertiesBase(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebsitePagePropertiesBase>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("website_page_properties_base_pkey");

                entity.ToTable("website_page_properties_base");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.TargetModelId).HasColumnName("target_model_id");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_page_properties_base_create_uid_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.WebsitePagePropertiesBases)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_page_properties_base_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_page_properties_base_write_uid_fkey");
            });
        }
    }
}