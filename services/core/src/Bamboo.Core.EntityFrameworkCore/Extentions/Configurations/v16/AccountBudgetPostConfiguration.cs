using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountBudgetPost(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountBudgetPost>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_budget_post_pkey");

                        entity.ToTable("account_budget_post");

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
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountBudgetPost) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_budget_post_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_budget_post_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountBudgetPostCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_budget_post_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_budget_post_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountBudgetPostWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_budget_post_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_budget_post_write_uid_fkey");

                        // entity.HasMany(d => d.Account).WithMany(p => p.Budget)
                        entity.HasMany(d => d.Account).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountBudgetRel",
                                r => r.HasOne<AccountAccount>().WithMany()
                                    .HasForeignKey("AccountId")
                                    .HasConstraintName("account_budget_rel_account_id_fkey"),
                                l => l.HasOne<AccountBudgetPost>().WithMany()
                                    .HasForeignKey("BudgetId")
                                    .HasConstraintName("account_budget_rel_budget_id_fkey"),
                                j =>
                                {
                                    j.HasKey("BudgetId", "AccountId").HasName("account_budget_rel_pkey");
                                    j.ToTable("account_budget_rel");
                                    j.HasIndex(new[] { "AccountId", "BudgetId" }, "account_budget_rel_account_id_budget_id_idx");
                                    j.IndexerProperty<Guid>("BudgetId").HasColumnName("budget_id");
                                    j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}