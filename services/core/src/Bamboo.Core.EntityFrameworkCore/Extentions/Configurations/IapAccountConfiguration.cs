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
        public static void ConfigureIapAccount(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IapAccount>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("iap_account_pkey");

                entity.ToTable("iap_account");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountToken).HasColumnName("account_token");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ServiceName).HasColumnName("service_name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("iap_account_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("iap_account_write_uid_fkey");

                //entity.HasMany(d => d.ResCompanies).WithMany(p => p.IapAccounts)
                entity.HasMany<ResCompany>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "IapAccountResCompanyRel",
                        r => r.HasOne<ResCompany>().WithMany()
                            .HasForeignKey("TenantId")
                            .HasConstraintName("iap_account_res_company_rel_res_company_id_fkey"),
                        l => l.HasOne<IapAccount>().WithMany()
                            .HasForeignKey("IapAccountId")
                            .HasConstraintName("iap_account_res_company_rel_iap_account_id_fkey"),
                        j =>
                        {
                            j.HasKey("IapAccountId", "TenantId").HasName("iap_account_res_company_rel_pkey");
                            j.ToTable("iap_account_res_company_rel");
                            j.HasIndex(new[] { "TenantId", "IapAccountId" }, "iap_account_res_company_rel_res_company_id_iap_account_id_idx");
                            j.IndexerProperty<Guid>("IapAccountId").HasColumnName("iap_account_id");
                            j.IndexerProperty<Guid>("TenantId").HasColumnName("res_company_id");
                        });

                entity.HasMany(d => d.ResUsers).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "IapAccountResUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
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