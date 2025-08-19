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
        public static void ConfigureMailTemplate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailTemplate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_template_pkey");

            entity.ToTable("mail_template");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Model, "mail_template__model_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AutoDelete).HasColumnName("auto_delete");
            entity.Property(e => e.BodyHtml)
                .HasColumnType("jsonb")
                .HasColumnName("body_html");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasColumnType("jsonb")
                .HasColumnName("description");
            entity.Property(e => e.EmailCc).HasColumnName("email_cc");
            entity.Property(e => e.EmailFrom).HasColumnName("email_from");
            entity.Property(e => e.EmailLayoutXmlid).HasColumnName("email_layout_xmlid");
            entity.Property(e => e.EmailTo).HasColumnName("email_to");
            entity.Property(e => e.Lang).HasColumnName("lang");
            entity.Property(e => e.MailServerId).HasColumnName("mail_server_id");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.PartnerTo).HasColumnName("partner_to");
            entity.Property(e => e.RefIrActWindow).HasColumnName("ref_ir_act_window");
            entity.Property(e => e.ReplyTo).HasColumnName("reply_to");
            entity.Property(e => e.ReportName)
                .HasColumnType("jsonb")
                .HasColumnName("report_name");
            entity.Property(e => e.ReportTemplate).HasColumnName("report_template");
            entity.Property(e => e.ScheduledDate).HasColumnName("scheduled_date");
            entity.Property(e => e.Subject)
                .HasColumnType("jsonb")
                .HasColumnName("subject");
            entity.Property(e => e.TemplateFs).HasColumnName("template_fs");
            entity.Property(e => e.UseDefaultTo).HasColumnName("use_default_to");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailTemplateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_template_create_uid_fkey");

            entity.HasOne(d => d.MailServer).WithMany(p => p.MailTemplate)
                .HasForeignKey(d => d.MailServerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_template_mail_server_id_fkey");

            entity.HasOne(d => d.ModelNavigation).WithMany(p => p.MailTemplate)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_template_model_id_fkey");

            entity.HasOne(d => d.RefIrActWindowNavigation).WithMany(p => p.MailTemplate)
                .HasForeignKey(d => d.RefIrActWindow)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_template_ref_ir_act_window_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.MailTemplateUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_template_user_id_fkey");

            entity.HasOne(d => d.ReportTemplateNavigation).WithMany(p => p.MailTemplate)
                .HasForeignKey(d => d.ReportTemplate)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_template_report_template_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailTemplateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_template_write_uid_fkey");

            // entity.HasMany(d => d.Attachment).WithMany(p => p.EmailTemplate)
            entity.HasMany(d => d.Attachment).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "EmailTemplateAttachmentRel",
                    r => r.HasOne<IrAttachment>().WithMany()
                        .HasForeignKey("AttachmentId")
                        .HasConstraintName("email_template_attachment_rel_attachment_id_fkey"),
                    l => l.HasOne<MailTemplate>().WithMany()
                        .HasForeignKey("EmailTemplateId")
                        .HasConstraintName("email_template_attachment_rel_email_template_id_fkey"),
                    j =>
                    {
                        j.HasKey("EmailTemplateId", "AttachmentId").HasName("email_template_attachment_rel_pkey");
                        j.ToTable("email_template_attachment_rel");
                        j.HasIndex(new[] { "AttachmentId", "EmailTemplateId" }, "email_template_attachment_rel_attachment_id_email_template__idx");
                        j.IndexerProperty<Guid>("EmailTemplateId").HasColumnName("email_template_id");
                        j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                    });

            // entity.HasMany(d => d.IrActionsReport).WithMany(p => p.MailTemplate)
            entity.HasMany(d => d.IrActionsReport).WithMany(p => p.MailTemplate)
                .UsingEntity<Dictionary<string, object>>(
                    "MailTemplateIrActionsReportRel",
                    r => r.HasOne<IrActReportXml>().WithMany()
                        .HasForeignKey("IrActionsReportId")
                        .HasConstraintName("mail_template_ir_actions_report_rel_ir_actions_report_id_fkey"),
                    l => l.HasOne<MailTemplate>().WithMany()
                        .HasForeignKey("MailTemplateId")
                        .HasConstraintName("mail_template_ir_actions_report_rel_mail_template_id_fkey"),
                    j =>
                    {
                        j.HasKey("MailTemplateId", "IrActionsReportId").HasName("mail_template_ir_actions_report_rel_pkey");
                        j.ToTable("mail_template_ir_actions_report_rel");
                        j.HasIndex(new[] { "IrActionsReportId", "MailTemplateId" }, "mail_template_ir_actions_repo_ir_actions_report_id_mail_tem_idx");
                        j.IndexerProperty<Guid>("MailTemplateId").HasColumnName("mail_template_id");
                        j.IndexerProperty<Guid>("IrActionsReportId").HasColumnName("ir_actions_report_id");
                    });
            });
        }
    }
}
