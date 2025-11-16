using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventTag(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventTag>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_tag_pkey");

                        entity.ToTable("event_tag");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CategoryId, "event_tag__category_id_index");

                        entity.HasIndex(e => e.IsPublished, "event_tag__is_published_index");

                        entity.HasIndex(e => e.WebsiteId, "event_tag__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");
                        entity.Property(e => e.CategorySequence).HasColumnName("category_sequence");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Category).WithMany(p => p.EventTag)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_tag_category_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventTagCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_tag_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_tag_create_uid_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.EventTag) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("event_tag_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_tag_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventTagWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_tag_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_tag_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}