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
        public static void ConfigureNoteNote(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteNote>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("note_note_pkey");

                entity.ToTable("note_note");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateDone).HasColumnName("date_done");
                entity.Property(e => e.Memo).HasColumnName("memo");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Open).HasColumnName("open");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("note_note_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("note_note_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.NoteNotes)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("note_note_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("note_note_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("note_note_write_uid_fkey");

                //entity.HasMany(d => d.Stages).WithMany(p => p.Notes)
                entity.HasMany<NoteStage>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "NoteStageRel",
                        r => r.HasOne<NoteStage>().WithMany()
                            .HasForeignKey("StageId")
                            .HasConstraintName("note_stage_rel_stage_id_fkey"),
                        l => l.HasOne<NoteNote>().WithMany()
                            .HasForeignKey("NoteId")
                            .HasConstraintName("note_stage_rel_note_id_fkey"),
                        j =>
                        {
                            j.HasKey("NoteId", "StageId").HasName("note_stage_rel_pkey");
                            j.ToTable("note_stage_rel");
                            j.HasIndex(new[] { "StageId", "NoteId" }, "note_stage_rel_stage_id_note_id_idx");
                        });

                //entity.HasMany(d => d.Tags).WithMany(p => p.Notes)
                entity.HasMany<NoteTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "NoteTagsRel",
                        r => r.HasOne<NoteTag>().WithMany()
                            .HasForeignKey("TagId")
                            .HasConstraintName("note_tags_rel_tag_id_fkey"),
                        l => l.HasOne<NoteNote>().WithMany()
                            .HasForeignKey("NoteId")
                            .HasConstraintName("note_tags_rel_note_id_fkey"),
                        j =>
                        {
                            j.HasKey("NoteId", "TagId").HasName("note_tags_rel_pkey");
                            j.ToTable("note_tags_rel");
                            j.HasIndex(new[] { "TagId", "NoteId" }, "note_tags_rel_tag_id_note_id_idx");
                        });
            });
        }
    }
}