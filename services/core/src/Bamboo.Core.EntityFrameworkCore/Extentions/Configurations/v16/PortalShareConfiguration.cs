using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.ResModel).HasColumnName("res_model");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PortalShareCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("portal_share_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("portal_share_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PortalShareWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("portal_share_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("portal_share_write_uid_fkey");

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.PortalShare)
                        entity.HasMany(d => d.ResPartner).WithMany()
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
                                    j.IndexerProperty<Guid>("PortalShareId").HasColumnName("portal_share_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}