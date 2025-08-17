using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class HrEmployeePublic: Entity<Guid>, IMultiTenant
{
    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("job_title", TypeName = "character varying")]
    public string? JobTitle { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("work_phone", TypeName = "character varying")]
    public string? WorkPhone { get; set; }

    [Column("mobile_phone", TypeName = "character varying")]
    public string? MobilePhone { get; set; }

    [Column("work_email", TypeName = "character varying")]
    public string? WorkEmail { get; set; }

    [Column("work_contact_id")]
    public Guid? WorkContactId { get; set; }

    [Column("work_location_id")]
    public Guid? WorkLocationId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("resource_id")]
    public Guid? ResourceId { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("coach_id")]
    public Guid? CoachId { get; set; }

    [Column("employee_type", TypeName = "character varying")]
    public string? EmployeeType { get; set; }

    [Column("leave_manager_id")]
    public Guid? LeaveManagerId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("id")]
    public Guid? Id { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("first_contract_date")]
    public DateTime? FirstContractDate { get; set; }

    [Column("mobility_card", TypeName = "character varying")]
    public string? MobilityCard { get; set; }

    [Column("expense_manager_id")]
    public Guid? ExpenseManagerId { get; set; }
}
