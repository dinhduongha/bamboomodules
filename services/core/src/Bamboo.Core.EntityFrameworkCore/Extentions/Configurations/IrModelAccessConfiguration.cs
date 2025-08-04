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
        public static void ConfigureIrModelAccess(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrModelAccess>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_model_access_pkey");

                entity.ToTable("ir_model_access");

                entity.HasIndex(e => e.GroupId, "ir_model_access_group_id_index");

                entity.HasIndex(e => e.ModelId, "ir_model_access_model_id_index");

                entity.HasIndex(e => e.Name, "ir_model_access_name_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PermCreate).HasColumnName("perm_create");
                entity.Property(e => e.PermRead).HasColumnName("perm_read");
                entity.Property(e => e.PermUnlink).HasColumnName("perm_unlink");
                entity.Property(e => e.PermWrite).HasColumnName("perm_write");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_model_access_create_uid_fkey");

                entity.HasOne(d => d.Group).WithMany(p => p.IrModelAccesses)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ir_model_access_group_id_fkey");

                entity.HasOne(d => d.Model).WithMany(p => p.IrModelAccesses)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_model_access_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_model_access_write_uid_fkey");
            });
        }
    }
}