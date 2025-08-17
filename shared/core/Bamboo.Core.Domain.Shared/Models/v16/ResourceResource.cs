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

[Table("resource_resource")]
public partial class ResourceResource: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("calendar_id")]
    public Guid? CalendarId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("resource_type")]
    public string? ResourceType { get; set; }

    [Column("tz")]
    public string? Tz { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("time_efficiency")]
    public double? TimeEfficiency { get; set; }

    // [Many2one]
    [ForeignKey("CalendarId")]
    // [InverseProperty("ResourceResource")] //Many2one
    public virtual ResourceCalendar? Calendar { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ResourceResource")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResourceResourceCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ResourceId")]
    [InverseProperty("Resource")]
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many]
    [ForeignKey("ResourceId")]
    [InverseProperty("Resource")]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [One2many]
    [ForeignKey("ResourceId")]
    [InverseProperty("Resource")]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendance { get; set; }

    // [One2many]
    [ForeignKey("ResourceId")]
    [InverseProperty("Resource")]
    public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("ResourceResourceUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResourceResourceWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
