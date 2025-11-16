using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectProject(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectProject>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_project_pkey");

                        entity.ToTable("project_project");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AccountId, "project_project__account_id_index");

                        entity.HasIndex(e => e.Date, "project_project__date_index");

                        entity.HasIndex(e => e.PartnerId, "project_project__partner_id_index").HasFilter("(partner_id IS NOT NULL)");

                        entity.HasIndex(e => e.SaleLineId, "project_project__sale_line_id_index").HasFilter("(sale_line_id IS NOT NULL)");

                        entity.HasIndex(e => e.StageId, "project_project__stage_id_index");

                        entity.HasIndex(e => e.XPlan2Id, "project_project__x_plan2_id_index").HasFilter("(x_plan2_id IS NOT NULL)");

                        entity.HasIndex(e => e.XPlan3Id, "project_project__x_plan3_id_index").HasFilter("(x_plan3_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.AccountId).HasColumnName("account_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AliasId).HasColumnName("alias_id");
                        entity.Property(e => e.AllocatedHours).HasColumnName("allocated_hours");
                        entity.Property(e => e.AllowBillable).HasColumnName("allow_billable");
                        entity.Property(e => e.AllowMilestones).HasColumnName("allow_milestones");
                        entity.Property(e => e.AllowRecurringTasks).HasColumnName("allow_recurring_tasks");
                        entity.Property(e => e.AllowTaskDependencies).HasColumnName("allow_task_dependencies");
                        entity.Property(e => e.AllowTimesheets).HasColumnName("allow_timesheets");
                        entity.Property(e => e.BillingType).HasColumnName("billing_type");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.DateStart).HasColumnName("date_start");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.IsTemplate).HasColumnName("is_template");
                        entity.Property(e => e.LabelTasks)
                            .HasColumnType("jsonb")
                            .HasColumnName("label_tasks");
                        entity.Property(e => e.LastUpdateId).HasColumnName("last_update_id");
                        entity.Property(e => e.LastUpdateStatus).HasColumnName("last_update_status");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PrivacyVisibility).HasColumnName("privacy_visibility");
                        entity.Property(e => e.ReinvoicedSaleOrderId).HasColumnName("reinvoiced_sale_order_id");
                        entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.StageId).HasColumnName("stage_id");
                        entity.Property(e => e.TaskPropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("task_properties_definition");
                        entity.Property(e => e.TimesheetProductId).HasColumnName("timesheet_product_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.XPlan2Id).HasColumnName("x_plan2_id");
                        entity.Property(e => e.XPlan3Id).HasColumnName("x_plan3_id");

                        // entity.HasOne(d => d.Account).WithMany(p => p.ProjectProjectAccount) .HasForeignKey(d => d.AccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_account_id_fkey");
                        entity.HasOne(d => d.Account).WithMany()
                            .HasForeignKey(d => d.AccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_account_id_fkey");

                        entity.HasOne(d => d.Alias).WithMany(p => p.ProjectProject)
                            .HasForeignKey(d => d.AliasId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_project_alias_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ProjectProject) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectProjectCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_create_uid_fkey");

                        entity.HasOne(d => d.LastUpdate).WithMany(p => p.ProjectProject)
                            .HasForeignKey(d => d.LastUpdateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_last_update_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.ProjectProject) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_partner_id_fkey");

                        entity.HasOne(d => d.ReinvoicedSaleOrder).WithMany(p => p.ProjectProject)
                            .HasForeignKey(d => d.ReinvoicedSaleOrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_reinvoiced_sale_order_id_fkey");

                        entity.HasOne(d => d.SaleLine).WithMany(p => p.ProjectProject)
                            .HasForeignKey(d => d.SaleLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_sale_line_id_fkey");

                        entity.HasOne(d => d.Stage).WithMany(p => p.ProjectProject)
                            .HasForeignKey(d => d.StageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_project_stage_id_fkey");

                        // entity.HasOne(d => d.TimesheetProduct).WithMany(p => p.ProjectProject) .HasForeignKey(d => d.TimesheetProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_timesheet_product_id_fkey");
                        entity.HasOne(d => d.TimesheetProduct).WithMany()
                            .HasForeignKey(d => d.TimesheetProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_timesheet_product_id_fkey");

                        // entity.HasOne(d => d.UserNavigation).WithMany(p => p.ProjectProjectUserNavigation) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_user_id_fkey");
                        entity.HasOne(d => d.UserNavigation).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectProjectWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_write_uid_fkey");

                        entity.HasOne(d => d.XPlan2).WithMany(p => p.ProjectProjectXPlan2)
                            .HasForeignKey(d => d.XPlan2Id)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_project_x_plan2_id_fkey");

                        entity.HasOne(d => d.XPlan3).WithMany(p => p.ProjectProjectXPlan3)
                            .HasForeignKey(d => d.XPlan3Id)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_project_x_plan3_id_fkey");

                        // entity.HasMany(d => d.ProjectTags).WithMany(p => p.ProjectProject)
                        entity.HasMany(d => d.ProjectTags).WithMany(p => p.ProjectProject)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectProjectProjectTagsRel",
                                r => r.HasOne<ProjectTags>().WithMany()
                                    .HasForeignKey("ProjectTagsId")
                                    .HasConstraintName("project_project_project_tags_rel_project_tags_id_fkey"),
                                l => l.HasOne<ProjectProject>().WithMany()
                                    .HasForeignKey("ProjectProjectId")
                                    .HasConstraintName("project_project_project_tags_rel_project_project_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectProjectId", "ProjectTagsId").HasName("project_project_project_tags_rel_pkey");
                                    j.ToTable("project_project_project_tags_rel");
                                    j.HasIndex(new[] { "ProjectTagsId", "ProjectProjectId" }, "project_project_project_tags__project_tags_id_project_proje_idx");
                                    j.IndexerProperty<Guid>("ProjectProjectId").HasColumnName("project_project_id");
                                    j.IndexerProperty<Guid>("ProjectTagsId").HasColumnName("project_tags_id");
                                });

                        // entity.HasMany(d => d.Type).WithMany(p => p.Project)
                        entity.HasMany(d => d.Type).WithMany(p => p.Project)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectTaskTypeRel",
                                r => r.HasOne<ProjectTaskType>().WithMany()
                                    .HasForeignKey("TypeId")
                                    .HasConstraintName("project_task_type_rel_type_id_fkey"),
                                l => l.HasOne<ProjectProject>().WithMany()
                                    .HasForeignKey("ProjectId")
                                    .HasConstraintName("project_task_type_rel_project_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectId", "TypeId").HasName("project_task_type_rel_pkey");
                                    j.ToTable("project_task_type_rel");
                                    j.HasIndex(new[] { "TypeId", "ProjectId" }, "project_task_type_rel_type_id_project_id_idx");
                                    j.IndexerProperty<Guid>("ProjectId").HasColumnName("project_id");
                                    j.IndexerProperty<Guid>("TypeId").HasColumnName("type_id");
                                });

                        // entity.HasMany(d => d.User).WithMany(p => p.Project)
                        entity.HasMany(d => d.User).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectFavoriteUserRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("UserId")
                                    .HasConstraintName("project_favorite_user_rel_user_id_fkey"),
                                l => l.HasOne<ProjectProject>().WithMany()
                                    .HasForeignKey("ProjectId")
                                    .HasConstraintName("project_favorite_user_rel_project_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectId", "UserId").HasName("project_favorite_user_rel_pkey");
                                    j.ToTable("project_favorite_user_rel");
                                    j.HasIndex(new[] { "UserId", "ProjectId" }, "project_favorite_user_rel_user_id_project_id_idx");
                                    j.IndexerProperty<Guid>("ProjectId").HasColumnName("project_id");
                                    j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}