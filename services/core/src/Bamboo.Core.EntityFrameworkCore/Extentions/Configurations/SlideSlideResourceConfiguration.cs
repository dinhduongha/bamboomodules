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
        public static void ConfigureSlideSlideResource(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideSlideResource>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_slide_resource_pkey");

                entity.ToTable("slide_slide_resource", tb => tb.HasComment("Additional resource for a particular slide"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.FileName)
                    .HasComment("File Name")
                    .HasColumnType("character varying")
                    .HasColumnName("file_name");
                entity.Property(e => e.Link)
                    .HasComment("Link")
                    .HasColumnType("character varying")
                    .HasColumnName("link");
                entity.Property(e => e.Name)
                    .HasComment("Name")
                    .HasColumnType("character varying")
                    .HasColumnName("name");
                entity.Property(e => e.ResourceType)
                    .HasComment("Resource Type")
                    .HasColumnType("character varying")
                    .HasColumnName("resource_type");
                entity.Property(e => e.SlideId)
                    .HasComment("Slide")
                    .HasColumnName("slide_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_resource_create_uid_fkey");

                entity.HasOne(d => d.Slide).WithMany(p => p.SlideSlideResources)
                    .HasForeignKey(d => d.SlideId)
                    .HasConstraintName("slide_slide_resource_slide_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_resource_write_uid_fkey");
            });
        }
    }
}