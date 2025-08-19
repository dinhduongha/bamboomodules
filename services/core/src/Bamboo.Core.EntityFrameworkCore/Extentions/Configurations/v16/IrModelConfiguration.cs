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
        public static void ConfigureIrModel(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrModel>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_model_pkey");

            entity.ToTable("ir_model");

            entity.HasIndex(e => e.Model, "ir_model_obj_name_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Info).HasColumnName("info");
            entity.Property(e => e.IsMailActivity).HasColumnName("is_mail_activity");
            entity.Property(e => e.IsMailBlacklist).HasColumnName("is_mail_blacklist");
            entity.Property(e => e.IsMailThread).HasColumnName("is_mail_thread");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Transient).HasColumnName("transient");
            entity.Property(e => e.WebsiteFormAccess).HasColumnName("website_form_access");
            entity.Property(e => e.WebsiteFormDefaultFieldId).HasColumnName("website_form_default_field_id");
            entity.Property(e => e.WebsiteFormKey).HasColumnName("website_form_key");
            entity.Property(e => e.WebsiteFormLabel).HasColumnName("website_form_label");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrModelCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_model_create_uid_fkey");

            entity.HasOne(d => d.WebsiteFormDefaultField).WithMany(p => p.IrModel)
                .HasForeignKey(d => d.WebsiteFormDefaultFieldId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_model_website_form_default_field_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrModelWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_model_write_uid_fkey");
            });
        }
    }
}