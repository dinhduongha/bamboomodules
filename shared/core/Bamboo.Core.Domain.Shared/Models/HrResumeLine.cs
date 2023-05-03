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

[Table("hr_resume_line")]
public partial class HrResumeLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("line_type_id")]
    public long? LineTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("date_end")]
    public DateTime? DateEnd { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrResumeLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrResumeLines")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("LineTypeId")]
    //[InverseProperty("HrResumeLines")]
    [NotMapped]
    public virtual HrResumeLineType? LineType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrResumeLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
