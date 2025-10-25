using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrPayrollStructure(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrPayrollStructure>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_payroll_structure_pkey");

                        entity.ToTable("hr_payroll_structure");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Code).HasColumnName("code");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrPayrollStructure) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_payroll_structure_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_payroll_structure_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrPayrollStructureCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_payroll_structure_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payroll_structure_create_uid_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payroll_structure_parent_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrPayrollStructureWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_payroll_structure_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payroll_structure_write_uid_fkey");

                        // entity.HasMany(d => d.Rule).WithMany(p => p.Struct)
                        entity.HasMany(d => d.Rule).WithMany(p => p.Struct)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrStructureSalaryRuleRel",
                                r => r.HasOne<HrSalaryRule>().WithMany()
                                    .HasForeignKey("RuleId")
                                    .HasConstraintName("hr_structure_salary_rule_rel_rule_id_fkey"),
                                l => l.HasOne<HrPayrollStructure>().WithMany()
                                    .HasForeignKey("StructId")
                                    .HasConstraintName("hr_structure_salary_rule_rel_struct_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StructId", "RuleId").HasName("hr_structure_salary_rule_rel_pkey");
                                    j.ToTable("hr_structure_salary_rule_rel");
                                    j.HasIndex(new[] { "RuleId", "StructId" }, "hr_structure_salary_rule_rel_rule_id_struct_id_idx");
                                    j.IndexerProperty<Guid>("StructId").HasColumnName("struct_id");
                                    j.IndexerProperty<Guid>("RuleId").HasColumnName("rule_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}