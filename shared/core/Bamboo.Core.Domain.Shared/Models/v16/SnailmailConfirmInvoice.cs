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

[Table("snailmail_confirm_invoice")]
public partial class SnailmailConfirmInvoice: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("invoice_send_id")]
    public Guid? InvoiceSendId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("model_name")]
    public string? ModelName { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SnailmailConfirmInvoiceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("InvoiceSendId")]
    //[InverseProperty("SnailmailConfirmInvoices")]
    [NotMapped]
    public virtual AccountInvoiceSend? InvoiceSend { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SnailmailConfirmInvoiceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
