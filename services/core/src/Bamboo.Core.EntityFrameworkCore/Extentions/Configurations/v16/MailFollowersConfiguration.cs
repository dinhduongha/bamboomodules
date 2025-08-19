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
        public static void ConfigureMailFollowers(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailFollowers>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_followers_pkey");

            entity.ToTable("mail_followers");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.PartnerId, "mail_followers__partner_id_index");

            entity.HasIndex(e => e.ResId, "mail_followers__res_id_index");

            entity.HasIndex(e => e.ResModel, "mail_followers__res_model_index");

            entity.HasIndex(e => new { e.ResModel, e.ResId, e.PartnerId }, "mail_followers_mail_followers_res_partner_res_model_id_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ResId).HasColumnName("res_id");
            entity.Property(e => e.ResModel).HasColumnName("res_model");

            // entity.HasOne(d => d.Partner).WithMany(p => p.MailFollowers)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_followers_partner_id_fkey");

            // entity.HasMany(d => d.MailMessageSubtype).WithMany(p => p.MailFollowers)
            entity.HasMany(d => d.MailMessageSubtype).WithMany(p => p.MailFollowers)
                .UsingEntity<Dictionary<string, object>>(
                    "MailFollowersMailMessageSubtypeRel",
                    r => r.HasOne<MailMessageSubtype>().WithMany()
                        .HasForeignKey("MailMessageSubtypeId")
                        .HasConstraintName("mail_followers_mail_message_subtyp_mail_message_subtype_id_fkey"),
                    l => l.HasOne<MailFollowers>().WithMany()
                        .HasForeignKey("MailFollowersId")
                        .HasConstraintName("mail_followers_mail_message_subtype_rel_mail_followers_id_fkey"),
                    j =>
                    {
                        j.HasKey("MailFollowersId", "MailMessageSubtypeId").HasName("mail_followers_mail_message_subtype_rel_pkey");
                        j.ToTable("mail_followers_mail_message_subtype_rel");
                        j.HasIndex(new[] { "MailMessageSubtypeId", "MailFollowersId" }, "mail_followers_mail_message_s_mail_message_subtype_id_mail__idx");
                        j.IndexerProperty<Guid>("MailFollowersId").HasColumnName("mail_followers_id");
                        j.IndexerProperty<Guid>("MailMessageSubtypeId").HasColumnName("mail_message_subtype_id");
                    });
            });
        }
    }
}
