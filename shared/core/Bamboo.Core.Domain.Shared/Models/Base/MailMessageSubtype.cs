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

[Table("mail_message_subtype")]
public partial class MailMessageSubtype: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("parent_id")]
    public long? ParentId { get; set; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("relation_field")]
    public string? RelationField { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("internal")]
    public bool? Internal { get; set; }

    [Column("default")]
    public bool? Default { get; set; }

    [Column("hidden")]
    public bool? Hidden { get; set; }

    [Column("track_recipients")]
    public bool? TrackRecipients { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailMessageSubtypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual MailMessageSubtype? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailMessageSubtypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("AllocationNotifSubtype")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypeAllocationNotifSubtypes { get; } = new List<HrLeaveType>();

    //[InverseProperty("LeaveNotifSubtype")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypeLeaveNotifSubtypes { get; } = new List<HrLeaveType>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<MailMessageSubtype> InverseParent { get; } = new List<MailMessageSubtype>();

    //[InverseProperty("Subtype")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; } = new List<MailComposeMessage>();

    //[InverseProperty("Subtype")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages { get; } = new List<MailMessage>();

    [ForeignKey("MailMessageSubtypeId")]
    //[InverseProperty("MailMessageSubtypes")]
    [NotMapped]
    public virtual ICollection<MailFollower> MailFollowers { get; } = new List<MailFollower>();
}
