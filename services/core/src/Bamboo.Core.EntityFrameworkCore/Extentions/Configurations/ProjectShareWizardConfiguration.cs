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
        public static void ConfigureProjectShareWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectShareWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("project_share_wizard_pkey");

                entity.ToTable("project_share_wizard");

                entity.HasIndex(e => e.TenantId, "project_share_wizard_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessMode).HasColumnName("access_mode");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DisplayAccessMode).HasColumnName("display_access_mode");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.ResId).HasColumnName("res_id");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_share_wizard_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_share_wizard_write_uid_fkey");

                //entity.HasMany(d => d.ResPartners).WithMany(p => p.ProjectShareWizards)
                entity.HasMany<ResPartner>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectShareWizardResPartnerRel",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("ResPartnerId")
                            .HasConstraintName("project_share_wizard_res_partner_rel_res_partner_id_fkey"),
                        l => l.HasOne<ProjectShareWizard>().WithMany()
                            .HasForeignKey("ProjectShareWizardId")
                            .HasConstraintName("project_share_wizard_res_partner_r_project_share_wizard_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProjectShareWizardId", "ResPartnerId").HasName("project_share_wizard_res_partner_rel_pkey");
                            j.ToTable("project_share_wizard_res_partner_rel");
                            j.HasIndex(new[] { "ResPartnerId", "ProjectShareWizardId" }, "project_share_wizard_res_part_res_partner_id_project_share__idx");
                        });
            });
        }
    }
}