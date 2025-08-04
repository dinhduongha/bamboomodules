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
        public static void ConfigureIrFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrFilter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_filters_pkey");

                entity.ToTable("ir_filters");

                // TODO: Check tenant
                entity.HasIndex(e => new { e.ModelId, e.UserId, e.ActionId, e.Name }, "ir_filters_name_model_uid_unique").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ActionId).HasColumnName("action_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Context).HasColumnName("context");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Domain).HasColumnName("domain");
                entity.Property(e => e.IsDefault).HasColumnName("is_default");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Sort).HasColumnName("sort");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_filters_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_filters_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_filters_write_uid_fkey");
            });
        }
    }
}