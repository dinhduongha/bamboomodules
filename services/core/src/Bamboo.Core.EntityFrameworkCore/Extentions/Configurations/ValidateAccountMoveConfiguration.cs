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
        public static void ConfigureValidateAccountMove(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValidateAccountMove>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("validate_account_move_pkey");

                entity.ToTable("validate_account_move");

                entity.HasIndex(e => e.TenantId, "validate_account_move_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ForcePost).HasColumnName("force_post");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("validate_account_move_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("validate_account_move_write_uid_fkey");

                entity.HasMany(d => d.AccountMoves).WithMany()
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
            });
        }
    }
}