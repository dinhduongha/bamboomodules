using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIapAccount(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IapAccount>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("iap_account_pkey");

            entity.ToTable("iap_account");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountToken).HasColumnName("account_token");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SenderName).HasColumnName("sender_name");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceLocked).HasColumnName("service_locked");
            entity.Property(e => e.ServiceName).HasColumnName("service_name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.WarningThreshold).HasColumnName("warning_threshold");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IapAccountCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("iap_account_create_uid_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.IapAccount)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("iap_account_service_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IapAccountWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("iap_account_write_uid_fkey");

            // entity.HasMany(d => d.ResCompany).WithMany(p => p.IapAccount)
            entity.HasMany(d => d.ResCompany).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "IapAccountResCompanyRel",
                    r => r.HasOne<ResCompany>().WithMany()
                        .HasForeignKey("ResCompanyId")
                        .HasConstraintName("iap_account_res_company_rel_res_company_id_fkey"),
                    l => l.HasOne<IapAccount>().WithMany()
                        .HasForeignKey("IapAccountId")
                        .HasConstraintName("iap_account_res_company_rel_iap_account_id_fkey"),
                    j =>
                    {
                        j.HasKey("IapAccountId", "ResCompanyId").HasName("iap_account_res_company_rel_pkey");
                        j.ToTable("iap_account_res_company_rel");
                        j.HasIndex(new[] { "ResCompanyId", "IapAccountId" }, "iap_account_res_company_rel_res_company_id_iap_account_id_idx");
                        j.IndexerProperty<Guid>("IapAccountId").HasColumnName("iap_account_id");
                        j.IndexerProperty<Guid>("ResCompanyId").HasColumnName("res_company_id");
                    });

            // entity.HasMany(d => d.ResUsers).WithMany(p => p.IapAccount)
            entity.HasMany(d => d.ResUsers).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "IapAccountResUsersRel",
                    r => r.HasOne<ResUsers>().WithMany()
                        .HasForeignKey("ResUsersId")
                        .HasConstraintName("iap_account_res_users_rel_res_users_id_fkey"),
                    l => l.HasOne<IapAccount>().WithMany()
                        .HasForeignKey("IapAccountId")
                        .HasConstraintName("iap_account_res_users_rel_iap_account_id_fkey"),
                    j =>
                    {
                        j.HasKey("IapAccountId", "ResUsersId").HasName("iap_account_res_users_rel_pkey");
                        j.ToTable("iap_account_res_users_rel");
                        j.HasIndex(new[] { "ResUsersId", "IapAccountId" }, "iap_account_res_users_rel_res_users_id_iap_account_id_idx");
                        j.IndexerProperty<Guid>("IapAccountId").HasColumnName("iap_account_id");
                        j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                    });
            });
        }
    }
}
