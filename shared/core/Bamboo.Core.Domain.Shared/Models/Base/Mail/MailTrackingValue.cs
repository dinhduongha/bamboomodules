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

[Table("mail_tracking_value")]
//[Index("Field", Name = "mail_tracking_value_field_index")]
//[Index("MailMessageId", Name = "mail_tracking_value_mail_message_id_index")]
public partial class MailTrackingValue: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("field")]
    public Guid? Field { get; set; }

    [Column("old_value_integer")]
    public long? OldValueInteger { get; set; }

    [Column("new_value_integer")]
    public long? NewValueInteger { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("tracking_sequence")]
    public long? TrackingSequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("field_desc")]
    public string? FieldDesc { get; set; }

    [Column("field_type")]
    public string? FieldType { get; set; }

    [Column("old_value_char")]
    public string? OldValueChar { get; set; }

    [Column("new_value_char")]
    public string? NewValueChar { get; set; }

    [Column("old_value_text")]
    public string? OldValueText { get; set; }

    [Column("new_value_text")]
    public string? NewValueText { get; set; }

    [Column("old_value_datetime", TypeName = "timestamp without time zone")]
    public DateTime? OldValueDatetime { get; set; }

    [Column("new_value_datetime", TypeName = "timestamp without time zone")]
    public DateTime? NewValueDatetime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("old_value_float")]
    public double? OldValueFloat { get; set; }

    [Column("old_value_monetary")]
    public double? OldValueMonetary { get; set; }

    [Column("new_value_float")]
    public double? NewValueFloat { get; set; }

    [Column("new_value_monetary")]
    public double? NewValueMonetary { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailTrackingValueCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("MailTrackingValues")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("Field")]
    //[InverseProperty("MailTrackingValues")]
    [NotMapped]
    public virtual IrModelField? FieldNavigation { get; set; }

    [ForeignKey("MailMessageId")]
    //[InverseProperty("MailTrackingValues")]
    [NotMapped]
    public virtual MailMessage? MailMessage { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailTrackingValueWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
