using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResUsersApikeys(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResUsersApikeys>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_users_apikeys_pkey");

                        entity.ToTable("res_users_apikeys");

                        entity.HasIndex(e => new { e.UserId, e.Index }, "res_users_apikeys_user_id_index_idx");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.ExpirationDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("expiration_date");
                        entity.Property(e => e.Index).HasColumnName("index");
                        entity.Property(e => e.Key).HasColumnName("key");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Scope).HasColumnName("scope");
                        entity.Property(e => e.UserId).HasColumnName("user_id");

                        // entity.HasOne(d => d.User).WithMany(p => p.ResUsersApikeys) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("res_users_apikeys_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("res_users_apikeys_user_id_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}