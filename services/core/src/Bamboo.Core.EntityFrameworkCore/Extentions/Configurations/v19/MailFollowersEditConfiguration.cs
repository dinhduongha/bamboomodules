using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailFollowersEdit(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailFollowersEdit>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_followers_edit_pkey");

                        entity.ToTable("mail_followers_edit");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.Message).HasColumnName("message");
                        entity.Property(e => e.Notify).HasColumnName("notify");
                        entity.Property(e => e.Operation).HasColumnName("operation");
                        entity.Property(e => e.ResIds).HasColumnName("res_ids");
                        entity.Property(e => e.ResModel).HasColumnName("res_model");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailFollowersEditCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_followers_edit_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_followers_edit_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailFollowersEditWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_followers_edit_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_followers_edit_write_uid_fkey");

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.MailFollowersEdit)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MailFollowersEditResPartnerRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("mail_followers_edit_res_partner_rel_res_partner_id_fkey"),
                                l => l.HasOne<MailFollowersEdit>().WithMany()
                                    .HasForeignKey("MailFollowersEditId")
                                    .HasConstraintName("mail_followers_edit_res_partner_rel_mail_followers_edit_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MailFollowersEditId", "ResPartnerId").HasName("mail_followers_edit_res_partner_rel_pkey");
                                    j.ToTable("mail_followers_edit_res_partner_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "MailFollowersEditId" }, "mail_followers_edit_res_partn_res_partner_id_mail_followers_idx");
                                    j.IndexerProperty<Guid>("MailFollowersEditId").HasColumnName("mail_followers_edit_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}