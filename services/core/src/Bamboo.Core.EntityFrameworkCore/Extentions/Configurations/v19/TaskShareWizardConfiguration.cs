using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureTaskShareWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<TaskShareWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("task_share_wizard_pkey");

                        entity.ToTable("task_share_wizard");

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
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.ResModel).HasColumnName("res_model");
                        entity.Property(e => e.TaskId).HasColumnName("task_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.TaskShareWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("task_share_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("task_share_wizard_create_uid_fkey");

                        entity.HasOne(d => d.Task).WithMany(p => p.TaskShareWizard)
                            .HasForeignKey(d => d.TaskId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("task_share_wizard_task_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.TaskShareWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("task_share_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("task_share_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.TaskShareWizard)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ResPartnerTaskShareWizardRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("res_partner_task_share_wizard_rel_res_partner_id_fkey"),
                                l => l.HasOne<TaskShareWizard>().WithMany()
                                    .HasForeignKey("TaskShareWizardId")
                                    .HasConstraintName("res_partner_task_share_wizard_rel_task_share_wizard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("TaskShareWizardId", "ResPartnerId").HasName("res_partner_task_share_wizard_rel_pkey");
                                    j.ToTable("res_partner_task_share_wizard_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "TaskShareWizardId" }, "res_partner_task_share_wizard_res_partner_id_task_share_wiz_idx");
                                    j.IndexerProperty<Guid>("TaskShareWizardId").HasColumnName("task_share_wizard_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}