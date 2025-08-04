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
        public static void ConfigureMailingSmsTest(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingSmsTest>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_sms_test_pkey");

                entity.ToTable("mailing_sms_test", tb => tb.HasComment("Test SMS Mailing"));

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
                entity.Property(e => e.MailingId)
                    .HasComment("Mailing")
                    .HasColumnName("mailing_id");
                entity.Property(e => e.Numbers)
                    .HasComment("Number(s)")
                    .HasColumnName("numbers");
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
                    .HasConstraintName("mailing_sms_test_create_uid_fkey");

                entity.HasOne(d => d.Mailing).WithMany(p => p.MailingSmsTests)
                    .HasForeignKey(d => d.MailingId)
                    .HasConstraintName("mailing_sms_test_mailing_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_sms_test_write_uid_fkey");
            });
        }
    }
}