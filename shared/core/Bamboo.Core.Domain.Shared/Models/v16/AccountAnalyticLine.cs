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
//[Index("AccountId", Name = "account_analytic_line_account_id_index")]
//[Index("Date", Name = "account_analytic_line_date_index")]
//[Index("MoveLineId", Name = "account_analytic_line_move_line_id_index")]
//[Index("OrderId", Name = "account_analytic_line_order_id_index")]
//[Index("ProjectId", Name = "account_analytic_line_project_id_index")]
//[Index("UserId", Name = "account_analytic_line_user_id_index")]
public partial class AccountAnalyticLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("plan_id")]
    public Guid? PlanId { get; set; }

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

    [Column("ancestor_task_id")]
    public Guid? AncestorTaskId { get; set; }

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
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual AccountAnalyticAccount? Account { get; set; }

    // [Many2one]
    [ForeignKey("AncestorTaskId")]
    // [InverseProperty("AccountAnalyticLineAncestorTask")] //Many2one
    public virtual ProjectTask? AncestorTask { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountAnalyticLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("AccountAnalyticLineEmployee")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("GeneralAccountId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual AccountAccount? GeneralAccount { get; set; }

    // [Many2one]
    [ForeignKey("GlobalLeaveId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual ResourceCalendarLeaves? GlobalLeave { get; set; }

    // [Many2one]
    [ForeignKey("HolidayId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual HrLeave? Holiday { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    // [InverseProperty("AccountAnalyticLineManager")] //Many2one
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [ForeignKey("MoveLineId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual AccountMoveLine? MoveLine { get; set; }

    // [One2many]
    [ForeignKey("MoAnalyticAccountLineId")]
    [InverseProperty("MoAnalyticAccountLine")]
    public virtual ICollection<MrpWorkorder> MrpWorkorderMoAnalyticAccountLine { get; set; }

    // [One2many]
    [ForeignKey("WcAnalyticAccountLineId")]
    [InverseProperty("WcAnalyticAccountLine")]
    public virtual ICollection<MrpWorkorder> MrpWorkorderWcAnalyticAccountLine { get; set; }

    // [Many2one]
    [ForeignKey("OrderId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual SaleOrder? Order { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PlanId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual AccountAnalyticPlan? Plan { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [ForeignKey("ProjectId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual ProjectProject? Project { get; set; }

    // [Many2one]
    [ForeignKey("SoLine")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual SaleOrderLine? SoLineNavigation { get; set; }

    // [One2many]
    [ForeignKey("AnalyticAccountLineId")]
    [InverseProperty("AnalyticAccountLine")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [Many2one]
    [ForeignKey("TaskId")]
    // [InverseProperty("AccountAnalyticLineTask")] //Many2one
    public virtual ProjectTask? Task { get; set; }

    // [Many2one]
    [ForeignKey("TimesheetInvoiceId")]
    // [InverseProperty("AccountAnalyticLine")] //Many2one
    public virtual AccountMove? TimesheetInvoice { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("AccountAnalyticLineUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountAnalyticLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
