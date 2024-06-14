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

[Table("account_payment_term_line")]
//[Index("PaymentId", Name = "account_payment_term_line_payment_id_index")]
public partial class AccountPaymentTermLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("months")]
    public long? Months { get; set; }

    [Column("days")]
    public long? Days { get; set; }

    [Column("days_after")]
    public long? DaysAfter { get; set; }

    [Column("discount_days")]
    public long? DiscountDays { get; set; }

    [Column("payment_id")]
    public Guid? PaymentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("value")]
    public string? Value { get; set; }

    [Column("value_amount")]
    public decimal? ValueAmount { get; set; }

    [Column("end_month")]
    public bool? EndMonth { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("discount_percentage")]
    public double? DiscountPercentage { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountPaymentTermLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PaymentId")]
    //[InverseProperty("AccountPaymentTermLines")]
    [NotMapped]
    public virtual AccountPaymentTerm? Payment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountPaymentTermLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
