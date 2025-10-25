using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrPayslipInput(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrPayslipInput>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_payslip_input_pkey");

                        entity.ToTable("hr_payslip_input");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.PayslipId, "hr_payslip_input__payslip_id_index");

                        entity.HasIndex(e => e.Sequence, "hr_payslip_input__sequence_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.ContractId).HasColumnName("contract_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PayslipId).HasColumnName("payslip_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Contract).WithMany(p => p.HrPayslipInput)
                            .HasForeignKey(d => d.ContractId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_payslip_input_contract_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrPayslipInputCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_payslip_input_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_input_create_uid_fkey");

                        entity.HasOne(d => d.Payslip).WithMany(p => p.HrPayslipInput)
                            .HasForeignKey(d => d.PayslipId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_payslip_input_payslip_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrPayslipInputWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_payslip_input_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_input_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}