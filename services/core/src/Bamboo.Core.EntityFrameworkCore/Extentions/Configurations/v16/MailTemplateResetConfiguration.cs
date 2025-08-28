using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailTemplateReset(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailTemplateReset>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_template_reset_pkey");

                        entity.ToTable("mail_template_reset");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailTemplateResetCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_template_reset_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_template_reset_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailTemplateResetWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_template_reset_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_template_reset_write_uid_fkey");

                        // entity.HasMany(d => d.MailTemplate).WithMany(p => p.MailTemplateReset)
                        entity.HasMany(d => d.MailTemplate).WithMany(p => p.MailTemplateReset)
                            .UsingEntity<Dictionary<string, object>>(
                                "MailTemplateMailTemplateResetRel",
                                r => r.HasOne<MailTemplate>().WithMany()
                                    .HasForeignKey("MailTemplateId")
                                    .HasConstraintName("mail_template_mail_template_reset_rel_mail_template_id_fkey"),
                                l => l.HasOne<MailTemplateReset>().WithMany()
                                    .HasForeignKey("MailTemplateResetId")
                                    .HasConstraintName("mail_template_mail_template_reset_r_mail_template_reset_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MailTemplateResetId", "MailTemplateId").HasName("mail_template_mail_template_reset_rel_pkey");
                                    j.ToTable("mail_template_mail_template_reset_rel");
                                    j.HasIndex(new[] { "MailTemplateId", "MailTemplateResetId" }, "mail_template_mail_template_r_mail_template_id_mail_templat_idx");
                                    j.IndexerProperty<Guid>("MailTemplateResetId").HasColumnName("mail_template_reset_id");
                                    j.IndexerProperty<Guid>("MailTemplateId").HasColumnName("mail_template_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}