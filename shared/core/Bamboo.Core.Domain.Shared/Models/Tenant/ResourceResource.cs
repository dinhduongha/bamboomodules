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
public partial class ResourceResource: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("calendar_id")]
    public Guid? CalendarId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("resource_type")]
    public string? ResourceType { get; set; }

    [Column("tz")]
    public string? Tz { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("time_efficiency")]
    public double? TimeEfficiency { get; set; }

    [ForeignKey("CalendarId")]
    //[InverseProperty("ResourceResources")]
    [NotMapped]
    public virtual ResourceCalendar? Calendar { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ResourceResources")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResourceResourceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("ResourceResourceUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResourceResourceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Resource")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    //[InverseProperty("Resource")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; } = new List<MrpWorkcenter>();

    //[InverseProperty("Resource")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendances { get; } = new List<ResourceCalendarAttendance>();

    //[InverseProperty("Resource")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeaves { get; } = new List<ResourceCalendarLeaf>();

}
