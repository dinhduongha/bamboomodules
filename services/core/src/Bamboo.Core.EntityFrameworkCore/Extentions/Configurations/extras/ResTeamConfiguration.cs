using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResTeam(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResTeam>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_team_pkey");

                entity.ToTable("res_team");

                entity.HasIndex(e => e.TenantId);
                entity.HasIndex(e => e.OrganizationUnitId);
                entity.HasIndex(e => e.OrganizationId);
                entity.HasIndex(e => e.SupervisorId);
                entity.HasIndex(e => e.TeamCode).IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("uuidv7()")
                    .HasColumnName("id");

                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
                entity.Property(e => e.TeamCode).HasColumnName("team_code");
                entity.Property(e => e.TeamName).HasColumnName("team_name");
                entity.Property(e => e.SupervisorId).HasColumnName("supervisor_id");
                entity.Property(e => e.TargetSalesAmount).HasColumnName("target_sales_amount");
                entity.Property(e => e.TargetVisitCount).HasColumnName("target_visit_count");
                entity.Property(e => e.TargetCoveragePercent).HasColumnName("target_coverage_percent");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreatorId).HasColumnName("create_uid");

                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");

                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Organization)
                    .WithMany(o => o.Teams)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_team_organization_id_fkey");

                entity.HasOne(d => d.Supervisor)
                    .WithMany()
                    .HasForeignKey(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_team_supervisor_id_fkey");

                // entity.HasMany<ResUsers>().WithMany()
                //     .UsingEntity<Dictionary<string, object>>(
                //         "ResTeamUsersRel",
                //         r => r.HasOne<ResUsers>().WithMany()
                //             .HasForeignKey("UserId")
                //             .HasConstraintName("res_team_users_rel_user_id_fkey"),
                //         l => l.HasOne<ResTeam>().WithMany()
                //             .HasForeignKey("TeamId")
                //             .HasConstraintName("res_team_users_rel_ouid_fkey"),
                //         j =>
                //         {
                //             j.HasKey("TeamId", "UserId").HasName("res_team_users_rel_pkey");
                //             j.ToTable("res_team_users_rel");
                //             j.HasIndex(new[] { "UserId", "TeamId" }, "res_team_users_rel_user_id_ouid_idx");
                //             j.IndexerProperty<Guid>("TeamId").HasColumnName("team_id");
                //             j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                //         });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}
