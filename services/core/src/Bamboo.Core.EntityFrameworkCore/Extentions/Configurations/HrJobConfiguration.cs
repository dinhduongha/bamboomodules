using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
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

                entity.HasIndex(e => e.IsPublished, "hr_job_is_published_index");

                entity.HasIndex(e => new { e.TenantId, e.Name, e.DepartmentId }, "hr_job_name_company_uniq").IsUnique();

                entity.HasIndex(e => e.WebsiteId, "hr_job_website_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.AliasId).HasColumnName("alias_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ContractTypeId).HasColumnName("contract_type_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.ExpectedEmployees).HasColumnName("expected_employees");
                entity.Property(e => e.HrResponsibleId).HasColumnName("hr_responsible_id");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.JobDetails)
                    .HasColumnType("jsonb")
                    .HasColumnName("job_details");
                entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.NoOfEmployee).HasColumnName("no_of_employee");
                entity.Property(e => e.NoOfHiredEmployee).HasColumnName("no_of_hired_employee");
                entity.Property(e => e.NoOfRecruitment).HasColumnName("no_of_recruitment");
                entity.Property(e => e.Requirements).HasColumnName("requirements");
                entity.Property(e => e.SeoName)
                    .HasColumnType("jsonb")
                    .HasColumnName("seo_name");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
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

                entity.HasOne(d => d.Address).WithMany(p => p.HrJobs)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_address_id_fkey");

                entity.HasOne(d => d.Alias).WithMany(p => p.HrJobs)
                    .HasForeignKey(d => d.AliasId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_job_alias_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_company_id_fkey");

                entity.HasOne(d => d.ContractType).WithMany(p => p.HrJobs)
                    .HasForeignKey(d => d.ContractTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_contract_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_create_uid_fkey");

                entity.HasOne(d => d.Department).WithMany(p => p.HrJobs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_department_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.HrResponsibleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_hr_responsible_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_manager_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrJobs)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_user_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.HrJobs)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_job_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_write_uid_fkey");

                entity.HasMany(d => d.HrSkills).WithMany(p => p.HrJobs)
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

                //entity.HasMany(d => d.ResUsers).WithMany(p => p.HrJobs)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HrJobExtendedInterviewerResUser",
                        r => r.HasOne<ResUser>().WithMany()
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
                        });

                /// TODO:
                //entity.HasMany(d => d.ResUsersNavigation).WithMany(p => p.HrJobsNavigation)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HrJobResUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
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
                        });
                /// TODO:
                //entity.HasMany(d => d.Users).WithMany(p => p.Jobs)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "JobFavoriteUserRel",
                        r => r.HasOne<ResUser>().WithMany()
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
                        });
            });
        }
    }
}