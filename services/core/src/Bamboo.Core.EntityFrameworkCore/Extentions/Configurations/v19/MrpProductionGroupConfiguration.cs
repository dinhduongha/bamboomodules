using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpProductionGroup(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpProductionGroup>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_production_group_pkey");

                        entity.ToTable("mrp_production_group");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Name, "mrp_production_group__name_index");

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
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpProductionGroupCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_group_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_group_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpProductionGroupWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_group_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_group_write_uid_fkey");

                        // entity.HasMany(d => d.ChildGroup).WithMany(p => p.ParentGroup)
                        entity.HasMany(d => d.ChildGroup).WithMany(p => p.ParentGroup)
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpProductionGroupRel",
                                r => r.HasOne<MrpProductionGroup>().WithMany()
                                    .HasForeignKey("ChildGroupId")
                                    .HasConstraintName("mrp_production_group_rel_child_group_id_fkey"),
                                l => l.HasOne<MrpProductionGroup>().WithMany()
                                    .HasForeignKey("ParentGroupId")
                                    .HasConstraintName("mrp_production_group_rel_parent_group_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ParentGroupId", "ChildGroupId").HasName("mrp_production_group_rel_pkey");
                                    j.ToTable("mrp_production_group_rel");
                                    j.HasIndex(new[] { "ChildGroupId", "ParentGroupId" }, "mrp_production_group_rel_child_group_id_parent_group_id_idx");
                                    j.IndexerProperty<Guid>("ParentGroupId").HasColumnName("parent_group_id");
                                    j.IndexerProperty<Guid>("ChildGroupId").HasColumnName("child_group_id");
                                });

                        // entity.HasMany(d => d.ParentGroup).WithMany(p => p.ChildGroup)
                        entity.HasMany(d => d.ParentGroup).WithMany(p => p.ChildGroup)
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpProductionGroupRel",
                                r => r.HasOne<MrpProductionGroup>().WithMany()
                                    .HasForeignKey("ParentGroupId")
                                    .HasConstraintName("mrp_production_group_rel_parent_group_id_fkey"),
                                l => l.HasOne<MrpProductionGroup>().WithMany()
                                    .HasForeignKey("ChildGroupId")
                                    .HasConstraintName("mrp_production_group_rel_child_group_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ParentGroupId", "ChildGroupId").HasName("mrp_production_group_rel_pkey");
                                    j.ToTable("mrp_production_group_rel");
                                    j.HasIndex(new[] { "ChildGroupId", "ParentGroupId" }, "mrp_production_group_rel_child_group_id_parent_group_id_idx");
                                    j.IndexerProperty<Guid>("ParentGroupId").HasColumnName("parent_group_id");
                                    j.IndexerProperty<Guid>("ChildGroupId").HasColumnName("child_group_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}