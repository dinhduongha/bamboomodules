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
        public static void ConfigureIrActServer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrActServer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_act_server_pkey");

                entity.ToTable("ir_act_server");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.ActivityDateDeadlineRange).HasColumnName("activity_date_deadline_range");
                entity.Property(e => e.ActivityDateDeadlineRangeType).HasColumnName("activity_date_deadline_range_type");
                entity.Property(e => e.ActivityNote).HasColumnName("activity_note");
                entity.Property(e => e.ActivitySummary).HasColumnName("activity_summary");
                entity.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");
                entity.Property(e => e.ActivityUserFieldName).HasColumnName("activity_user_field_name");
                entity.Property(e => e.ActivityUserId).HasColumnName("activity_user_id");
                entity.Property(e => e.ActivityUserType).HasColumnName("activity_user_type");
                entity.Property(e => e.BindingModelId).HasColumnName("binding_model_id");
                entity.Property(e => e.BindingType).HasColumnName("binding_type");
                entity.Property(e => e.BindingViewTypes).HasColumnName("binding_view_types");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CrudModelId).HasColumnName("crud_model_id");
                entity.Property(e => e.Help)
                    .HasColumnType("jsonb")
                    .HasColumnName("help");
                entity.Property(e => e.LinkFieldId).HasColumnName("link_field_id");
                entity.Property(e => e.MailPostAutofollow).HasColumnName("mail_post_autofollow");
                entity.Property(e => e.MailPostMethod).HasColumnName("mail_post_method");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.ModelName).HasColumnName("model_name");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.SmsMethod).HasColumnName("sms_method");
                entity.Property(e => e.SmsTemplateId).HasColumnName("sms_template_id");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.TemplateId).HasColumnName("template_id");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.Usage).HasColumnName("usage");
                entity.Property(e => e.WebsitePath).HasColumnName("website_path");
                entity.Property(e => e.WebsitePublished).HasColumnName("website_published");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.ActivityType).WithMany(p => p.IrActServers)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ir_act_server_activity_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.ActivityUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_server_activity_user_id_fkey");

                entity.HasOne(d => d.BindingModel).WithMany(p => p.IrActServerBindingModels)
                    .HasForeignKey(d => d.BindingModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_act_server_binding_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_server_create_uid_fkey");

                entity.HasOne(d => d.CrudModel).WithMany(p => p.IrActServerCrudModels)
                    .HasForeignKey(d => d.CrudModelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_server_crud_model_id_fkey");

                entity.HasOne(d => d.LinkField).WithMany(p => p.IrActServers)
                    .HasForeignKey(d => d.LinkFieldId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_server_link_field_id_fkey");

                entity.HasOne(d => d.Model).WithMany(p => p.IrActServerModels)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_act_server_model_id_fkey");

                entity.HasOne(d => d.SmsTemplate).WithMany(p => p.IrActServers)
                    .HasForeignKey(d => d.SmsTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_server_sms_template_id_fkey");

                entity.HasOne(d => d.Template).WithMany(p => p.IrActServers)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_server_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_server_write_uid_fkey");

                //entity.HasMany(d => d.Actions).WithMany(p => p.Servers)
                entity.HasMany<IrActServer>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "RelServerAction",
                        r => r.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ActionId")
                            .HasConstraintName("rel_server_actions_action_id_fkey"),
                        l => l.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ServerId")
                            .HasConstraintName("rel_server_actions_server_id_fkey"),
                        j =>
                        {
                            j.HasKey("ServerId", "ActionId").HasName("rel_server_actions_pkey");
                            j.ToTable("rel_server_actions");
                            j.HasIndex(new[] { "ActionId", "ServerId" }, "rel_server_actions_action_id_server_id_idx");
                        });

                entity.HasMany(d => d.Fields).WithMany(p => p.Servers)
                    .UsingEntity<Dictionary<string, object>>(
                        "IrActServerWebhookFieldRel",
                        r => r.HasOne<IrModelFields>().WithMany()
                            .HasForeignKey("FieldId")
                            .HasConstraintName("ir_act_server_webhook_field_rel_field_id_fkey"),
                        l => l.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ServerId")
                            .HasConstraintName("ir_act_server_webhook_field_rel_server_id_fkey"),
                        j =>
                        {
                            j.HasKey("ServerId", "FieldId").HasName("ir_act_server_webhook_field_rel_pkey");
                            j.ToTable("ir_act_server_webhook_field_rel");
                            j.HasIndex(new[] { "FieldId", "ServerId" }, "ir_act_server_webhook_field_rel_field_id_server_id_idx");
                            j.IndexerProperty<Guid>("ServerId").HasColumnName("server_id");
                            j.IndexerProperty<Guid>("FieldId").HasColumnName("field_id");
                        });

                //entity.HasMany(d => d.Gids).WithMany(p => p.Acts)
                entity.HasMany<ResGroup>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "IrActServerGroupRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("Gid")
                            .HasConstraintName("ir_act_server_group_rel_gid_fkey"),
                        l => l.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ActId")
                            .HasConstraintName("ir_act_server_group_rel_act_id_fkey"),
                        j =>
                        {
                            j.HasKey("ActId", "Gid").HasName("ir_act_server_group_rel_pkey");
                            j.ToTable("ir_act_server_group_rel");
                            j.HasIndex(new[] { "Gid", "ActId" }, "ir_act_server_group_rel_gid_act_id_idx");
                        });

                //entity.HasMany(d => d.ResPartners).WithMany(p => p.IrActServers)
                entity.HasMany<ResPartner>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "IrActServerResPartnerRel",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("ResPartnerId")
                            .HasConstraintName("ir_act_server_res_partner_rel_res_partner_id_fkey"),
                        l => l.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("IrActServerId")
                            .HasConstraintName("ir_act_server_res_partner_rel_ir_act_server_id_fkey"),
                        j =>
                        {
                            j.HasKey("IrActServerId", "ResPartnerId").HasName("ir_act_server_res_partner_rel_pkey");
                            j.ToTable("ir_act_server_res_partner_rel");
                            j.HasIndex(new[] { "ResPartnerId", "IrActServerId" }, "ir_act_server_res_partner_rel_res_partner_id_ir_act_server__idx");
                        });

                //entity.HasMany(d => d.Servers).WithMany(p => p.Actions)
                entity.HasMany<IrActServer>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "RelServerAction",
                        r => r.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ServerId")
                            .HasConstraintName("rel_server_actions_server_id_fkey"),
                        l => l.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ActionId")
                            .HasConstraintName("rel_server_actions_action_id_fkey"),
                        j =>
                        {
                            j.HasKey("ServerId", "ActionId").HasName("rel_server_actions_pkey");
                            j.ToTable("rel_server_actions");
                            j.HasIndex(new[] { "ActionId", "ServerId" }, "rel_server_actions_action_id_server_id_idx");
                        });
            });
        }
    }
}