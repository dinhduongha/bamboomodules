using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSmsComposer(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SmsComposer>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sms_composer_pkey");

                        entity.ToTable("sms_composer");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CompositionMode).HasColumnName("composition_mode");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.MailingId).HasColumnName("mailing_id");
                        entity.Property(e => e.MassForceSend).HasColumnName("mass_force_send");
                        entity.Property(e => e.MassKeepLog).HasColumnName("mass_keep_log");
                        entity.Property(e => e.MassSmsAllowUnsubscribe).HasColumnName("mass_sms_allow_unsubscribe");
                        entity.Property(e => e.NumberFieldName).HasColumnName("number_field_name");
                        entity.Property(e => e.Numbers).HasColumnName("numbers");
                        entity.Property(e => e.RecipientSingleNumberItf).HasColumnName("recipient_single_number_itf");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.ResIds).HasColumnName("res_ids");
                        entity.Property(e => e.ResModel).HasColumnName("res_model");
                        entity.Property(e => e.TemplateId).HasColumnName("template_id");
                        entity.Property(e => e.UseExclusionList).HasColumnName("use_exclusion_list");
                        entity.Property(e => e.UtmCampaignId).HasColumnName("utm_campaign_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SmsComposerCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sms_composer_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_composer_create_uid_fkey");

                        entity.HasOne(d => d.Mailing).WithMany(p => p.SmsComposer)
                            .HasForeignKey(d => d.MailingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_composer_mailing_id_fkey");

                        entity.HasOne(d => d.Template).WithMany(p => p.SmsComposer)
                            .HasForeignKey(d => d.TemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_composer_template_id_fkey");

                        entity.HasOne(d => d.UtmCampaign).WithMany(p => p.SmsComposer)
                            .HasForeignKey(d => d.UtmCampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_composer_utm_campaign_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SmsComposerWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sms_composer_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_composer_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}