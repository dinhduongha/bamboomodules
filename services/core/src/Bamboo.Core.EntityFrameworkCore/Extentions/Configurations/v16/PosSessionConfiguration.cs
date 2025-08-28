using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePosSession(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosSession>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_session_pkey");

                        entity.ToTable("pos_session");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ConfigId, "pos_session__config_id_index");

                        entity.HasIndex(e => e.MoveId, "pos_session__move_id_index");

                        entity.HasIndex(e => e.State, "pos_session__state_index");

                        entity.HasIndex(e => e.UserId, "pos_session__user_id_index");

                        entity.HasIndex(e => e.Name, "pos_session_uniq_name").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.CashJournalId).HasColumnName("cash_journal_id");
                        entity.Property(e => e.CashRealTransaction).HasColumnName("cash_real_transaction");
                        entity.Property(e => e.CashRegisterBalanceEndReal).HasColumnName("cash_register_balance_end_real");
                        entity.Property(e => e.CashRegisterBalanceStart).HasColumnName("cash_register_balance_start");
                        entity.Property(e => e.ClosingNotes).HasColumnName("closing_notes");
                        entity.Property(e => e.ConfigId).HasColumnName("config_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.LoginNumber).HasColumnName("login_number");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.OpeningNotes).HasColumnName("opening_notes");
                        entity.Property(e => e.Rescue).HasColumnName("rescue");
                        entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");
                        entity.Property(e => e.StartAt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("start_at");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.StopAt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("stop_at");
                        entity.Property(e => e.UpdateStockAtClosing).HasColumnName("update_stock_at_closing");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.CashJournal).WithMany(p => p.PosSession)
                            .HasForeignKey(d => d.CashJournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_session_cash_journal_id_fkey");

                        entity.HasOne(d => d.Config).WithMany(p => p.PosSession)
                            .HasForeignKey(d => d.ConfigId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_session_config_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PosSessionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_session_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_session_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.PosSession)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_session_employee_id_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.PosSession)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_session_move_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.PosSessionUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("pos_session_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_session_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PosSessionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_session_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_session_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}