using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureTalentPoolAddApplicants(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<TalentPoolAddApplicants>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("talent_pool_add_applicants_pkey");

                        entity.ToTable("talent_pool_add_applicants");

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
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.TalentPoolAddApplicantsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("talent_pool_add_applicants_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("talent_pool_add_applicants_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.TalentPoolAddApplicantsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("talent_pool_add_applicants_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("talent_pool_add_applicants_write_uid_fkey");

                        // entity.HasMany(d => d.HrApplicant).WithMany(p => p.TalentPoolAddApplicants)
                        entity.HasMany(d => d.HrApplicant).WithMany(p => p.TalentPoolAddApplicants)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrApplicantTalentPoolAddApplicantsRel",
                                r => r.HasOne<HrApplicant>().WithMany()
                                    .HasForeignKey("HrApplicantId")
                                    .HasConstraintName("hr_applicant_talent_pool_add_applicants_re_hr_applicant_id_fkey"),
                                l => l.HasOne<TalentPoolAddApplicants>().WithMany()
                                    .HasForeignKey("TalentPoolAddApplicantsId")
                                    .HasConstraintName("hr_applicant_talent_pool_add__talent_pool_add_applicants_i_fkey"),
                                j =>
                                {
                                    j.HasKey("TalentPoolAddApplicantsId", "HrApplicantId").HasName("hr_applicant_talent_pool_add_applicants_rel_pkey");
                                    j.ToTable("hr_applicant_talent_pool_add_applicants_rel");
                                    j.HasIndex(new[] { "HrApplicantId", "TalentPoolAddApplicantsId" }, "hr_applicant_talent_pool_add__hr_applicant_id_talent_pool_a_idx");
                                    j.IndexerProperty<Guid>("TalentPoolAddApplicantsId").HasColumnName("talent_pool_add_applicants_id");
                                    j.IndexerProperty<Guid>("HrApplicantId").HasColumnName("hr_applicant_id");
                                });

                        // entity.HasMany(d => d.HrApplicantCategory).WithMany(p => p.TalentPoolAddApplicants)
                        entity.HasMany(d => d.HrApplicantCategory).WithMany(p => p.TalentPoolAddApplicants)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrApplicantCategoryTalentPoolAddApplicantsRel",
                                r => r.HasOne<HrApplicantCategory>().WithMany()
                                    .HasForeignKey("HrApplicantCategoryId")
                                    .HasConstraintName("hr_applicant_category_talent_pool_hr_applicant_category_id_fkey"),
                                l => l.HasOne<TalentPoolAddApplicants>().WithMany()
                                    .HasForeignKey("TalentPoolAddApplicantsId")
                                    .HasConstraintName("hr_applicant_category_talent__talent_pool_add_applicants_i_fkey"),
                                j =>
                                {
                                    j.HasKey("TalentPoolAddApplicantsId", "HrApplicantCategoryId").HasName("hr_applicant_category_talent_pool_add_applicants_rel_pkey");
                                    j.ToTable("hr_applicant_category_talent_pool_add_applicants_rel");
                                    j.HasIndex(new[] { "HrApplicantCategoryId", "TalentPoolAddApplicantsId" }, "hr_applicant_category_talent__hr_applicant_category_id_tale_idx");
                                    j.IndexerProperty<Guid>("TalentPoolAddApplicantsId").HasColumnName("talent_pool_add_applicants_id");
                                    j.IndexerProperty<Guid>("HrApplicantCategoryId").HasColumnName("hr_applicant_category_id");
                                });

                        // entity.HasMany(d => d.HrTalentPool).WithMany(p => p.TalentPoolAddApplicants)
                        entity.HasMany(d => d.HrTalentPool).WithMany(p => p.TalentPoolAddApplicants)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrTalentPoolTalentPoolAddApplicantsRel",
                                r => r.HasOne<HrTalentPool>().WithMany()
                                    .HasForeignKey("HrTalentPoolId")
                                    .HasConstraintName("hr_talent_pool_talent_pool_add_applicant_hr_talent_pool_id_fkey"),
                                l => l.HasOne<TalentPoolAddApplicants>().WithMany()
                                    .HasForeignKey("TalentPoolAddApplicantsId")
                                    .HasConstraintName("hr_talent_pool_talent_pool_ad_talent_pool_add_applicants_i_fkey"),
                                j =>
                                {
                                    j.HasKey("TalentPoolAddApplicantsId", "HrTalentPoolId").HasName("hr_talent_pool_talent_pool_add_applicants_rel_pkey");
                                    j.ToTable("hr_talent_pool_talent_pool_add_applicants_rel");
                                    j.HasIndex(new[] { "HrTalentPoolId", "TalentPoolAddApplicantsId" }, "hr_talent_pool_talent_pool_ad_hr_talent_pool_id_talent_pool_idx");
                                    j.IndexerProperty<Guid>("TalentPoolAddApplicantsId").HasColumnName("talent_pool_add_applicants_id");
                                    j.IndexerProperty<Guid>("HrTalentPoolId").HasColumnName("hr_talent_pool_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}