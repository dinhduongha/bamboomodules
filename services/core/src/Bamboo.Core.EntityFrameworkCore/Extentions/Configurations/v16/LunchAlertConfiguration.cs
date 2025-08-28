using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureLunchAlert(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LunchAlert>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("lunch_alert_pkey");

                        entity.ToTable("lunch_alert");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CronId).HasColumnName("cron_id");
                        entity.Property(e => e.Fri).HasColumnName("fri");
                        entity.Property(e => e.Message)
                            .HasColumnType("jsonb")
                            .HasColumnName("message");
                        entity.Property(e => e.Mode).HasColumnName("mode");
                        entity.Property(e => e.Mon).HasColumnName("mon");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.NotificationMoment).HasColumnName("notification_moment");
                        entity.Property(e => e.NotificationTime).HasColumnName("notification_time");
                        entity.Property(e => e.Recipients).HasColumnName("recipients");
                        entity.Property(e => e.Sat).HasColumnName("sat");
                        entity.Property(e => e.Sun).HasColumnName("sun");
                        entity.Property(e => e.Thu).HasColumnName("thu");
                        entity.Property(e => e.Tue).HasColumnName("tue");
                        entity.Property(e => e.Tz).HasColumnName("tz");
                        entity.Property(e => e.Until).HasColumnName("until");
                        entity.Property(e => e.Wed).HasColumnName("wed");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LunchAlertCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lunch_alert_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lunch_alert_create_uid_fkey");

                        entity.HasOne(d => d.Cron).WithMany(p => p.LunchAlert)
                            .HasForeignKey(d => d.CronId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("lunch_alert_cron_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LunchAlertWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lunch_alert_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lunch_alert_write_uid_fkey");

                        // entity.HasMany(d => d.LunchLocation).WithMany(p => p.LunchAlert)
                        entity.HasMany(d => d.LunchLocation).WithMany(p => p.LunchAlert)
                            .UsingEntity<Dictionary<string, object>>(
                                "LunchAlertLunchLocationRel",
                                r => r.HasOne<LunchLocation>().WithMany()
                                    .HasForeignKey("LunchLocationId")
                                    .HasConstraintName("lunch_alert_lunch_location_rel_lunch_location_id_fkey"),
                                l => l.HasOne<LunchAlert>().WithMany()
                                    .HasForeignKey("LunchAlertId")
                                    .HasConstraintName("lunch_alert_lunch_location_rel_lunch_alert_id_fkey"),
                                j =>
                                {
                                    j.HasKey("LunchAlertId", "LunchLocationId").HasName("lunch_alert_lunch_location_rel_pkey");
                                    j.ToTable("lunch_alert_lunch_location_rel");
                                    j.HasIndex(new[] { "LunchLocationId", "LunchAlertId" }, "lunch_alert_lunch_location_re_lunch_location_id_lunch_alert_idx");
                                    j.IndexerProperty<Guid>("LunchAlertId").HasColumnName("lunch_alert_id");
                                    j.IndexerProperty<Guid>("LunchLocationId").HasColumnName("lunch_location_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}