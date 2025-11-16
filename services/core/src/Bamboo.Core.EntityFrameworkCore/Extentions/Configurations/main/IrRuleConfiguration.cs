using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrRule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrRule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_rule_pkey");

                        entity.ToTable("ir_rule");

                        entity.HasIndex(e => e.ModelId, "ir_rule__model_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DomainForce).HasColumnName("domain_force");
                        entity.Property(e => e.Global).HasColumnName("global");
                        entity.Property(e => e.ModelId).HasColumnName("model_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PermCreate).HasColumnName("perm_create");
                        entity.Property(e => e.PermRead).HasColumnName("perm_read");
                        entity.Property(e => e.PermUnlink).HasColumnName("perm_unlink");
                        entity.Property(e => e.PermWrite).HasColumnName("perm_write");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrRuleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_rule_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_rule_create_uid_fkey");

                        entity.HasOne(d => d.Model).WithMany(p => p.IrRule)
                            .HasForeignKey(d => d.ModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_rule_model_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrRuleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_rule_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_rule_write_uid_fkey");

                        // entity.HasMany(d => d.Group).WithMany(p => p.RuleGroup)
                        entity.HasMany(d => d.Group).WithMany(p => p.RuleGroup)
                            .UsingEntity<Dictionary<string, object>>(
                                "RuleGroupRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("GroupId")
                                    .HasConstraintName("rule_group_rel_group_id_fkey"),
                                l => l.HasOne<IrRule>().WithMany()
                                    .HasForeignKey("RuleGroupId")
                                    .HasConstraintName("rule_group_rel_rule_group_id_fkey"),
                                j =>
                                {
                                    j.HasKey("RuleGroupId", "GroupId").HasName("rule_group_rel_pkey");
                                    j.ToTable("rule_group_rel");
                                    j.HasIndex(new[] { "GroupId", "RuleGroupId" }, "rule_group_rel_group_id_rule_group_id_idx");
                                    j.IndexerProperty<Guid>("RuleGroupId").HasColumnName("rule_group_id");
                                    j.IndexerProperty<Guid>("GroupId").HasColumnName("group_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}