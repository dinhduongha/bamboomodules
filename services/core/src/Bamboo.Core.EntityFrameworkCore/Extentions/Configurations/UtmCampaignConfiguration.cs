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
        public static void ConfigureUtmCampaign(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UtmCampaign>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("utm_campaign_pkey");

                entity.ToTable("utm_campaign");

                entity.HasIndex(e => e.Name, "utm_campaign_unique_name").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.IsAutoCampaign).HasColumnName("is_auto_campaign");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.StageId).HasColumnName("stage_id");
                entity.Property(e => e.Title)
                    .HasColumnType("jsonb")
                    .HasColumnName("title");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("utm_campaign_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("utm_campaign_create_uid_fkey");

                entity.HasOne(d => d.Stage).WithMany(p => p.UtmCampaigns)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("utm_campaign_stage_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("utm_campaign_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("utm_campaign_write_uid_fkey");

                //entity.HasMany(d => d.Campaigns).WithMany(p => p.Tags)
                entity.HasMany<UtmTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "UtmTagRel",
                        r => r.HasOne<UtmTag>().WithMany()
                            .HasForeignKey("CampaignId")
                            .HasConstraintName("utm_tag_rel_campaign_id_fkey"),
                        l => l.HasOne<UtmCampaign>().WithMany()
                            .HasForeignKey("TagId")
                            .HasConstraintName("utm_tag_rel_tag_id_fkey"),
                        j =>
                        {
                            j.HasKey("TagId", "CampaignId").HasName("utm_tag_rel_pkey");
                            j.ToTable("utm_tag_rel");
                            j.HasIndex(new[] { "CampaignId", "TagId" }, "utm_tag_rel_campaign_id_tag_id_idx");
                        });
            });
        }
    }
}