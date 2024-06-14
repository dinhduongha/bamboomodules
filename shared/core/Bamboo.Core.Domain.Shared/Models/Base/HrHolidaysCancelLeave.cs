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

[Table("hr_holidays_cancel_leave")]
public partial class HrHolidaysCancelLeave: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("leave_id")]
    public Guid? LeaveId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("reason")]
    public string? Reason { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrHolidaysCancelLeaveCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LeaveId")]
    //[InverseProperty("HrHolidaysCancelLeaves")]
    [NotMapped]
    public virtual HrLeave? Leave { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrHolidaysCancelLeaveWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
