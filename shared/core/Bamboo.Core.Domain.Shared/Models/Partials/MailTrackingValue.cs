using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("mail_tracking_value")]
//[Index("Field", Name = "mail_tracking_value__field_index")]
//[Index("MailMessageId", Name = "mail_tracking_value__mail_message_id_index")]
public partial class MailTrackingValue
{
    // v16-Compat    
    //[Column("field")]
    //public Guid? Field { get; set; }

    [Column("tracking_sequence")]
    public long? TrackingSequence { get; set; }

    [Column("field_desc")]
    public string? FieldDesc { get; set; }

    [Column("field_type")]
    public string? FieldType { get; set; }

    [Column("old_value_monetary")]
    public double? OldValueMonetary { get; set; }

    [Column("new_value_monetary")]
    public double? NewValueMonetary { get; set; }

    // [Many2one]
    [ForeignKey("Field")]
    public virtual IrModelFields? FieldNavigation { get; set; }
}
