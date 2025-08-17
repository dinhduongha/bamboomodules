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
public partial class MailMessageSubtype: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("relation_field")]
    public string? RelationField { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailMessageSubtypeCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("AllocationNotifSubtypeId")]
    [InverseProperty("AllocationNotifSubtype")]
    public virtual ICollection<HrLeaveType> HrLeaveTypeAllocationNotifSubtype { get; set; }

    // [One2many]
    [ForeignKey("LeaveNotifSubtypeId")]
    [InverseProperty("LeaveNotifSubtype")]
    public virtual ICollection<HrLeaveType> HrLeaveTypeLeaveNotifSubtype { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<MailMessageSubtype> InverseParent { get; set; }

    // [One2many]
    [ForeignKey("SubtypeId")]
    [InverseProperty("Subtype")]
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    [ForeignKey("SubtypeId")]
    [InverseProperty("Subtype")]
    public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual MailMessageSubtype? Parent { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailMessageSubtypeWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailMessageSubtypeId")]
    // [InverseProperty("MailMessageSubtype")]
    // public virtual ICollection<MailFollowers> MailFollowers { get; set; }
}
