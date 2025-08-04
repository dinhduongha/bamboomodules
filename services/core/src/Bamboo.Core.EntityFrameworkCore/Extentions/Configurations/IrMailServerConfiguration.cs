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
        public static void ConfigureIrMailServer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrMailServer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_mail_server_pkey");

                entity.ToTable("ir_mail_server");

                entity.HasIndex(e => e.Name, "ir_mail_server_name_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.FromFilter).HasColumnName("from_filter");
                entity.Property(e => e.GoogleGmailAccessToken).HasColumnName("google_gmail_access_token");
                entity.Property(e => e.GoogleGmailAccessTokenExpiration).HasColumnName("google_gmail_access_token_expiration");
                entity.Property(e => e.GoogleGmailAuthorizationCode).HasColumnName("google_gmail_authorization_code");
                entity.Property(e => e.GoogleGmailRefreshToken).HasColumnName("google_gmail_refresh_token");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.SmtpAuthentication).HasColumnName("smtp_authentication");
                entity.Property(e => e.SmtpDebug).HasColumnName("smtp_debug");
                entity.Property(e => e.SmtpEncryption).HasColumnName("smtp_encryption");
                entity.Property(e => e.SmtpHost).HasColumnName("smtp_host");
                entity.Property(e => e.SmtpPass).HasColumnName("smtp_pass");
                entity.Property(e => e.SmtpPort).HasColumnName("smtp_port");
                entity.Property(e => e.SmtpSslCertificate).HasColumnName("smtp_ssl_certificate");
                entity.Property(e => e.SmtpSslPrivateKey).HasColumnName("smtp_ssl_private_key");
                entity.Property(e => e.SmtpUser).HasColumnName("smtp_user");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_mail_server_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_mail_server_write_uid_fkey");
            });
        }
    }
}