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
        public static void ConfigureWebsitePageProperty(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebsitePageProperty>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("website_page_properties_pkey");

                entity.ToTable("website_page_properties");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.OldUrl).HasColumnName("old_url");
                entity.Property(e => e.TargetModelId).HasColumnName("target_model_id");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_page_properties_create_uid_fkey");

                entity.HasOne(d => d.TargetModel).WithMany(p => p.WebsitePageProperties)
                    .HasForeignKey(d => d.TargetModelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_page_properties_target_model_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.WebsitePageProperties)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_page_properties_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_page_properties_write_uid_fkey");
            });
        }
    }
}