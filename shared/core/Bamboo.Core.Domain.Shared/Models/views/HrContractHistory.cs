using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class HrContractHistory: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("active_employee")]
    public bool? ActiveEmployee { get; set; }

    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("is_under_contract")]
    public bool? IsUnderContract { get; set; }

    [Column("date_hired")]
    public DateTime? DateHired { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("date_end")]
    public DateTime? DateEnd { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("structure_type_id")]
    public Guid? StructureTypeId { get; set; }

    [Column("hr_responsible_id")]
    public Guid? HrResponsibleId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("wage")]
    public decimal? Wage { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("contract_type_id")]
    public Guid? ContractTypeId { get; set; }
}
