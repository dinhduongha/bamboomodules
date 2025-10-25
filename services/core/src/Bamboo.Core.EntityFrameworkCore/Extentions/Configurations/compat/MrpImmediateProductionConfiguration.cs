using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpImmediateProduction(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpImmediateProduction>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_immediate_production_pkey");

                        entity.ToTable("mrp_immediate_production");

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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpImmediateProductionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_immediate_production_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_immediate_production_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpImmediateProductionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_immediate_production_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_immediate_production_write_uid_fkey");

                        // entity.HasMany(d => d.MrpProduction).WithMany(p => p.MrpImmediateProduction)
                        entity.HasMany(d => d.MrpProduction).WithMany(p => p.MrpImmediateProduction)
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpProductionProductionRel",
                                r => r.HasOne<MrpProduction>().WithMany()
                                    .HasForeignKey("MrpProductionId")
                                    .HasConstraintName("mrp_production_production_rel_mrp_production_id_fkey"),
                                l => l.HasOne<MrpImmediateProduction>().WithMany()
                                    .HasForeignKey("MrpImmediateProductionId")
                                    .HasConstraintName("mrp_production_production_rel_mrp_immediate_production_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MrpImmediateProductionId", "MrpProductionId").HasName("mrp_production_production_rel_pkey");
                                    j.ToTable("mrp_production_production_rel");
                                    j.HasIndex(new[] { "MrpProductionId", "MrpImmediateProductionId" }, "mrp_production_production_rel_mrp_production_id_mrp_immedia_idx");
                                    j.IndexerProperty<Guid>("MrpImmediateProductionId").HasColumnName("mrp_immediate_production_id");
                                    j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}