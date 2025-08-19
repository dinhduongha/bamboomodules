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

[Table("hr_expense_refuse_wizard")]
public partial class HrExpenseRefuseWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    
    //v16-Compat
    [Column("hr_expense_sheet_id")]
    public Guid? HrExpenseSheetId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("reason")]
    public string? Reason { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrExpenseRefuseWizardCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("HrExpenseSheetId")]
    [InverseProperty("HrExpenseRefuseWizard")] //Many2one
    public virtual HrExpenseSheet? HrExpenseSheet { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrExpenseRefuseWizardWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // v16-Compat
    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrExpenseRefuseWizardId")] //Many2many
    // [InverseProperty("HrExpenseRefuseWizard")] //Many2many
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [Many2many] // Normal
    [NotMapped] //Many2many // Normal
    // [ForeignKey("HrExpenseRefuseWizardId")] //Many2many
    // [InverseProperty("HrExpenseRefuseWizard")] //Many2many
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; }
}
