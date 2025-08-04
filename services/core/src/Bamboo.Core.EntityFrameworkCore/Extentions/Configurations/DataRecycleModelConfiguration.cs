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
        public static void ConfigureDataRecycleModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataRecycleModel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("data_recycle_model_pkey");

                entity.ToTable("data_recycle_model", tb => tb.HasComment("Recycling Model"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Domain)
                    .HasComment("Filter")
                    .HasColumnType("character varying")
                    .HasColumnName("domain");
                entity.Property(e => e.IncludeArchived)
                    .HasComment("Include Archived")
                    .HasColumnName("include_archived");
                entity.Property(e => e.LastNotification)
                    .HasComment("Last Notification")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_notification");
                entity.Property(e => e.Name)
                    .HasComment("Name")
                    .HasColumnType("character varying")
                    .HasColumnName("name");
                entity.Property(e => e.NotifyFrequency)
                    .HasComment("Notify")
                    .HasColumnName("notify_frequency");
                entity.Property(e => e.NotifyFrequencyPeriod)
                    .HasComment("Notify Frequency Period")
                    .HasColumnType("character varying")
                    .HasColumnName("notify_frequency_period");
                entity.Property(e => e.RecycleAction)
                    .HasComment("Recycle Action")
                    .HasColumnType("character varying")
                    .HasColumnName("recycle_action");
                entity.Property(e => e.RecycleMode)
                    .HasComment("Recycle Mode")
                    .HasColumnType("character varying")
                    .HasColumnName("recycle_mode");
                entity.Property(e => e.ResModelId)
                    .HasComment("Model")
                    .HasColumnName("res_model_id");
                entity.Property(e => e.ResModelName)
                    .HasComment("Model Name")
                    .HasColumnType("character varying")
                    .HasColumnName("res_model_name");
                entity.Property(e => e.TimeFieldDelta)
                    .HasComment("Delta")
                    .HasColumnName("time_field_delta");
                entity.Property(e => e.TimeFieldDeltaUnit)
                    .HasComment("Delta Unit")
                    .HasColumnType("character varying")
                    .HasColumnName("time_field_delta_unit");
                entity.Property(e => e.TimeFieldId)
                    .HasComment("Time Field")
                    .HasColumnName("time_field_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("data_recycle_model_create_uid_fkey");

                entity.HasOne(d => d.ResModel).WithMany(p => p.DataRecycleModels)
                    .HasForeignKey(d => d.ResModelId)
                    .HasConstraintName("data_recycle_model_res_model_id_fkey");

                entity.HasOne(d => d.TimeField).WithMany(p => p.DataRecycleModels)
                    .HasForeignKey(d => d.TimeFieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("data_recycle_model_time_field_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("data_recycle_model_write_uid_fkey");

                //entity.HasMany(d => d.ResUsers).WithMany(p => p.DataRecycleModels)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "DataRecycleModelResUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("ResUsersId")
                            .HasConstraintName("data_recycle_model_res_users_rel_res_users_id_fkey"),
                        l => l.HasOne<DataRecycleModel>().WithMany()
                            .HasForeignKey("DataRecycleModelId")
                            .HasConstraintName("data_recycle_model_res_users_rel_data_recycle_model_id_fkey"),
                        j =>
                        {
                            j.HasKey("DataRecycleModelId", "ResUsersId").HasName("data_recycle_model_res_users_rel_pkey");
                            j.ToTable("data_recycle_model_res_users_rel", tb => tb.HasComment("RELATION BETWEEN data_recycle_model AND res_users"));
                            j.HasIndex(new[] { "ResUsersId", "DataRecycleModelId" }, "data_recycle_model_res_users__res_users_id_data_recycle_mod_idx");
                            j.IndexerProperty<Guid>("DataRecycleModelId").HasColumnName("data_recycle_model_id");
                            j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                        });
            });
        }
    }
}