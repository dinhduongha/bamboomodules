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
        public static void ConfigureMailActivityType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailActivityType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_activity_type_pkey");

                entity.ToTable("mail_activity_type");

                entity.HasIndex(e => e.CreatorId, "mail_activity_type_create_uid_index");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Category).HasColumnName("category");
                entity.Property(e => e.ChainingType).HasColumnName("chaining_type");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DecorationType).HasColumnName("decoration_type");
                entity.Property(e => e.DefaultNote)
                    .HasColumnType("jsonb")
                    .HasColumnName("default_note");
                entity.Property(e => e.DefaultUserId).HasColumnName("default_user_id");
                entity.Property(e => e.DelayCount).HasColumnName("delay_count");
                entity.Property(e => e.DelayFrom).HasColumnName("delay_from");
                entity.Property(e => e.DelayUnit).HasColumnName("delay_unit");
                entity.Property(e => e.Icon).HasColumnName("icon");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.Summary)
                    .HasColumnType("jsonb")
                    .HasColumnName("summary");
                entity.Property(e => e.TriggeredNextTypeId).HasColumnName("triggered_next_type_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_type_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.DefaultUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_type_default_user_id_fkey");

                entity.HasOne(d => d.TriggeredNextType).WithMany(p => p.InverseTriggeredNextType)
                    .HasForeignKey(d => d.TriggeredNextTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mail_activity_type_triggered_next_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_type_write_uid_fkey");

                //entity.HasMany(d => d.Activities).WithMany(p => p.Recommendeds)
                entity.HasMany<MailActivityType>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailActivityRel",
                        r => r.HasOne<MailActivityType>().WithMany()
                            .HasForeignKey("ActivityId")
                            .HasConstraintName("mail_activity_rel_activity_id_fkey"),
                        l => l.HasOne<MailActivityType>().WithMany()
                            .HasForeignKey("RecommendedId")
                            .HasConstraintName("mail_activity_rel_recommended_id_fkey"),
                        j =>
                        {
                            j.HasKey("ActivityId", "RecommendedId").HasName("mail_activity_rel_pkey");
                            j.ToTable("mail_activity_rel");
                            j.HasIndex(new[] { "RecommendedId", "ActivityId" }, "mail_activity_rel_recommended_id_activity_id_idx");
                        });

                //entity.HasMany(d => d.MailTemplates).WithMany(p => p.MailActivityTypes)
                entity.HasMany<MailTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailActivityTypeMailTemplateRel",
                        r => r.HasOne<MailTemplate>().WithMany()
                            .HasForeignKey("MailTemplateId")
                            .HasConstraintName("mail_activity_type_mail_template_rel_mail_template_id_fkey"),
                        l => l.HasOne<MailActivityType>().WithMany()
                            .HasForeignKey("MailActivityTypeId")
                            .HasConstraintName("mail_activity_type_mail_template_rel_mail_activity_type_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailActivityTypeId", "MailTemplateId").HasName("mail_activity_type_mail_template_rel_pkey");
                            j.ToTable("mail_activity_type_mail_template_rel");
                            j.HasIndex(new[] { "MailTemplateId", "MailActivityTypeId" }, "mail_activity_type_mail_templ_mail_template_id_mail_activit_idx");
                        });

                //entity.HasMany(d => d.Recommendeds).WithMany(p => p.Activities)
                entity.HasMany<MailActivityType>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailActivityRel",
                        r => r.HasOne<MailActivityType>().WithMany()
                            .HasForeignKey("RecommendedId")
                            .HasConstraintName("mail_activity_rel_recommended_id_fkey"),
                        l => l.HasOne<MailActivityType>().WithMany()
                            .HasForeignKey("ActivityId")
                            .HasConstraintName("mail_activity_rel_activity_id_fkey"),
                        j =>
                        {
                            j.HasKey("ActivityId", "RecommendedId").HasName("mail_activity_rel_pkey");
                            j.ToTable("mail_activity_rel");
                            j.HasIndex(new[] { "RecommendedId", "ActivityId" }, "mail_activity_rel_recommended_id_activity_id_idx");
                        });
            });
        }
    }
}