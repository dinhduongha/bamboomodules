using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class TimesheetsAnalysisReport: IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("task_id")]
    public Guid? TaskId { get; set; }

    [Column("parent_task_id")]
    public Guid? ParentTaskId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("unit_amount")]
    public double? UnitAmount { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("so_line")]
    public Guid? SoLine { get; set; }

    [Column("timesheet_invoice_type", TypeName = "character varying")]
    public string? TimesheetInvoiceType { get; set; }

    [Column("timesheet_invoice_id")]
    public Guid? TimesheetInvoiceId { get; set; }

    [Column("timesheet_revenues")]
    public double? TimesheetRevenues { get; set; }

    [Column("billable_time")]
    public double? BillableTime { get; set; }

    [Column("margin")]
    public double? Margin { get; set; }

    [Column("non_billable_time")]
    public double? NonBillableTime { get; set; }
}
