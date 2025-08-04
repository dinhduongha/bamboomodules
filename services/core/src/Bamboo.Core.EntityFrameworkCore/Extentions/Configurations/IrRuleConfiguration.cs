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
        public static void ConfigureIrRule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrRule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_rule_pkey");

                entity.ToTable("ir_rule");

                entity.HasIndex(e => e.ModelId, "ir_rule_model_id_index");

                entity.HasIndex(e => e.Name, "ir_rule_name_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_rule_create_uid_fkey");

                entity.HasOne(d => d.Model).WithMany(p => p.IrRules)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_rule_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_rule_write_uid_fkey");

                entity.HasMany(d => d.Groups).WithMany(p => p.RuleGroups)
                //entity.HasMany<ResGroup>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "RuleGroupRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("GroupId")
                            .OnDelete(DeleteBehavior.Restrict)
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
            });
        }
    }
}