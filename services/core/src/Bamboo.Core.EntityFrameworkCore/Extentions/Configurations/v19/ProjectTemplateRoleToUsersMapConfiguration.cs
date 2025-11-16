using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectTemplateRoleToUsersMap(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectTemplateRoleToUsersMap>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_template_role_to_users_map_pkey");

                        entity.ToTable("project_template_role_to_users_map");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.RoleId).HasColumnName("role_id");
                        entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectTemplateRoleToUsersMapCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_template_role_to_users_map_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_template_role_to_users_map_create_uid_fkey");

                        entity.HasOne(d => d.Role).WithMany(p => p.ProjectTemplateRoleToUsersMap)
                            .HasForeignKey(d => d.RoleId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("project_template_role_to_users_map_role_id_fkey");

                        entity.HasOne(d => d.Wizard).WithMany(p => p.ProjectTemplateRoleToUsersMap)
                            .HasForeignKey(d => d.WizardId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_template_role_to_users_map_wizard_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectTemplateRoleToUsersMapWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_template_role_to_users_map_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_template_role_to_users_map_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.ProjectTemplateRoleToUsersMap)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectTemplateRoleToUsersMapResUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("project_template_role_to_users_map_res_users__res_users_id_fkey"),
                                l => l.HasOne<ProjectTemplateRoleToUsersMap>().WithMany()
                                    .HasForeignKey("ProjectTemplateRoleToUsersMapId")
                                    .HasConstraintName("project_template_role_to_user_project_template_role_to_use_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectTemplateRoleToUsersMapId", "ResUsersId").HasName("project_template_role_to_users_map_res_users_rel_pkey");
                                    j.ToTable("project_template_role_to_users_map_res_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "ProjectTemplateRoleToUsersMapId" }, "project_template_role_to_user_res_users_id_project_template_idx");
                                    j.IndexerProperty<Guid>("ProjectTemplateRoleToUsersMapId").HasColumnName("project_template_role_to_users_map_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}