using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailPresence(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailPresence>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_presence_pkey");

                        entity.ToTable("mail_presence");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.GuestId, "mail_presence_guest_unique")
                            .IsUnique()
                            .HasFilter("(guest_id IS NOT NULL)");

                        entity.HasIndex(e => e.UserId, "mail_presence_user_unique")
                            .IsUnique()
                            .HasFilter("(user_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.GuestId).HasColumnName("guest_id");
                        entity.Property(e => e.LastPoll)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_poll");
                        entity.Property(e => e.LastPresence)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_presence");
                        entity.Property(e => e.Status).HasColumnName("status");
                        entity.Property(e => e.UserId).HasColumnName("user_id");

                        entity.HasOne(d => d.Guest).WithOne(p => p.MailPresence)
                            .HasForeignKey<MailPresence>(d => d.GuestId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_presence_guest_id_fkey");

                        // entity.HasOne(d => d.User).WithOne(p => p.MailPresence) .HasForeignKey<MailPresence>(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("mail_presence_user_id_fkey");
                        entity.HasOne(d => d.User).WithOne(p => p.MailPresence)
                            .HasForeignKey<MailPresence>(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_presence_user_id_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}