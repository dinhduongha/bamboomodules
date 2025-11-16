using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrTalentPool(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrTalentPool>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_talent_pool_pkey");

                        entity.ToTable("hr_talent_pool");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PoolManager).HasColumnName("pool_manager");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrTalentPool) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_talent_pool_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_talent_pool_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrTalentPoolCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_talent_pool_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_talent_pool_create_uid_fkey");

                        // entity.HasOne(d => d.PoolManagerNavigation).WithMany(p => p.HrTalentPoolPoolManagerNavigation) .HasForeignKey(d => d.PoolManager) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_talent_pool_pool_manager_fkey");
                        entity.HasOne(d => d.PoolManagerNavigation).WithMany()
                            .HasForeignKey(d => d.PoolManager)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_talent_pool_pool_manager_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrTalentPoolWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_talent_pool_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_talent_pool_write_uid_fkey");

                        // entity.HasMany(d => d.HrApplicantCategory).WithMany(p => p.HrTalentPool)
                        entity.HasMany(d => d.HrApplicantCategory).WithMany(p => p.HrTalentPool)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrApplicantCategoryHrTalentPoolRel",
                                r => r.HasOne<HrApplicantCategory>().WithMany()
                                    .HasForeignKey("HrApplicantCategoryId")
                                    .HasConstraintName("hr_applicant_category_hr_talent_p_hr_applicant_category_id_fkey"),
                                l => l.HasOne<HrTalentPool>().WithMany()
                                    .HasForeignKey("HrTalentPoolId")
                                    .HasConstraintName("hr_applicant_category_hr_talent_pool_rel_hr_talent_pool_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrTalentPoolId", "HrApplicantCategoryId").HasName("hr_applicant_category_hr_talent_pool_rel_pkey");
                                    j.ToTable("hr_applicant_category_hr_talent_pool_rel");
                                    j.HasIndex(new[] { "HrApplicantCategoryId", "HrTalentPoolId" }, "hr_applicant_category_hr_tale_hr_applicant_category_id_hr_t_idx");
                                    j.IndexerProperty<Guid>("HrTalentPoolId").HasColumnName("hr_talent_pool_id");
                                    j.IndexerProperty<Guid>("HrApplicantCategoryId").HasColumnName("hr_applicant_category_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}