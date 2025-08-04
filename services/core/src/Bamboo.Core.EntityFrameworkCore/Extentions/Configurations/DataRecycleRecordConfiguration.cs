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
        public static void ConfigureDataRecycleRecord(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataRecycleRecord>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("data_recycle_record_pkey");

                entity.ToTable("data_recycle_record", tb => tb.HasComment("Recycling Record"));

                entity.HasIndex(e => e.ResId, "data_recycle_record_res_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.TenantId)
                    .HasComment("Company")
                    .HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.RecycleModelId)
                    .HasComment("Recycle Model")
                    .HasColumnName("recycle_model_id");
                entity.Property(e => e.ResId)
                    .HasComment("Record ID")
                    .HasColumnName("res_id");
                entity.Property(e => e.ResModelId)
                    .HasComment("Model")
                    .HasColumnName("res_model_id");
                entity.Property(e => e.ResModelName)
                    .HasComment("Model Name")
                    .HasColumnType("character varying")
                    .HasColumnName("res_model_name");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("data_recycle_record_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("data_recycle_record_create_uid_fkey");

                entity.HasOne(d => d.RecycleModel).WithMany(p => p.DataRecycleRecords)
                    .HasForeignKey(d => d.RecycleModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("data_recycle_record_recycle_model_id_fkey");

                entity.HasOne(d => d.ResModel).WithMany(p => p.DataRecycleRecords)
                    .HasForeignKey(d => d.ResModelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("data_recycle_record_res_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("data_recycle_record_write_uid_fkey");
            });
        }
    }
}