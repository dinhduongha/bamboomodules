using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailCannedResponse(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailCannedResponse>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_canned_response_pkey");

                        entity.ToTable("mail_canned_response");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Source, "mail_canned_response__source_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.IsShared).HasColumnName("is_shared");
                        entity.Property(e => e.LastUsed)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_used");
                        entity.Property(e => e.Source).HasColumnName("source");
                        entity.Property(e => e.Substitution).HasColumnName("substitution");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailCannedResponseCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_canned_response_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_canned_response_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailCannedResponseWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_canned_response_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_canned_response_write_uid_fkey");

                        // entity.HasMany(d => d.ResGroups).WithMany(p => p.MailCannedResponse)
                        entity.HasMany(d => d.ResGroups).WithMany(p => p.MailCannedResponse)
                            .UsingEntity<Dictionary<string, object>>(
                                "MailCannedResponseResGroupsRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("ResGroupsId")
                                    .HasConstraintName("mail_canned_response_res_groups_rel_res_groups_id_fkey"),
                                l => l.HasOne<MailCannedResponse>().WithMany()
                                    .HasForeignKey("MailCannedResponseId")
                                    .HasConstraintName("mail_canned_response_res_groups_re_mail_canned_response_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MailCannedResponseId", "ResGroupsId").HasName("mail_canned_response_res_groups_rel_pkey");
                                    j.ToTable("mail_canned_response_res_groups_rel");
                                    j.HasIndex(new[] { "ResGroupsId", "MailCannedResponseId" }, "mail_canned_response_res_grou_res_groups_id_mail_canned_res_idx");
                                    j.IndexerProperty<Guid>("MailCannedResponseId").HasColumnName("mail_canned_response_id");
                                    j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}