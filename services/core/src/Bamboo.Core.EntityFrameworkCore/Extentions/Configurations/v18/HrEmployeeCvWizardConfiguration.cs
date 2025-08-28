using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrEmployeeCvWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrEmployeeCvWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_employee_cv_wizard_pkey");

                        entity.ToTable("hr_employee_cv_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ColorPrimary).HasColumnName("color_primary");
                        entity.Property(e => e.ColorSecondary).HasColumnName("color_secondary");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ShowContact).HasColumnName("show_contact");
                        entity.Property(e => e.ShowOthers).HasColumnName("show_others");
                        entity.Property(e => e.ShowSkills).HasColumnName("show_skills");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrEmployeeCvWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_cv_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_cv_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrEmployeeCvWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_cv_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_cv_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrEmployeeCvWizard)
                        entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrEmployeeCvWizard)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrEmployeeHrEmployeeCvWizardRel",
                                r => r.HasOne<HrEmployee>().WithMany()
                                    .HasForeignKey("HrEmployeeId")
                                    .HasConstraintName("hr_employee_hr_employee_cv_wizard_rel_hr_employee_id_fkey"),
                                l => l.HasOne<HrEmployeeCvWizard>().WithMany()
                                    .HasForeignKey("HrEmployeeCvWizardId")
                                    .HasConstraintName("hr_employee_hr_employee_cv_wizard_hr_employee_cv_wizard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrEmployeeCvWizardId", "HrEmployeeId").HasName("hr_employee_hr_employee_cv_wizard_rel_pkey");
                                    j.ToTable("hr_employee_hr_employee_cv_wizard_rel");
                                    j.HasIndex(new[] { "HrEmployeeId", "HrEmployeeCvWizardId" }, "hr_employee_hr_employee_cv_wi_hr_employee_id_hr_employee_cv_idx");
                                    j.IndexerProperty<Guid>("HrEmployeeCvWizardId").HasColumnName("hr_employee_cv_wizard_id");
                                    j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}