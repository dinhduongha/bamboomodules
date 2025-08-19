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

[Table("hr_attendance")]
//[Index("EmployeeId", Name = "hr_attendance__employee_id_index")]
public partial class HrAttendance: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("overtime_status")]
    public string? OvertimeStatus { get; set; }

    [Column("in_country_name")]
    public string? InCountryName { get; set; }

    [Column("in_city")]
    public string? InCity { get; set; }

    [Column("in_ip_address")]
    public string? InIpAddress { get; set; }

    [Column("in_browser")]
    public string? InBrowser { get; set; }

    [Column("in_mode")]
    public string? InMode { get; set; }

    [Column("out_country_name")]
    public string? OutCountryName { get; set; }

    [Column("out_city")]
    public string? OutCity { get; set; }

    [Column("out_ip_address")]
    public string? OutIpAddress { get; set; }

    [Column("out_browser")]
    public string? OutBrowser { get; set; }

    [Column("out_mode")]
    public string? OutMode { get; set; }

    [Column("in_latitude")]
    public decimal? InLatitude { get; set; }

    [Column("in_longitude")]
    public decimal? InLongitude { get; set; }

    [Column("out_latitude")]
    public decimal? OutLatitude { get; set; }

    [Column("out_longitude")]
    public decimal? OutLongitude { get; set; }

    [Column("check_in", TypeName = "timestamp without time zone")]
    public DateTime? CheckIn { get; set; }

    [Column("check_out", TypeName = "timestamp without time zone")]
    public DateTime? CheckOut { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("worked_hours")]
    public double? WorkedHours { get; set; }

    [Column("overtime_hours")]
    public double? OvertimeHours { get; set; }

    [Column("validated_overtime_hours")]
    public double? ValidatedOvertimeHours { get; set; }

    [Column("expected_hours")]
    public double? ExpectedHours { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrAttendanceCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrAttendance")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    [ForeignKey("LastAttendanceId")]
    [InverseProperty("LastAttendance")]
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrAttendanceWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
