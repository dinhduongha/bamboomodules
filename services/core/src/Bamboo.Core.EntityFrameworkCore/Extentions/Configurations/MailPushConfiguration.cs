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
        public static void ConfigureMailPush(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailPush>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_push_pkey");

                entity.ToTable("mail_push");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.MailPushDeviceId).HasColumnName("mail_push_device_id");
                entity.Property(e => e.Payload).HasColumnName("payload");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_push_create_uid_fkey");

                entity.HasOne(d => d.MailPushDevice).WithMany(p => p.MailPushes)
                    .HasForeignKey(d => d.MailPushDeviceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_push_mail_push_device_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_push_write_uid_fkey");
            });
        }
    }
}