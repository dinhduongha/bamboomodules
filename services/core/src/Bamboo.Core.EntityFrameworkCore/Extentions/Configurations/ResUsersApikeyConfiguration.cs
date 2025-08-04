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
        public static void ConfigureResUsersApikey(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResUsersApikey>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_users_apikeys_pkey");

                entity.ToTable("res_users_apikeys");

                entity.HasIndex(e => e.TenantId, "res_users_apikeys_company_id_index");

                entity.HasIndex(e => new { e.UserId, e.Index }, "res_users_apikeys_user_id_index_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.Index).HasColumnName("index");
                entity.Property(e => e.Key).HasColumnName("key");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Scope).HasColumnName("scope");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("res_users_apikeys_user_id_fkey");
            });
        }
    }
}