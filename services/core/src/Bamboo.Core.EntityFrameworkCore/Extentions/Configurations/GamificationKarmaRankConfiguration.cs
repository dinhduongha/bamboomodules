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
        public static void ConfigureGamificationKarmaRank(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationKarmaRank>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_karma_rank_pkey");

                entity.ToTable("gamification_karma_rank", tb => tb.HasComment("Rank based on karma"));

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
                entity.Property(e => e.Description)
                    .HasComment("Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.DescriptionMotivational)
                    .HasComment("Motivational")
                    .HasColumnType("jsonb")
                    .HasColumnName("description_motivational");
                entity.Property(e => e.KarmaMin)
                    .HasComment("Required Karma")
                    .HasColumnName("karma_min");
                entity.Property(e => e.Name)
                    .HasComment("Rank Name")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
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
                    .HasConstraintName("gamification_karma_rank_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_karma_rank_write_uid_fkey");
            });
        }
    }
}