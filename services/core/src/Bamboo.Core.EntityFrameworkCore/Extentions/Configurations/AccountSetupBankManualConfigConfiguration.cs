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
        public static void ConfigureAccountSetupBankManualConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountSetupBankManualConfig>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_setup_bank_manual_config_pkey");

                entity.ToTable("account_setup_bank_manual_config");

                entity.HasIndex(e => e.TenantId, "account_setup_bank_manual_config_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.NewJournalName).HasColumnName("new_journal_name");
                entity.Property(e => e.NumJournalsWithoutAccount).HasColumnName("num_journals_without_account");
                entity.Property(e => e.ResPartnerBankId).HasColumnName("res_partner_bank_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_setup_bank_manual_config_create_uid_fkey");

                entity.HasOne(d => d.ResPartnerBank).WithMany(p => p.AccountSetupBankManualConfigs)
                    .HasForeignKey(d => d.ResPartnerBankId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_setup_bank_manual_config_res_partner_bank_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_setup_bank_manual_config_write_uid_fkey");
            });
        }
    }
}