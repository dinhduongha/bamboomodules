using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("account_payment_term_line")]
//[Index("PaymentId", Name = "account_payment_term_line__payment_id_index")]
public partial class AccountPaymentTermLine
{

    [Column("months")]
    public long? Months { get; set; }

    [Column("days")]
    public long? Days { get; set; }

    [Column("days_after")]
    public long? DaysAfter { get; set; }

    [Column("discount_days")]
    public long? DiscountDays { get; set; }

    [Column("end_month")]
    public bool? EndMonth { get; set; }

    [Column("discount_percentage")]
    public double? DiscountPercentage { get; set; }

}
