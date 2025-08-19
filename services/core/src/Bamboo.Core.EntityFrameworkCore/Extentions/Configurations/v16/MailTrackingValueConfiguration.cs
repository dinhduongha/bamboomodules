using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailTrackingValue(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailTrackingValue>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_tracking_value_pkey");

            entity.ToTable("mail_tracking_value");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.FieldId, "mail_tracking_value__field_id_index");

            // v16-Compat	
            entity.HasIndex(e => e.Field, "mail_tracking_value_field_index");

            entity.HasIndex(e => e.MailMessageId, "mail_tracking_value__mail_message_id_index");

            entity.HasIndex(e => new { e.MailMessageId, e.OldValueInteger }, "mail_tracking_value_mail_message_id_old_value_integer_task_stag").HasFilter("(field_id = '00000000-0000-0000-0000-00000000264b'::uuid)");

            // v16-Compat -- CHECK ID            
            //entity.HasIndex(e => new { e.MailMessageId, e.OldValueInteger }, "mail_tracking_value_mail_message_id_old_value_integer_task_stag").HasFilter("(field = '00000000-0000-0000-0000-0000000032cb'::uuid)");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Field).HasColumnName("field");
            entity.Property(e => e.FieldDesc).HasColumnName("field_desc");
            entity.Property(e => e.FieldId).HasColumnName("field_id");
            entity.Property(e => e.FieldInfo)
                .HasColumnType("jsonb")
                .HasColumnName("field_info");
            entity.Property(e => e.FieldType).HasColumnName("field_type");
            entity.Property(e => e.MailMessageId).HasColumnName("mail_message_id");
            entity.Property(e => e.NewValueChar).HasColumnName("new_value_char");
            entity.Property(e => e.NewValueDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("new_value_datetime");
            entity.Property(e => e.NewValueFloat).HasColumnName("new_value_float");
            entity.Property(e => e.NewValueInteger).HasColumnName("new_value_integer");
            entity.Property(e => e.NewValueMonetary).HasColumnName("new_value_monetary");
            entity.Property(e => e.NewValueText).HasColumnName("new_value_text");
            entity.Property(e => e.OldValueChar).HasColumnName("old_value_char");
            entity.Property(e => e.OldValueDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("old_value_datetime");
            entity.Property(e => e.OldValueFloat).HasColumnName("old_value_float");
            entity.Property(e => e.OldValueInteger).HasColumnName("old_value_integer");
            entity.Property(e => e.OldValueMonetary).HasColumnName("old_value_monetary");
            entity.Property(e => e.OldValueText).HasColumnName("old_value_text");
            entity.Property(e => e.TrackingSequence).HasColumnName("tracking_sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailTrackingValueCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_tracking_value_create_uid_fkey");

                // entity.HasOne(d => d.Currency).WithMany(p => p.MailTrackingValue)
                entity.HasOne(d => d.Currency).WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_tracking_value_currency_id_fkey");

            //entity.HasOne(d => d.ModelField).WithMany(p => p.MailTrackingValue)
            entity.HasOne(d => d.ModelField).WithMany()
                .HasForeignKey(d => d.FieldId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_tracking_value_field_id_fkey");

            //entity.HasOne(d => d.FieldNavigation).WithMany(p => p.MailTrackingValueNavigation)
            entity.HasOne(d => d.FieldNavigation).WithMany()
                .HasForeignKey(d => d.Field)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_tracking_value_field_fkey");

            entity.HasOne(d => d.MailMessage).WithMany(p => p.MailTrackingValue)
                .HasForeignKey(d => d.MailMessageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_tracking_value_mail_message_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailTrackingValueWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_tracking_value_write_uid_fkey");
            });
        }
    }
}
