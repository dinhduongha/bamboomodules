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
        public static void ConfigureMaintenanceTeam(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaintenanceTeam>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("maintenance_team_pkey");

                entity.ToTable("maintenance_team");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_team_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_team_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_team_write_uid_fkey");

                //entity.HasMany(d => d.ResUsers).WithMany(p => p.MaintenanceTeams)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MaintenanceTeamUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
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
                        });
            });
        }
    }
}