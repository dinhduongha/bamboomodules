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
        public static void ConfigureCertificateCertificate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CertificateCertificate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("certificate_certificate_pkey");

            entity.ToTable("certificate_certificate");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");

            entity.Property(e => e.ContentFormat).HasColumnName("content_format");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_start");
            entity.Property(e => e.LoadingError).HasColumnName("loading_error");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Pkcs12Password).HasColumnName("pkcs12_password");
            entity.Property(e => e.PrivateKeyId).HasColumnName("private_key_id");
            entity.Property(e => e.PublicKeyId).HasColumnName("public_key_id");
            entity.Property(e => e.Scope).HasColumnName("scope");
            entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            entity.Property(e => e.SubjectCommonName).HasColumnName("subject_common_name");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.CertificateCertificate)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("certificate_certificate_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.CertificateCertificateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("certificate_certificate_create_uid_fkey");

            entity.HasOne(d => d.PrivateKey).WithMany(p => p.CertificateCertificatePrivateKey)
                .HasForeignKey(d => d.PrivateKeyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("certificate_certificate_private_key_id_fkey");

            entity.HasOne(d => d.PublicKey).WithMany(p => p.CertificateCertificatePublicKey)
                .HasForeignKey(d => d.PublicKeyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("certificate_certificate_public_key_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.CertificateCertificateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("certificate_certificate_write_uid_fkey");
            });
        }
    }
}