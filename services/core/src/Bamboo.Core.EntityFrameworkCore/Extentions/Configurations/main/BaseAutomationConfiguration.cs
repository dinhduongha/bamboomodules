using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureBaseAutomation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseAutomation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_automation_pkey");

                        entity.ToTable("base_automation");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.FilterDomain).HasColumnName("filter_domain");
                        entity.Property(e => e.FilterPreDomain).HasColumnName("filter_pre_domain");
                        entity.Property(e => e.LastRun)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_run");
                        entity.Property(e => e.LogWebhookCalls).HasColumnName("log_webhook_calls");
                        entity.Property(e => e.ModelId).HasColumnName("model_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.RecordGetter).HasColumnName("record_getter");
                        entity.Property(e => e.TrgDateCalendarId).HasColumnName("trg_date_calendar_id");
                        entity.Property(e => e.TrgDateId).HasColumnName("trg_date_id");
                        entity.Property(e => e.TrgDateRange).HasColumnName("trg_date_range");
                        entity.Property(e => e.TrgDateRangeMode).HasColumnName("trg_date_range_mode");
                        entity.Property(e => e.TrgDateRangeType).HasColumnName("trg_date_range_type");
                        entity.Property(e => e.TrgFieldRef).HasColumnName("trg_field_ref");
                        entity.Property(e => e.TrgSelectionFieldId).HasColumnName("trg_selection_field_id");
                        entity.Property(e => e.Trigger).HasColumnName("trigger");
                        entity.Property(e => e.WebhookUuid).HasColumnName("webhook_uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseAutomationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("base_automation_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_automation_create_uid_fkey");

                        entity.HasOne(d => d.Model).WithMany(p => p.BaseAutomation)
                            .HasForeignKey(d => d.ModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("base_automation_model_id_fkey");

                        entity.HasOne(d => d.TrgDateCalendar).WithMany(p => p.BaseAutomation)
                            .HasForeignKey(d => d.TrgDateCalendarId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_automation_trg_date_calendar_id_fkey");

                        entity.HasOne(d => d.TrgDate).WithMany(p => p.BaseAutomation)
                            .HasForeignKey(d => d.TrgDateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_automation_trg_date_id_fkey");

                        entity.HasOne(d => d.TrgSelectionField).WithMany(p => p.BaseAutomation)
                            .HasForeignKey(d => d.TrgSelectionFieldId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_automation_trg_selection_field_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseAutomationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("base_automation_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_automation_write_uid_fkey");

                        // entity.HasMany(d => d.IrModelFields).WithMany(p => p.BaseAutomationNavigation)
                        entity.HasMany(d => d.IrModelFields).WithMany(p => p.BaseAutomationNavigation)
                            .UsingEntity<Dictionary<string, object>>(
                                "BaseAutomationIrModelFieldsRel",
                                r => r.HasOne<IrModelFields>().WithMany()
                                    .HasForeignKey("IrModelFieldsId")
                                    .HasConstraintName("base_automation_ir_model_fields_rel_ir_model_fields_id_fkey"),
                                l => l.HasOne<BaseAutomation>().WithMany()
                                    .HasForeignKey("BaseAutomationId")
                                    .HasConstraintName("base_automation_ir_model_fields_rel_base_automation_id_fkey"),
                                j =>
                                {
                                    j.HasKey("BaseAutomationId", "IrModelFieldsId").HasName("base_automation_ir_model_fields_rel_pkey");
                                    j.ToTable("base_automation_ir_model_fields_rel");
                                    j.HasIndex(new[] { "IrModelFieldsId", "BaseAutomationId" }, "base_automation_ir_model_fiel_ir_model_fields_id_base_autom_idx");
                                    j.IndexerProperty<Guid>("BaseAutomationId").HasColumnName("base_automation_id");
                                    j.IndexerProperty<Guid>("IrModelFieldsId").HasColumnName("ir_model_fields_id");
                                });

                        // entity.HasMany(d => d.IrModelFieldsNavigation).WithMany(p => p.BaseAutomation1)
                        entity.HasMany(d => d.IrModelFieldsNavigation).WithMany(p => p.BaseAutomation1)
                            .UsingEntity<Dictionary<string, object>>(
                                "BaseAutomationOnchangeFieldsRel",
                                r => r.HasOne<IrModelFields>().WithMany()
                                    .HasForeignKey("IrModelFieldsId")
                                    .HasConstraintName("base_automation_onchange_fields_rel_ir_model_fields_id_fkey"),
                                l => l.HasOne<BaseAutomation>().WithMany()
                                    .HasForeignKey("BaseAutomationId")
                                    .HasConstraintName("base_automation_onchange_fields_rel_base_automation_id_fkey"),
                                j =>
                                {
                                    j.HasKey("BaseAutomationId", "IrModelFieldsId").HasName("base_automation_onchange_fields_rel_pkey");
                                    j.ToTable("base_automation_onchange_fields_rel");
                                    j.HasIndex(new[] { "IrModelFieldsId", "BaseAutomationId" }, "base_automation_onchange_fiel_ir_model_fields_id_base_autom_idx");
                                    j.IndexerProperty<Guid>("BaseAutomationId").HasColumnName("base_automation_id");
                                    j.IndexerProperty<Guid>("IrModelFieldsId").HasColumnName("ir_model_fields_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}