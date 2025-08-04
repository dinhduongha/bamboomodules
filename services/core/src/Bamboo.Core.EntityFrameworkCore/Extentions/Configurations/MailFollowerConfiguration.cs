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
        public static void ConfigureMailFollower(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailFollower>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_followers_pkey");

                entity.ToTable("mail_followers");

                entity.HasIndex(e => new { e.ResModel, e.ResId, e.PartnerId }, "mail_followers_mail_followers_res_partner_res_model_id_uniq").IsUnique();

                entity.HasIndex(e => e.PartnerId, "mail_followers_partner_id_index");

                entity.HasIndex(e => e.ResId, "mail_followers_res_id_index");

                entity.HasIndex(e => e.ResModel, "mail_followers_res_model_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.ResId).HasColumnName("res_id");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_followers_partner_id_fkey");

                //entity.HasMany(d => d.MailMessageSubtypes).WithMany(p => p.MailFollowers)
                entity.HasMany<MailMessageSubtype>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailFollowersMailMessageSubtypeRel",
                        r => r.HasOne<MailMessageSubtype>().WithMany()
                            .HasForeignKey("MailMessageSubtypeId")
                            .HasConstraintName("mail_followers_mail_message_subtyp_mail_message_subtype_id_fkey"),
                        l => l.HasOne<MailFollower>().WithMany()
                            .HasForeignKey("MailFollowersId")
                            .HasConstraintName("mail_followers_mail_message_subtype_rel_mail_followers_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailFollowersId", "MailMessageSubtypeId").HasName("mail_followers_mail_message_subtype_rel_pkey");
                            j.ToTable("mail_followers_mail_message_subtype_rel");
                            j.HasIndex(new[] { "MailMessageSubtypeId", "MailFollowersId" }, "mail_followers_mail_message_s_mail_message_subtype_id_mail__idx");
                        });
            });
        }
    }
}