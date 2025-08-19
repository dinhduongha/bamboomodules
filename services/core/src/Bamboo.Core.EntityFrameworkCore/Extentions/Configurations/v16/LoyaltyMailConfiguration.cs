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
        public static void ConfigureLoyaltyMail(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LoyaltyMail>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("loyalty_mail_pkey");

            entity.ToTable("loyalty_mail");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.PosReportPrintId).HasColumnName("pos_report_print_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.Trigger).HasColumnName("trigger");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.LoyaltyMailCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_mail_create_uid_fkey");

            entity.HasOne(d => d.MailTemplate).WithMany(p => p.LoyaltyMail)
                .HasForeignKey(d => d.MailTemplateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("loyalty_mail_mail_template_id_fkey");

            entity.HasOne(d => d.PosReportPrint).WithMany(p => p.LoyaltyMail)
                .HasForeignKey(d => d.PosReportPrintId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_mail_pos_report_print_id_fkey");

            entity.HasOne(d => d.Program).WithMany(p => p.LoyaltyMail)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("loyalty_mail_program_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.LoyaltyMailWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_mail_write_uid_fkey");
            });
        }
    }
}
