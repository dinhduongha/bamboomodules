using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailPushDevice(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailPushDevice>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_push_device_pkey");

                        entity.ToTable("mail_push_device");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.PartnerId, "mail_push_device__partner_id_index");

                        entity.HasIndex(e => e.Endpoint, "mail_push_device_endpoint_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Endpoint).HasColumnName("endpoint");
                        entity.Property(e => e.ExpirationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("expiration_time");
                        entity.Property(e => e.Keys).HasColumnName("keys");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailPushDeviceCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_push_device_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_push_device_create_uid_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.MailPushDevice) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mail_push_device_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mail_push_device_partner_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailPushDeviceWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_push_device_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_push_device_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}