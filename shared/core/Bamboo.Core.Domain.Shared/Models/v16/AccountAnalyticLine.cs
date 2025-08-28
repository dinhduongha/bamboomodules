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

[Table("account_analytic_line")]
//[Index("AccountId", Name = "account_analytic_line__account_id_index")]
//[Index("Date", Name = "account_analytic_line__date_index")]
//[Index("EmployeeId", Name = "account_analytic_line__employee_id_index")]
//[Index("MoveLineId", Name = "account_analytic_line__move_line_id_index")]
//[Index("OrderId", Name = "account_analytic_line__order_id_index")]
//[Index("ProjectId", Name = "account_analytic_line__project_id_index")]
//[Index("UserId", Name = "account_analytic_line__user_id_index")]
public partial class AccountAnalyticLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("unit_amount")]
    public double? UnitAmount { get; set; }

    [Column("x_plan2_id")]
    public Guid? XPlan2Id { get; set; }

    [Column("x_plan3_id")]
    public Guid? XPlan3Id { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("general_account_id")]
    public Guid? GeneralAccountId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("move_line_id")]
    public Guid? MoveLineId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [Column("so_line")]
    public Guid? SoLine { get; set; }

    [Column("task_id")]
    public Guid? TaskId { get; set; }

    [Column("parent_task_id")]
    public Guid? ParentTaskId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("holiday_id")]
    public Guid? HolidayId { get; set; }

    [Column("global_leave_id")]
    public Guid? GlobalLeaveId { get; set; }

    [Column("timesheet_invoice_id")]
    public Guid? TimesheetInvoiceId { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("timesheet_invoice_type")]
    public string? TimesheetInvoiceType { get; set; }

    [Column("is_so_line_edited")]
    public bool? IsSoLineEdited { get; set; }

    // [Many2one]
    [ForeignKey("AccountId")]
    public virtual AccountAnalyticAccount? Account { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("GeneralAccountId")]
    public virtual AccountAccount? GeneralAccount { get; set; }

    // [Many2one]
    [ForeignKey("GlobalLeaveId")]
    public virtual ResourceCalendarLeaves? GlobalLeave { get; set; }

    // [Many2one]
    [ForeignKey("HolidayId")]
    public virtual HrLeave? Holiday { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [ForeignKey("MoveLineId")]
    public virtual AccountMoveLine? MoveLine { get; set; }

    // [Many2one]
    [ForeignKey("OrderId")]
    public virtual SaleOrder? Order { get; set; }

    // [Many2one]
    [ForeignKey("ParentTaskId")]
    public virtual ProjectTask? ParentTask { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [ForeignKey("ProjectId")]
    public virtual ProjectProject? Project { get; set; }

    // [Many2one]
    [ForeignKey("SoLine")]
    public virtual SaleOrderLine? SoLineNavigation { get; set; }

    // [Many2one]
    [ForeignKey("TaskId")]
    public virtual ProjectTask? Task { get; set; }

    // [Many2one]
    [ForeignKey("TimesheetInvoiceId")]
    public virtual AccountMove? TimesheetInvoice { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2one]
    [ForeignKey("XPlan2Id")]
    public virtual AccountAnalyticAccount? XPlan2 { get; set; }

    // [Many2one]
    [ForeignKey("XPlan3Id")]
    public virtual AccountAnalyticAccount? XPlan3 { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticLineId")] //Many2many // Hidden
    // [InverseProperty("AccountAnalyticLine")] //Many2many // Hidden
    public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticLineId")] //Many2many // Hidden
    // [InverseProperty("AccountAnalyticLineNavigation")] //Many2many // Hidden
    public virtual ICollection<MrpWorkorder> MrpWorkorderNavigation { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticLineId")] //Many2many // Hidden
    // [InverseProperty("AccountAnalyticLine")] //Many2many // Hidden
    public virtual ICollection<StockMove> StockMove { get; set; }
}
