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

//[Table("payment_transaction")]
//[Index("CompanyId", Name = "payment_transaction__company_id_index")]
//[Index("Operation", Name = "payment_transaction__operation_index")]
//[Index("State", Name = "payment_transaction__state_index")]
//[Index("Reference", Name = "payment_transaction_reference_uniq", IsUnique = true)]
public partial class PaymentTransaction
{
    [Column("callback_model_id")]
    public Guid? CallbackModelId { get; set; }

    [Column("callback_res_id")]
    public Guid? CallbackResId { get; set; }

    [Column("callback_method")]
    public string? CallbackMethod { get; set; }

    [Column("callback_hash")]
    public string? CallbackHash { get; set; }

    [Column("fees")]
    public decimal? Fees { get; set; }

    [Column("callback_is_done")]
    public bool? CallbackIsDone { get; set; }

    // [Many2one]
    [ForeignKey("CallbackModelId")]
    public virtual IrModel? CallbackModel { get; set; }
}
