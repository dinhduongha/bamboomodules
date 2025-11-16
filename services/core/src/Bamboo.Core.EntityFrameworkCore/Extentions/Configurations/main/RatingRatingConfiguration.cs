using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.MessageId, "rating_rating__message_id_index");

                        entity.HasIndex(e => e.ParentResId, "rating_rating__parent_res_id_index");

                        entity.HasIndex(e => e.ParentResModelId, "rating_rating__parent_res_model_id_index");

                        entity.HasIndex(e => e.ParentResModel, "rating_rating__parent_res_model_index");

                        entity.HasIndex(e => e.PublisherId, "rating_rating__publisher_id_index").HasFilter("(publisher_id IS NOT NULL)");

                        entity.HasIndex(e => e.ResId, "rating_rating__res_id_index");

                        entity.HasIndex(e => e.ResModelId, "rating_rating__res_model_id_index");

                        entity.HasIndex(e => e.ResModel, "rating_rating__res_model_index");

                        entity.HasIndex(e => new { e.ResModel, e.ResId, e.LastModificationTime }, "rating_rating_consumed_idx").HasFilter("(consumed IS TRUE)");

                        entity.HasIndex(e => new { e.ParentResModel, e.ParentResId, e.LastModificationTime }, "rating_rating_parent_consumed_idx").HasFilter("(consumed IS TRUE)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.Consumed).HasColumnName("consumed");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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
                        entity.Property(e => e.RatedOn)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("rated_on");
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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.RatingRatingCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("rating_rating_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("rating_rating_create_uid_fkey");

                        entity.HasOne(d => d.Message).WithMany(p => p.RatingRating)
                            .HasForeignKey(d => d.MessageId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("rating_rating_message_id_fkey");

                        entity.HasOne(d => d.ParentResModelNavigation).WithMany(p => p.RatingRatingParentResModelNavigation)
                            .HasForeignKey(d => d.ParentResModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("rating_rating_parent_res_model_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.RatingRatingPartner) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("rating_rating_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("rating_rating_partner_id_fkey");

                        // entity.HasOne(d => d.Publisher).WithMany(p => p.RatingRatingPublisher) .HasForeignKey(d => d.PublisherId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("rating_rating_publisher_id_fkey");
                        entity.HasOne(d => d.Publisher).WithMany()
                            .HasForeignKey(d => d.PublisherId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("rating_rating_publisher_id_fkey");

                        // entity.HasOne(d => d.RatedPartner).WithMany(p => p.RatingRatingRatedPartner) .HasForeignKey(d => d.RatedPartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("rating_rating_rated_partner_id_fkey");
                        entity.HasOne(d => d.RatedPartner).WithMany()
                            .HasForeignKey(d => d.RatedPartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("rating_rating_rated_partner_id_fkey");

                        entity.HasOne(d => d.ResModelNavigation).WithMany(p => p.RatingRatingResModelNavigation)
                            .HasForeignKey(d => d.ResModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("rating_rating_res_model_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.RatingRatingWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("rating_rating_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("rating_rating_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}