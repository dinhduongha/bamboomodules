using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureForumPostVote(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ForumPostVote>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("forum_post_vote_pkey");

                        entity.ToTable("forum_post_vote");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CreationTime, "forum_post_vote__create_date_index");

                        entity.HasIndex(e => new { e.PostId, e.UserId }, "forum_post_vote_vote_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ForumId).HasColumnName("forum_id");
                        entity.Property(e => e.PostId).HasColumnName("post_id");
                        entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.Vote).HasColumnName("vote");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ForumPostVoteCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_post_vote_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_vote_create_uid_fkey");

                        entity.HasOne(d => d.Forum).WithMany(p => p.ForumPostVote)
                            .HasForeignKey(d => d.ForumId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_vote_forum_id_fkey");

                        entity.HasOne(d => d.Post).WithMany(p => p.ForumPostVote)
                            .HasForeignKey(d => d.PostId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("forum_post_vote_post_id_fkey");

                        // entity.HasOne(d => d.Recipient).WithMany(p => p.ForumPostVoteRecipient) .HasForeignKey(d => d.RecipientId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_post_vote_recipient_id_fkey");
                        entity.HasOne(d => d.Recipient).WithMany()
                            .HasForeignKey(d => d.RecipientId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_vote_recipient_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.ForumPostVoteUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("forum_post_vote_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("forum_post_vote_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ForumPostVoteWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_post_vote_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_vote_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}