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
        public static void ConfigureFollowupPrint(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FollowupPrint>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("followup_print_pkey");

                entity.ToTable("followup_print");

                entity.HasIndex(e => e.TenantId, "followup_print_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.EmailBody).HasColumnName("email_body");
                entity.Property(e => e.EmailConf).HasColumnName("email_conf");
                entity.Property(e => e.EmailSubject).HasColumnName("email_subject");
                entity.Property(e => e.FollowupId).HasColumnName("followup_id");
                entity.Property(e => e.PartnerLang).HasColumnName("partner_lang");
                entity.Property(e => e.Summary).HasColumnName("summary");
                entity.Property(e => e.TestPrint).HasColumnName("test_print");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("followup_print_create_uid_fkey");

                entity.HasOne(d => d.Followup).WithMany(p => p.FollowupPrints)
                    .HasForeignKey(d => d.FollowupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("followup_print_followup_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("followup_print_write_uid_fkey");
            });
        }
    }
}