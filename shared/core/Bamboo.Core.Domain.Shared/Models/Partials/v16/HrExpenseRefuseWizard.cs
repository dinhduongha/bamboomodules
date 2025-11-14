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

//[Table("hr_expense_refuse_wizard")]
public partial class HrExpenseRefuseWizard
{
    [Column("hr_expense_sheet_id")]
    public Guid? HrExpenseSheetId { get; set; }

    // [Many2one]
    //[ForeignKey("HrExpenseSheetId")]
    //public virtual HrExpenseSheet? HrExpenseSheet { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("HrExpenseRefuseWizardId")] // Many2many // Normal
    // [InverseProperty("HrExpenseRefuseWizard")] // Many2many // Normal
    public virtual ICollection<HrExpense> HrExpense { get; set; }
}
