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

//[Table("hr_expense")]
//[Index("State", Name = "hr_expense_state_index")]
public partial class HrExpense
{
    [Column("reference")]
    public string? Reference { get; set; }

    [Column("unit_amount")]
    public decimal? UnitAmount { get; set; }

    [Column("amount_tax")]
    public decimal? AmountTax { get; set; }

    [Column("amount_tax_company")]
    public decimal? AmountTaxCompany { get; set; }

    [Column("untaxed_amount")]
    public decimal? UntaxedAmount { get; set; }

    [Column("total_amount_company")]
    public decimal? TotalAmountCompany { get; set; }

    [Column("is_refused")]
    public bool? IsRefused { get; set; }

    [Column("sample")]
    public bool? Sample { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrExpenseId")] //Many2many // Hidden
    // [InverseProperty("HrExpense")] //Many2many // Hidden
    public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizard { get; set; }
}
