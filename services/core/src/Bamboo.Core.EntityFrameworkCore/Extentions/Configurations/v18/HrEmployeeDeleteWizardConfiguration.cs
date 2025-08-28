using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrEmployeeDeleteWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrEmployeeDeleteWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_employee_delete_wizard_pkey");

                        entity.ToTable("hr_employee_delete_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrEmployeeDeleteWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_delete_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_delete_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrEmployeeDeleteWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_delete_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_delete_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrEmployeeDeleteWizard)
                        entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrEmployeeDeleteWizard)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrEmployeeHrEmployeeDeleteWizardRel",
                                r => r.HasOne<HrEmployee>().WithMany()
                                    .HasForeignKey("HrEmployeeId")
                                    .HasConstraintName("hr_employee_hr_employee_delete_wizard_rel_hr_employee_id_fkey"),
                                l => l.HasOne<HrEmployeeDeleteWizard>().WithMany()
                                    .HasForeignKey("HrEmployeeDeleteWizardId")
                                    .HasConstraintName("hr_employee_hr_employee_delet_hr_employee_delete_wizard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrEmployeeDeleteWizardId", "HrEmployeeId").HasName("hr_employee_hr_employee_delete_wizard_rel_pkey");
                                    j.ToTable("hr_employee_hr_employee_delete_wizard_rel");
                                    j.HasIndex(new[] { "HrEmployeeId", "HrEmployeeDeleteWizardId" }, "hr_employee_hr_employee_delet_hr_employee_id_hr_employee_de_idx");
                                    j.IndexerProperty<Guid>("HrEmployeeDeleteWizardId").HasColumnName("hr_employee_delete_wizard_id");
                                    j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}