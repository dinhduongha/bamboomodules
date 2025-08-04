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
        public static void ConfigureRatingRating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RatingRating>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("rating_rating_pkey");

                entity.ToTable("rating_rating");

                entity.HasIndex(e => e.MessageId, "rating_rating_message_id_index");

                entity.HasIndex(e => e.ParentResId, "rating_rating_parent_res_id_index");

                entity.HasIndex(e => e.ParentResModelId, "rating_rating_parent_res_model_id_index");

                entity.HasIndex(e => e.ParentResModel, "rating_rating_parent_res_model_index");

                entity.HasIndex(e => e.ResId, "rating_rating_res_id_index");

                entity.HasIndex(e => e.ResModelId, "rating_rating_res_model_id_index");

                entity.HasIndex(e => e.ResModel, "rating_rating_res_model_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessToken).HasColumnName("access_token");
                entity.Property(e => e.Consumed).HasColumnName("consumed");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Feedback).HasColumnName("feedback");
                entity.Property(e => e.IsInternal).HasColumnName("is_internal");
                entity.Property(e => e.MessageId).HasColumnName("message_id");
                entity.Property(e => e.ParentResId).HasColumnName("parent_res_id");
                entity.Property(e => e.ParentResModel).HasColumnName("parent_res_model");
                entity.Property(e => e.ParentResModelId).HasColumnName("parent_res_model_id");
                entity.Property(e => e.ParentResName).HasColumnName("parent_res_name");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PublisherComment).HasColumnName("publisher_comment");
                entity.Property(e => e.PublisherDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("publisher_datetime");
                entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
                entity.Property(e => e.RatedPartnerId).HasColumnName("rated_partner_id");
                entity.Property(e => e.Rating).HasColumnName("rating");
                entity.Property(e => e.RatingText).HasColumnName("rating_text");
                entity.Property(e => e.ResId).HasColumnName("res_id");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.ResModelId).HasColumnName("res_model_id");
                entity.Property(e => e.ResName).HasColumnName("res_name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("rating_rating_create_uid_fkey");

                entity.HasOne(d => d.Message).WithMany(p => p.RatingRatings)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("rating_rating_message_id_fkey");

                entity.HasOne(d => d.ParentResModelNavigation).WithMany(p => p.RatingRatingParentResModelNavigations)
                    .HasForeignKey(d => d.ParentResModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("rating_rating_parent_res_model_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("rating_rating_partner_id_fkey");

                entity.HasOne(d => d.Publisher).WithMany(p => p.RatingRatingPublishers)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("rating_rating_publisher_id_fkey");

                entity.HasOne(d => d.RatedPartner).WithMany(p => p.RatingRatingRatedPartners)
                    .HasForeignKey(d => d.RatedPartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("rating_rating_rated_partner_id_fkey");

                entity.HasOne(d => d.ResModelNavigation).WithMany(p => p.RatingRatingResModelNavigations)
                    .HasForeignKey(d => d.ResModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("rating_rating_res_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("rating_rating_write_uid_fkey");
            });
        }
    }
}