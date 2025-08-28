using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMaintenanceTeam(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MaintenanceTeam>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("maintenance_team_pkey");

                        entity.ToTable("maintenance_team");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.MaintenanceTeam) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_team_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_team_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MaintenanceTeamCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_team_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_team_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MaintenanceTeamWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_team_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_team_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.MaintenanceTeam)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MaintenanceTeamUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("maintenance_team_users_rel_res_users_id_fkey"),
                                l => l.HasOne<MaintenanceTeam>().WithMany()
                                    .HasForeignKey("MaintenanceTeamId")
                                    .HasConstraintName("maintenance_team_users_rel_maintenance_team_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MaintenanceTeamId", "ResUsersId").HasName("maintenance_team_users_rel_pkey");
                                    j.ToTable("maintenance_team_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "MaintenanceTeamId" }, "maintenance_team_users_rel_res_users_id_maintenance_team_id_idx");
                                    j.IndexerProperty<Guid>("MaintenanceTeamId").HasColumnName("maintenance_team_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}