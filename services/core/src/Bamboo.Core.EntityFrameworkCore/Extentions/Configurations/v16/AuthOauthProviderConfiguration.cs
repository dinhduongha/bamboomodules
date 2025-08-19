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
        public static void ConfigureAuthOauthProvider(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AuthOauthProvider>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("auth_oauth_provider_pkey");

            entity.ToTable("auth_oauth_provider");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AuthEndpoint).HasColumnName("auth_endpoint");
            entity.Property(e => e.Body)
                .HasColumnType("jsonb")
                .HasColumnName("body");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CssClass).HasColumnName("css_class");
            entity.Property(e => e.DataEndpoint).HasColumnName("data_endpoint");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Scope).HasColumnName("scope");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.ValidationEndpoint).HasColumnName("validation_endpoint");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AuthOauthProviderCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("auth_oauth_provider_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AuthOauthProviderWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("auth_oauth_provider_write_uid_fkey");
            });
        }
    }
}