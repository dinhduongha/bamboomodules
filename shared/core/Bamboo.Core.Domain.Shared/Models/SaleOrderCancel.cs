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

[Table("sale_order_cancel")]
//[Index("AuthorId", Name = "sale_order_cancel_author_id_index")]
public partial class SaleOrderCancel: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AuthorId")]
    //[InverseProperty("SaleOrderCancels")]
    [NotMapped]
    public virtual ResPartner? Author { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleOrderCancelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("OrderId")]
    //[InverseProperty("SaleOrderCancels")]
    [NotMapped]
    public virtual SaleOrder? Order { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("SaleOrderCancels")]
    [NotMapped]
    public virtual MailTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleOrderCancelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
