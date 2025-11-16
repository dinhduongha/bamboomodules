using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrJob(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrJob>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_job_pkey");

                        entity.ToTable("hr_job");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.DepartmentId, "hr_job__department_id_index").HasFilter("(department_id IS NOT NULL)");

                        entity.HasIndex(e => e.IsPublished, "hr_job__is_published_index");

                        entity.HasIndex(e => e.SurveyId, "hr_job__survey_id_index").HasFilter("(survey_id IS NOT NULL)");

                        entity.HasIndex(e => e.WebsiteId, "hr_job__website_id_index");

                        entity.HasIndex(e => new { e.Name, e.TenantId, e.DepartmentId }, "hr_job_name_company_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AddressId).HasColumnName("address_id");
                        entity.Property(e => e.AliasId).HasColumnName("alias_id");
                        entity.Property(e => e.ApplicantPropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("applicant_properties_definition");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.ContractTypeId).HasColumnName("contract_type_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.ExpectedDegree).HasColumnName("expected_degree");
                        entity.Property(e => e.IndustryId).HasColumnName("industry_id");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.IsSeoOptimized).HasColumnName("is_seo_optimized");
                        entity.Property(e => e.JobDetails)
                            .HasColumnType("jsonb")
                            .HasColumnName("job_details");
                        entity.Property(e => e.JobProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("job_properties");
                        entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.NoOfHiredEmployee).HasColumnName("no_of_hired_employee");
                        entity.Property(e => e.NoOfRecruitment).HasColumnName("no_of_recruitment");
                        entity.Property(e => e.PublishedDate).HasColumnName("published_date");
                        entity.Property(e => e.Requirements).HasColumnName("requirements");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SurveyId).HasColumnName("survey_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.WebsiteDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_description");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.WebsiteMetaDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_description");
                        entity.Property(e => e.WebsiteMetaKeywords)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_keywords");
                        entity.Property(e => e.WebsiteMetaOgImg).HasColumnName("website_meta_og_img");
                        entity.Property(e => e.WebsiteMetaTitle)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_title");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Address).WithMany(p => p.HrJob) .HasForeignKey(d => d.AddressId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_job_address_id_fkey");
                        entity.HasOne(d => d.Address).WithMany()
                            .HasForeignKey(d => d.AddressId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_address_id_fkey");

                        entity.HasOne(d => d.Alias).WithMany(p => p.HrJob)
                            .HasForeignKey(d => d.AliasId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_job_alias_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrJob) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_job_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_company_id_fkey");

                        entity.HasOne(d => d.ContractType).WithMany(p => p.HrJob)
                            .HasForeignKey(d => d.ContractTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_contract_type_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrJobCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_job_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_create_uid_fkey");

                        entity.HasOne(d => d.Department).WithMany(p => p.HrJob)
                            .HasForeignKey(d => d.DepartmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_department_id_fkey");

                        entity.HasOne(d => d.ExpectedDegreeNavigation).WithMany(p => p.HrJob)
                            .HasForeignKey(d => d.ExpectedDegree)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_expected_degree_fkey");

                        entity.HasOne(d => d.Industry).WithMany(p => p.HrJob)
                            .HasForeignKey(d => d.IndustryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_industry_id_fkey");

                        entity.HasOne(d => d.Manager).WithMany(p => p.HrJob)
                            .HasForeignKey(d => d.ManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_manager_id_fkey");

                        entity.HasOne(d => d.Survey).WithMany(p => p.HrJob)
                            .HasForeignKey(d => d.SurveyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_survey_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.HrJobUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_job_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_user_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.HrJob) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_job_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_job_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrJobWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_job_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_write_uid_fkey");

                        // entity.HasMany(d => d.HrSkill).WithMany(p => p.HrJob)
                        entity.HasMany(d => d.HrSkill).WithMany(p => p.HrJob)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrJobHrSkillRel",
                                r => r.HasOne<HrSkill>().WithMany()
                                    .HasForeignKey("HrSkillId")
                                    .HasConstraintName("hr_job_hr_skill_rel_hr_skill_id_fkey"),
                                l => l.HasOne<HrJob>().WithMany()
                                    .HasForeignKey("HrJobId")
                                    .HasConstraintName("hr_job_hr_skill_rel_hr_job_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrJobId", "HrSkillId").HasName("hr_job_hr_skill_rel_pkey");
                                    j.ToTable("hr_job_hr_skill_rel");
                                    j.HasIndex(new[] { "HrSkillId", "HrJobId" }, "hr_job_hr_skill_rel_hr_skill_id_hr_job_id_idx");
                                    j.IndexerProperty<Guid>("HrJobId").HasColumnName("hr_job_id");
                                    j.IndexerProperty<Guid>("HrSkillId").HasColumnName("hr_skill_id");
                                });

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.HrJob)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "HrJobExtendedInterviewerResUsers",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("hr_job_extended_interviewer_res_users_res_users_id_fkey"),
                                l => l.HasOne<HrJob>().WithMany()
                                    .HasForeignKey("HrJobId")
                                    .HasConstraintName("hr_job_extended_interviewer_res_users_hr_job_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrJobId", "ResUsersId").HasName("hr_job_extended_interviewer_res_users_pkey");
                                    j.ToTable("hr_job_extended_interviewer_res_users");
                                    j.HasIndex(new[] { "ResUsersId", "HrJobId" }, "hr_job_extended_interviewer_res_user_res_users_id_hr_job_id_idx");
                                    j.IndexerProperty<Guid>("HrJobId").HasColumnName("hr_job_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                        // entity.HasMany(d => d.ResUsersNavigation).WithMany(p => p.HrJobNavigation)
                        entity.HasMany(d => d.ResUsersNavigation).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "HrJobResUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("hr_job_res_users_rel_res_users_id_fkey"),
                                l => l.HasOne<HrJob>().WithMany()
                                    .HasForeignKey("HrJobId")
                                    .HasConstraintName("hr_job_res_users_rel_hr_job_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrJobId", "ResUsersId").HasName("hr_job_res_users_rel_pkey");
                                    j.ToTable("hr_job_res_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "HrJobId" }, "hr_job_res_users_rel_res_users_id_hr_job_id_idx");
                                    j.IndexerProperty<Guid>("HrJobId").HasColumnName("hr_job_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                        // entity.HasMany(d => d.UserNavigation).WithMany(p => p.Job)
                        entity.HasMany(d => d.UserNavigation).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "JobFavoriteUserRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("UserId")
                                    .HasConstraintName("job_favorite_user_rel_user_id_fkey"),
                                l => l.HasOne<HrJob>().WithMany()
                                    .HasForeignKey("JobId")
                                    .HasConstraintName("job_favorite_user_rel_job_id_fkey"),
                                j =>
                                {
                                    j.HasKey("JobId", "UserId").HasName("job_favorite_user_rel_pkey");
                                    j.ToTable("job_favorite_user_rel");
                                    j.HasIndex(new[] { "UserId", "JobId" }, "job_favorite_user_rel_user_id_job_id_idx");
                                    j.IndexerProperty<Guid>("JobId").HasColumnName("job_id");
                                    j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}