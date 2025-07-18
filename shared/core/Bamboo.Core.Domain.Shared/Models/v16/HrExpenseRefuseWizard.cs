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
public partial class HrExpenseRefuseWizard : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("hr_expense_sheet_id")]
    public Guid? HrExpenseSheetId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("reason")]
    public string? Reason { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrExpenseRefuseWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }


    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrExpenseRefuseWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    // v16-Compat
    //[ForeignKey("HrExpenseSheetId")]
    //[InverseProperty("HrExpenseRefuseWizards")]
    //[NotMapped]
    //public virtual HrExpenseSheet? HrExpenseSheet { get; set; }

    // v16-Compat
    //[ForeignKey("HrExpenseRefuseWizardId")]
    //[InverseProperty("HrExpenseRefuseWizards")]
    //public virtual ICollection<HrExpense> HrExpenses { get; set; } = new List<HrExpense>();

    [ForeignKey("HrExpenseRefuseWizardId")]
    //[InverseProperty("HrExpenseRefuseWizards")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; } = new List<HrExpenseSheet>();
}
