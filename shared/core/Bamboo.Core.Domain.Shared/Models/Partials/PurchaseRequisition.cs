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

//[Table("purchase_requisition")]
//[Index("ScheduleDate", Name = "purchase_requisition_schedule_date_index")]
public partial class PurchaseRequisition
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("type_id")]
    public Guid? TypeId { get; set; }

    [Column("origin")]
    public string? Origin { get; set; }

    [Column("ordering_date")]
    public DateTime? OrderingDate { get; set; }

    [Column("schedule_date")]
    public DateTime? ScheduleDate { get; set; }

    // v16-Compat
    //[Column("date_end", TypeName = "timestamp without time zone")]
    //public DateTime? DateEnd { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("TypeId")]
    public virtual PurchaseRequisitionType? Type { get; set; }

}
