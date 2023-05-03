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

[Table("sms_composer")]
public partial class SmsComposer: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("composition_mode")]
    public string? CompositionMode { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("res_ids")]
    public string? ResIds { get; set; }

    [Column("recipient_single_number_itf")]
    public string? RecipientSingleNumberItf { get; set; }

    [Column("number_field_name")]
    public string? NumberFieldName { get; set; }

    [Column("numbers")]
    public string? Numbers { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("mass_keep_log")]
    public bool? MassKeepLog { get; set; }

    [Column("mass_force_send")]
    public bool? MassForceSend { get; set; }

    [Column("mass_use_blacklist")]
    public bool? MassUseBlacklist { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SmsComposerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("SmsComposers")]
    [NotMapped]
    public virtual SmsTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SmsComposerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
