using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResPartnerCategory(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResPartnerCategory>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_partner_category_pkey");

            entity.ToTable("res_partner_category");

            entity.HasIndex(e => e.ParentId, "res_partner_category__parent_id_index");

            entity.HasIndex(e => e.ParentPath, "res_partner_category__parent_path_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.ParentPath).HasColumnName("parent_path");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ResPartnerCategoryCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_category_create_uid_fkey");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("res_partner_category_parent_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ResPartnerCategoryWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_category_write_uid_fkey");

            // entity.HasMany(d => d.Partner).WithMany(p => p.Category)
            entity.HasMany(d => d.Partner).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ResPartnerResPartnerCategoryRel",
                    r => r.HasOne<ResPartner>().WithMany()
                        .HasForeignKey("PartnerId")
                        .HasConstraintName("res_partner_res_partner_category_rel_partner_id_fkey"),
                    l => l.HasOne<ResPartnerCategory>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("res_partner_res_partner_category_rel_category_id_fkey"),
                    j =>
                    {
                        j.HasKey("CategoryId", "PartnerId").HasName("res_partner_res_partner_category_rel_pkey");
                        j.ToTable("res_partner_res_partner_category_rel");
                        j.HasIndex(new[] { "PartnerId", "CategoryId" }, "res_partner_res_partner_category_rel_partner_id_category_id_idx");
                        j.IndexerProperty<Guid>("CategoryId").HasColumnName("category_id");
                        j.IndexerProperty<Guid>("PartnerId").HasColumnName("partner_id");
                    });
            });
        }
    }
}
