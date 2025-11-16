using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("data_recycle_record");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.RecycleModelId, "data_recycle_record__recycle_model_id_index").HasFilter("(recycle_model_id IS NOT NULL)");

                        entity.HasIndex(e => e.ResId, "data_recycle_record__res_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.RecycleModelId).HasColumnName("recycle_model_id");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.ResModelId).HasColumnName("res_model_id");
                        entity.Property(e => e.ResModelName).HasColumnName("res_model_name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.DataRecycleRecord) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("data_recycle_record_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("data_recycle_record_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.DataRecycleRecordCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("data_recycle_record_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("data_recycle_record_create_uid_fkey");

                        entity.HasOne(d => d.RecycleModel).WithMany(p => p.DataRecycleRecord)
                            .HasForeignKey(d => d.RecycleModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("data_recycle_record_recycle_model_id_fkey");

                        entity.HasOne(d => d.ResModel).WithMany(p => p.DataRecycleRecord)
                            .HasForeignKey(d => d.ResModelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("data_recycle_record_res_model_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.DataRecycleRecordWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("data_recycle_record_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("data_recycle_record_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}