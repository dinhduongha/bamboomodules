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

[Table("sms_template_preview")]
public partial class SmsTemplatePreview: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("resource_ref")]
    public string? ResourceRef { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SmsTemplatePreviewCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SmsTemplateId")]
    //[InverseProperty("SmsTemplatePreviews")]
    [NotMapped]
    public virtual SmsTemplate? SmsTemplate { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SmsTemplatePreviewWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
