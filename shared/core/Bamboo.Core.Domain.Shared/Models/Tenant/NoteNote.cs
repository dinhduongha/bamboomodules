using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("note_note")]
public partial class NoteNote: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("date_done")]
    public DateTime? DateDone { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("memo")]
    public string? Memo { get; set; }

    [Column("open")]
    public bool? Open { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("NoteNotes")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("NoteNoteCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("NoteNotes")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("NoteNoteUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("NoteNoteWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("NoteNavigation")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivities { get; } = new List<MailActivity>();

    [ForeignKey("NoteId")]
    //[InverseProperty("Notes")]
    [NotMapped]
    public virtual ICollection<NoteStage> Stages { get; } = new List<NoteStage>();

    [ForeignKey("NoteId")]
    //[InverseProperty("Notes")]
    [NotMapped]
    public virtual ICollection<NoteTag> Tags { get; } = new List<NoteTag>();
}
