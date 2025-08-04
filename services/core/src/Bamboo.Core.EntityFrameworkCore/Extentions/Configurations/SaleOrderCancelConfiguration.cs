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
        public static void ConfigureSaleOrderCancel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrderCancel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sale_order_cancel_pkey");

                entity.ToTable("sale_order_cancel");

                entity.HasIndex(e => e.TenantId, "sale_order_cancel_company_id_index");

                entity.HasIndex(e => e.AuthorId, "sale_order_cancel_author_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AuthorId).HasColumnName("author_id");
                entity.Property(e => e.Body).HasColumnName("body");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                entity.Property(e => e.Lang).HasColumnName("lang");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.Subject).HasColumnName("subject");
                entity.Property(e => e.TemplateId).HasColumnName("template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Author).WithMany(p => p.SaleOrderCancels)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_cancel_author_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_cancel_create_uid_fkey");

                entity.HasOne(d => d.Order).WithMany(p => p.SaleOrderCancels)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sale_order_cancel_order_id_fkey");

                entity.HasOne(d => d.Template).WithMany(p => p.SaleOrderCancels)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_cancel_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_cancel_write_uid_fkey");
            });
        }
    }
}