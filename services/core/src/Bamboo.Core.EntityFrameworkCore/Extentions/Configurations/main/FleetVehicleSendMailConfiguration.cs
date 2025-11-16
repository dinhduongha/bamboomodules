using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureFleetVehicleSendMail(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<FleetVehicleSendMail>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("fleet_vehicle_send_mail_pkey");

                        entity.ToTable("fleet_vehicle_send_mail");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AuthorId).HasColumnName("author_id");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.Subject).HasColumnName("subject");
                        entity.Property(e => e.TemplateId).HasColumnName("template_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Author).WithMany(p => p.FleetVehicleSendMail) .HasForeignKey(d => d.AuthorId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("fleet_vehicle_send_mail_author_id_fkey");
                        entity.HasOne(d => d.Author).WithMany()
                            .HasForeignKey(d => d.AuthorId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("fleet_vehicle_send_mail_author_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.FleetVehicleSendMailCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_send_mail_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_send_mail_create_uid_fkey");

                        entity.HasOne(d => d.Template).WithMany(p => p.FleetVehicleSendMail)
                            .HasForeignKey(d => d.TemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_send_mail_template_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.FleetVehicleSendMailWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_send_mail_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_send_mail_write_uid_fkey");

                        // entity.HasMany(d => d.Attachment).WithMany(p => p.Wizard)
                        entity.HasMany(d => d.Attachment).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "FleetVehicleMailComposeMessageIrAttachmentsRel",
                                r => r.HasOne<IrAttachment>().WithMany()
                                    .HasForeignKey("AttachmentId")
                                    .HasConstraintName("fleet_vehicle_mail_compose_message_ir_attach_attachment_id_fkey"),
                                l => l.HasOne<FleetVehicleSendMail>().WithMany()
                                    .HasForeignKey("WizardId")
                                    .HasConstraintName("fleet_vehicle_mail_compose_message_ir_attachment_wizard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("WizardId", "AttachmentId").HasName("fleet_vehicle_mail_compose_message_ir_attachments_rel_pkey");
                                    j.ToTable("fleet_vehicle_mail_compose_message_ir_attachments_rel");
                                    j.HasIndex(new[] { "AttachmentId", "WizardId" }, "fleet_vehicle_mail_compose_message__attachment_id_wizard_id_idx");
                                    j.IndexerProperty<Guid>("WizardId").HasColumnName("wizard_id");
                                    j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                                });

                        // entity.HasMany(d => d.FleetVehicle).WithMany(p => p.FleetVehicleSendMail)
                        entity.HasMany(d => d.FleetVehicle).WithMany(p => p.FleetVehicleSendMail)
                            .UsingEntity<Dictionary<string, object>>(
                                "FleetVehicleFleetVehicleSendMailRel",
                                r => r.HasOne<FleetVehicle>().WithMany()
                                    .HasForeignKey("FleetVehicleId")
                                    .HasConstraintName("fleet_vehicle_fleet_vehicle_send_mail_rel_fleet_vehicle_id_fkey"),
                                l => l.HasOne<FleetVehicleSendMail>().WithMany()
                                    .HasForeignKey("FleetVehicleSendMailId")
                                    .HasConstraintName("fleet_vehicle_fleet_vehicle_sen_fleet_vehicle_send_mail_id_fkey"),
                                j =>
                                {
                                    j.HasKey("FleetVehicleSendMailId", "FleetVehicleId").HasName("fleet_vehicle_fleet_vehicle_send_mail_rel_pkey");
                                    j.ToTable("fleet_vehicle_fleet_vehicle_send_mail_rel");
                                    j.HasIndex(new[] { "FleetVehicleId", "FleetVehicleSendMailId" }, "fleet_vehicle_fleet_vehicle_s_fleet_vehicle_id_fleet_vehicl_idx");
                                    j.IndexerProperty<Guid>("FleetVehicleSendMailId").HasColumnName("fleet_vehicle_send_mail_id");
                                    j.IndexerProperty<Guid>("FleetVehicleId").HasColumnName("fleet_vehicle_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}