using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHtmlEditorConverterTest(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HtmlEditorConverterTest>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("html_editor_converter_test_pkey");

                        entity.ToTable("html_editor_converter_test");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Binary).HasColumnName("binary");
                        entity.Property(e => e.Char).HasColumnName("char");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.Datetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("datetime");
                        entity.Property(e => e.Float).HasColumnName("float");
                        entity.Property(e => e.Html).HasColumnName("html");
                        entity.Property(e => e.Integer).HasColumnName("integer");
                        entity.Property(e => e.Many2one).HasColumnName("many2one");
                        entity.Property(e => e.Numeric).HasColumnName("numeric");
                        entity.Property(e => e.SelectionStr).HasColumnName("selection_str");
                        entity.Property(e => e.Text).HasColumnName("text");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HtmlEditorConverterTestCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("html_editor_converter_test_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("html_editor_converter_test_create_uid_fkey");

                        entity.HasOne(d => d.Many2oneNavigation).WithMany(p => p.HtmlEditorConverterTest)
                            .HasForeignKey(d => d.Many2one)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("html_editor_converter_test_many2one_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HtmlEditorConverterTestWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("html_editor_converter_test_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("html_editor_converter_test_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}