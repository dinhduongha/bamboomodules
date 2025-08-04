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
        public static void ConfigureEventStage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventStage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_stage_pkey");

                entity.ToTable("event_stage", tb => tb.HasComment("Event Stage"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasComment("Stage description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.Fold)
                    .HasComment("Folded in Kanban")
                    .HasColumnName("fold");
                entity.Property(e => e.LegendBlocked)
                    .HasComment("Red Kanban Label")
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_blocked");
                entity.Property(e => e.LegendDone)
                    .HasComment("Green Kanban Label")
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_done");
                entity.Property(e => e.LegendNormal)
                    .HasComment("Grey Kanban Label")
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_normal");
                entity.Property(e => e.Name)
                    .HasComment("Stage Name")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PipeEnd)
                    .HasComment("End Stage")
                    .HasColumnName("pipe_end");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_stage_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_stage_write_uid_fkey");
            });
        }
    }
}