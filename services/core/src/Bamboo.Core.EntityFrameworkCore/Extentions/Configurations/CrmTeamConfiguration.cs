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
        public static void ConfigureCrmTeam(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmTeam>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("crm_team_pkey");

                entity.ToTable("crm_team");

                entity.HasIndex(e => e.TenantId, "crm_team_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AliasId).HasColumnName("alias_id");
                entity.Property(e => e.AssignmentDomain).HasColumnName("assignment_domain");
                entity.Property(e => e.AssignmentOptout).HasColumnName("assignment_optout");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.InvoicedTarget).HasColumnName("invoiced_target");
                entity.Property(e => e.LeadPropertiesDefinition)
                    .HasColumnType("jsonb")
                    .HasColumnName("lead_properties_definition");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.UseLeads).HasColumnName("use_leads");
                entity.Property(e => e.UseOpportunities).HasColumnName("use_opportunities");
                entity.Property(e => e.UseQuotations).HasColumnName("use_quotations");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Alias).WithMany(p => p.CrmTeams)
                    .HasForeignKey(d => d.AliasId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("crm_team_alias_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_team_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_team_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrmTeams)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_team_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_team_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_team_write_uid_fkey");

                //entity.HasMany(d => d.Users).WithMany(p => p.Teams)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "TeamFavoriteUserRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("team_favorite_user_rel_user_id_fkey"),
                        l => l.HasOne<CrmTeam>().WithMany()
                            .HasForeignKey("TeamId")
                            .HasConstraintName("team_favorite_user_rel_team_id_fkey"),
                        j =>
                        {
                            j.HasKey("TeamId", "UserId").HasName("team_favorite_user_rel_pkey");
                            j.ToTable("team_favorite_user_rel");
                            j.HasIndex(new[] { "UserId", "TeamId" }, "team_favorite_user_rel_user_id_team_id_idx");
                        });
            });
        }
    }
}