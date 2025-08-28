using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePosSelfOrderCustomLink(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosSelfOrderCustomLink>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_self_order_custom_link_pkey");

                        entity.ToTable("pos_self_order_custom_link");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LinkHtml).HasColumnName("link_html");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Style).HasColumnName("style");
                        entity.Property(e => e.Url).HasColumnName("url");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PosSelfOrderCustomLinkCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_self_order_custom_link_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_self_order_custom_link_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PosSelfOrderCustomLinkWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_self_order_custom_link_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_self_order_custom_link_write_uid_fkey");

                        // entity.HasMany(d => d.PosConfig).WithMany(p => p.PosSelfOrderCustomLink)
                        entity.HasMany(d => d.PosConfig).WithMany(p => p.PosSelfOrderCustomLink)
                            .UsingEntity<Dictionary<string, object>>(
                                "PosConfigPosSelfOrderCustomLinkRel",
                                r => r.HasOne<PosConfig>().WithMany()
                                    .HasForeignKey("PosConfigId")
                                    .HasConstraintName("pos_config_pos_self_order_custom_link_rel_pos_config_id_fkey"),
                                l => l.HasOne<PosSelfOrderCustomLink>().WithMany()
                                    .HasForeignKey("PosSelfOrderCustomLinkId")
                                    .HasConstraintName("pos_config_pos_self_order_cus_pos_self_order_custom_link_i_fkey"),
                                j =>
                                {
                                    j.HasKey("PosSelfOrderCustomLinkId", "PosConfigId").HasName("pos_config_pos_self_order_custom_link_rel_pkey");
                                    j.ToTable("pos_config_pos_self_order_custom_link_rel");
                                    j.HasIndex(new[] { "PosConfigId", "PosSelfOrderCustomLinkId" }, "pos_config_pos_self_order_cus_pos_config_id_pos_self_order__idx");
                                    j.IndexerProperty<Guid>("PosSelfOrderCustomLinkId").HasColumnName("pos_self_order_custom_link_id");
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}