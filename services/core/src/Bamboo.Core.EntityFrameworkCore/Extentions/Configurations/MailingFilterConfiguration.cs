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
        public static void ConfigureMailingFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingFilter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_filter_pkey");

                entity.ToTable("mailing_filter", tb => tb.HasComment("Mailing Favorite Filters"));

                entity.HasIndex(e => e.CreatorId, "mailing_filter_create_uid_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Saved by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.MailingDomain)
                    .HasComment("Filter Domain")
                    .HasColumnType("character varying")
                    .HasColumnName("mailing_domain");
                entity.Property(e => e.MailingModelId)
                    .HasComment("Recipients Model")
                    .HasColumnName("mailing_model_id");
                entity.Property(e => e.Name)
                    .HasComment("Filter Name")
                    .HasColumnType("character varying")
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
                    .HasConstraintName("mailing_filter_create_uid_fkey");

                entity.HasOne(d => d.MailingModel).WithMany(p => p.MailingFilters)
                    .HasForeignKey(d => d.MailingModelId)
                    .HasConstraintName("mailing_filter_mailing_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_filter_write_uid_fkey");
            });
        }
    }
}