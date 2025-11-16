using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureDataRecycleModel(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<DataRecycleModel>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("data_recycle_model_pkey");

                        entity.ToTable("data_recycle_model");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.Domain).HasColumnName("domain");
                        entity.Property(e => e.IncludeArchived).HasColumnName("include_archived");
                        entity.Property(e => e.LastNotification)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_notification");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.NotifyFrequency).HasColumnName("notify_frequency");
                        entity.Property(e => e.NotifyFrequencyPeriod).HasColumnName("notify_frequency_period");
                        entity.Property(e => e.RecycleAction).HasColumnName("recycle_action");
                        entity.Property(e => e.RecycleMode).HasColumnName("recycle_mode");
                        entity.Property(e => e.ResModelId).HasColumnName("res_model_id");
                        entity.Property(e => e.ResModelName).HasColumnName("res_model_name");
                        entity.Property(e => e.TimeFieldDelta).HasColumnName("time_field_delta");
                        entity.Property(e => e.TimeFieldDeltaUnit).HasColumnName("time_field_delta_unit");
                        entity.Property(e => e.TimeFieldId).HasColumnName("time_field_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.DataRecycleModelCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("data_recycle_model_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("data_recycle_model_create_uid_fkey");

                        entity.HasOne(d => d.ResModel).WithMany(p => p.DataRecycleModel)
                            .HasForeignKey(d => d.ResModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("data_recycle_model_res_model_id_fkey");

                        entity.HasOne(d => d.TimeField).WithMany(p => p.DataRecycleModel)
                            .HasForeignKey(d => d.TimeFieldId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("data_recycle_model_time_field_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.DataRecycleModelWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("data_recycle_model_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("data_recycle_model_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.DataRecycleModel)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "DataRecycleModelResUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("data_recycle_model_res_users_rel_res_users_id_fkey"),
                                l => l.HasOne<DataRecycleModel>().WithMany()
                                    .HasForeignKey("DataRecycleModelId")
                                    .HasConstraintName("data_recycle_model_res_users_rel_data_recycle_model_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DataRecycleModelId", "ResUsersId").HasName("data_recycle_model_res_users_rel_pkey");
                                    j.ToTable("data_recycle_model_res_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "DataRecycleModelId" }, "data_recycle_model_res_users__res_users_id_data_recycle_mod_idx");
                                    j.IndexerProperty<Guid>("DataRecycleModelId").HasColumnName("data_recycle_model_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}