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
        public static void ConfigureWebTourTour(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebTourTour>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("web_tour_tour_pkey");

                entity.ToTable("web_tour_tour");

                entity.HasIndex(e => e.Name, "web_tour_tour_uniq_name").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Custom).HasColumnName("custom");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.RainbowManMessage)
                    .HasColumnType("jsonb")
                    .HasColumnName("rainbow_man_message");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("web_tour_tour_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("web_tour_tour_write_uid_fkey");

                entity.HasMany(d => d.ResUsers).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ResUsersWebTourTourRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("ResUsersId")
                            .HasConstraintName("res_users_web_tour_tour_rel_res_users_id_fkey"),
                        l => l.HasOne<WebTourTour>().WithMany()
                            .HasForeignKey("WebTourTourId")
                            .HasConstraintName("res_users_web_tour_tour_rel_web_tour_tour_id_fkey"),
                        j =>
                        {
                            j.HasKey("WebTourTourId", "ResUsersId").HasName("res_users_web_tour_tour_rel_pkey");
                            j.ToTable("res_users_web_tour_tour_rel");
                            j.HasIndex(new[] { "ResUsersId", "WebTourTourId" }, "res_users_web_tour_tour_rel_res_users_id_web_tour_tour_id_idx");
                            j.IndexerProperty<Guid>("WebTourTourId").HasColumnName("web_tour_tour_id");
                            j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                        });
            });
        }
    }
}