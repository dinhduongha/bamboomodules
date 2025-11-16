using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrBankAccountAllocationWizardLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrBankAccountAllocationWizardLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_bank_account_allocation_wizard_line_pkey");

                        entity.ToTable("hr_bank_account_allocation_wizard_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.AmountType).HasColumnName("amount_type");
                        entity.Property(e => e.BankAccountId).HasColumnName("bank_account_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Trusted).HasColumnName("trusted");
                        entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.BankAccount).WithMany(p => p.HrBankAccountAllocationWizardLine)
                            .HasForeignKey(d => d.BankAccountId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_bank_account_allocation_wizard_line_bank_account_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrBankAccountAllocationWizardLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_bank_account_allocation_wizard_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_bank_account_allocation_wizard_line_create_uid_fkey");

                        entity.HasOne(d => d.Wizard).WithMany(p => p.HrBankAccountAllocationWizardLine)
                            .HasForeignKey(d => d.WizardId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_bank_account_allocation_wizard_line_wizard_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrBankAccountAllocationWizardLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_bank_account_allocation_wizard_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_bank_account_allocation_wizard_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}