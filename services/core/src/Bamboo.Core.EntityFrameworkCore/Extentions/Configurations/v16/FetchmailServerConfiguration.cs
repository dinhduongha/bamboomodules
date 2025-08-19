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
        public static void ConfigureFetchmailServer(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<FetchmailServer>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("fetchmail_server_pkey");

            entity.ToTable("fetchmail_server");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.ServerType, "fetchmail_server_server_type_index");

            entity.HasIndex(e => e.State, "fetchmail_server_state_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Attach).HasColumnName("attach");
            entity.Property(e => e.Configuration).HasColumnName("configuration");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.GoogleGmailAccessToken).HasColumnName("google_gmail_access_token");
            entity.Property(e => e.GoogleGmailAccessTokenExpiration).HasColumnName("google_gmail_access_token_expiration");
            entity.Property(e => e.GoogleGmailAuthorizationCode).HasColumnName("google_gmail_authorization_code");
            entity.Property(e => e.GoogleGmailRefreshToken).HasColumnName("google_gmail_refresh_token");
            entity.Property(e => e.IsSsl).HasColumnName("is_ssl");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.Original).HasColumnName("original");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Port).HasColumnName("port");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Script).HasColumnName("script");
            entity.Property(e => e.Server).HasColumnName("server");
            entity.Property(e => e.ServerType).HasColumnName("server_type");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.User).HasColumnName("user");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.FetchmailServerCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fetchmail_server_create_uid_fkey");

            entity.HasOne(d => d.Object).WithMany(p => p.FetchmailServer)
                .HasForeignKey(d => d.ObjectId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fetchmail_server_object_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.FetchmailServerWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fetchmail_server_write_uid_fkey");
            });
        }
    }
}