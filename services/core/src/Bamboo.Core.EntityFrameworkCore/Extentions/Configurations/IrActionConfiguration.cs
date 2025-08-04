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
        public static void ConfigureIrAction(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrAction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_actions_pkey");

                entity.ToTable("ir_actions");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.BindingModelId).HasColumnName("binding_model_id");
                entity.Property(e => e.BindingType).HasColumnName("binding_type");
                entity.Property(e => e.BindingViewTypes).HasColumnName("binding_view_types");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Help)
                    .HasColumnType("jsonb")
                    .HasColumnName("help");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.BindingModel).WithMany(p => p.IrActions)
                    .HasForeignKey(d => d.BindingModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_actions_binding_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_actions_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_actions_write_uid_fkey");
            });
        }
    }
}