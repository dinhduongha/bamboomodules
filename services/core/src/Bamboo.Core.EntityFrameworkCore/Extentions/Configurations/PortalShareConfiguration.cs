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
        public static void ConfigurePortalShare(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortalShare>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("portal_share_pkey");

                entity.ToTable("portal_share");

                entity.HasIndex(e => e.TenantId, "portal_share_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
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
                    .HasConstraintName("portal_share_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("portal_share_write_uid_fkey");

                //entity.HasMany(d => d.ResPartners).WithMany(p => p.PortalShares)
                entity.HasMany<ResPartner>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PortalShareResPartnerRel",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("ResPartnerId")
                            .HasConstraintName("portal_share_res_partner_rel_res_partner_id_fkey"),
                        l => l.HasOne<PortalShare>().WithMany()
                            .HasForeignKey("PortalShareId")
                            .HasConstraintName("portal_share_res_partner_rel_portal_share_id_fkey"),
                        j =>
                        {
                            j.HasKey("PortalShareId", "ResPartnerId").HasName("portal_share_res_partner_rel_pkey");
                            j.ToTable("portal_share_res_partner_rel");
                            j.HasIndex(new[] { "ResPartnerId", "PortalShareId" }, "portal_share_res_partner_rel_res_partner_id_portal_share_id_idx");
                        });
            });
        }
    }
}