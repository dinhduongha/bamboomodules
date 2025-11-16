using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureValidateAccountMove(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ValidateAccountMove>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("validate_account_move_pkey");

                        entity.ToTable("validate_account_move");

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
                        entity.Property(e => e.ForceHash).HasColumnName("force_hash");
                        entity.Property(e => e.ForcePost).HasColumnName("force_post");
                        entity.Property(e => e.IgnoreAbnormalAmount).HasColumnName("ignore_abnormal_amount");
                        entity.Property(e => e.IgnoreAbnormalDate).HasColumnName("ignore_abnormal_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ValidateAccountMoveCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("validate_account_move_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("validate_account_move_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ValidateAccountMoveWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("validate_account_move_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("validate_account_move_write_uid_fkey");

                        // entity.HasMany(d => d.AccountMove).WithMany(p => p.ValidateAccountMove)
                        entity.HasMany(d => d.AccountMove).WithMany(p => p.ValidateAccountMove)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountMoveValidateAccountMoveRel",
                                r => r.HasOne<AccountMove>().WithMany()
                                    .HasForeignKey("AccountMoveId")
                                    .HasConstraintName("account_move_validate_account_move_rel_account_move_id_fkey"),
                                l => l.HasOne<ValidateAccountMove>().WithMany()
                                    .HasForeignKey("ValidateAccountMoveId")
                                    .HasConstraintName("account_move_validate_account_mov_validate_account_move_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ValidateAccountMoveId", "AccountMoveId").HasName("account_move_validate_account_move_rel_pkey");
                                    j.ToTable("account_move_validate_account_move_rel");
                                    j.HasIndex(new[] { "AccountMoveId", "ValidateAccountMoveId" }, "account_move_validate_account_account_move_id_validate_acco_idx");
                                    j.IndexerProperty<Guid>("ValidateAccountMoveId").HasColumnName("validate_account_move_id");
                                    j.IndexerProperty<Guid>("AccountMoveId").HasColumnName("account_move_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}