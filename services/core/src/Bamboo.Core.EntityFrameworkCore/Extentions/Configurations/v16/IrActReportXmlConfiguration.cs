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
        public static void ConfigureIrActReportXml(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrActReportXml>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_act_report_xml_pkey");

            entity.ToTable("ir_act_report_xml");

            entity.HasIndex(e => e.Path, "ir_act_report_xml_path_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Attachment).HasColumnName("attachment");
            entity.Property(e => e.AttachmentUse).HasColumnName("attachment_use");
            entity.Property(e => e.BindingModelId).HasColumnName("binding_model_id");
            entity.Property(e => e.BindingType).HasColumnName("binding_type");
            entity.Property(e => e.BindingViewTypes).HasColumnName("binding_view_types");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Domain).HasColumnName("domain");
            entity.Property(e => e.Help)
                .HasColumnType("jsonb")
                .HasColumnName("help");
            entity.Property(e => e.IsInvoiceReport).HasColumnName("is_invoice_report");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.Multi).HasColumnName("multi");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.PaperformatId).HasColumnName("paperformat_id");
            entity.Property(e => e.Path).HasColumnName("path");
            entity.Property(e => e.PrintReportName)
                .HasColumnType("jsonb")
                .HasColumnName("print_report_name");
            entity.Property(e => e.ReportFile).HasColumnName("report_file");
            entity.Property(e => e.ReportName).HasColumnName("report_name");
            entity.Property(e => e.ReportType).HasColumnName("report_type");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.BindingModel).WithMany(p => p.IrActReportXml)
                .HasForeignKey(d => d.BindingModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_act_report_xml_binding_model_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrActReportXmlCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_act_report_xml_create_uid_fkey");

            entity.HasOne(d => d.Paperformat).WithMany(p => p.IrActReportXml)
                .HasForeignKey(d => d.PaperformatId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_act_report_xml_paperformat_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrActReportXmlWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_act_report_xml_write_uid_fkey");

            // entity.HasMany(d => d.Gid).WithMany(p => p.Uid)
            entity.HasMany(d => d.Gid).WithMany(p => p.Uid)
                .UsingEntity<Dictionary<string, object>>(
                    "ResGroupsReportRel",
                    r => r.HasOne<ResGroups>().WithMany()
                        .HasForeignKey("Gid")
                        .HasConstraintName("res_groups_report_rel_gid_fkey"),
                    l => l.HasOne<IrActReportXml>().WithMany()
                        .HasForeignKey("Uid")
                        .HasConstraintName("res_groups_report_rel_uid_fkey"),
                    j =>
                    {
                        j.HasKey("Uid", "Gid").HasName("res_groups_report_rel_pkey");
                        j.ToTable("res_groups_report_rel");
                        j.HasIndex(new[] { "Gid", "Uid" }, "res_groups_report_rel_gid_uid_idx");
                        j.IndexerProperty<Guid>("Uid").HasColumnName("uid");
                        j.IndexerProperty<Guid>("Gid").HasColumnName("gid");
                    });
            });
        }
    }
}
