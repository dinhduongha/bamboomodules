using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrDepartureWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrDepartureWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_departure_wizard_pkey");

                        entity.ToTable("hr_departure_wizard");

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
                        entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
                        entity.Property(e => e.DepartureDescription).HasColumnName("departure_description");
                        entity.Property(e => e.DepartureReasonId).HasColumnName("departure_reason_id");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.ReleaseCampanyCar).HasColumnName("release_campany_car");
                        entity.Property(e => e.SetDateEnd).HasColumnName("set_date_end");
                        entity.Property(e => e.UnassignEquipment).HasColumnName("unassign_equipment");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrDepartureWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_departure_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_departure_wizard_create_uid_fkey");

                        entity.HasOne(d => d.DepartureReason).WithMany(p => p.HrDepartureWizard)
                            .HasForeignKey(d => d.DepartureReasonId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_departure_wizard_departure_reason_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrDepartureWizard)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_departure_wizard_employee_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrDepartureWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_departure_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_departure_wizard_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}