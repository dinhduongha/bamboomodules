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
        public static void ConfigureSaleOrderTemplate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrderTemplate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sale_order_template_pkey");

                entity.ToTable("sale_order_template");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Note)
                    .HasColumnType("jsonb")
                    .HasColumnName("note");
                entity.Property(e => e.NumberOfDays).HasColumnName("number_of_days");
                entity.Property(e => e.RequirePayment).HasColumnName("require_payment");
                entity.Property(e => e.RequireSignature).HasColumnName("require_signature");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_create_uid_fkey");

                entity.HasOne(d => d.MailTemplate).WithMany(p => p.SaleOrderTemplates)
                    .HasForeignKey(d => d.MailTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_mail_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_write_uid_fkey");
            });
        }
    }
}