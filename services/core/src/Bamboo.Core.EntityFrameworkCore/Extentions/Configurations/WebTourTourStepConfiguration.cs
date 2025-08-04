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
        public static void ConfigureWebTourTourStep(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebTourTourStep>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("web_tour_tour_step_pkey");

                entity.ToTable("web_tour_tour_step");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Content).HasColumnName("content");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Run).HasColumnName("run");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.TourId).HasColumnName("tour_id");
                entity.Property(e => e.Trigger).HasColumnName("trigger");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("web_tour_tour_step_create_uid_fkey");

                entity.HasOne(d => d.Tour).WithMany(p => p.WebTourTourSteps)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("web_tour_tour_step_tour_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("web_tour_tour_step_write_uid_fkey");
            });
        }
    }
}