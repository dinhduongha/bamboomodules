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
        public static void ConfigureMailMessageSubtype(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailMessageSubtype>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_message_subtype_pkey");

                entity.ToTable("mail_message_subtype");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Default).HasColumnName("default");
                entity.Property(e => e.Description)
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.Hidden).HasColumnName("hidden");
                entity.Property(e => e.Internal).HasColumnName("internal");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.RelationField).HasColumnName("relation_field");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.TrackRecipients).HasColumnName("track_recipients");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_message_subtype_create_uid_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_message_subtype_parent_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_message_subtype_write_uid_fkey");
            });
        }
    }
}