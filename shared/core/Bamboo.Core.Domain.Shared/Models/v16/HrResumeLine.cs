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
//[Index("EmployeeId", Name = "hr_resume_line__employee_id_index")]
public partial class HrResumeLine : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("line_type_id")]
    public Guid? LineTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("date_end")]
    public DateTime? DateEnd { get; set; }

    // v16-Compat json
    //[Column("name")]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    // v16-Compat json
    //[Column("description")]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [Column("expiration_status")]
    public string? ExpirationStatus { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("HrResumeLines")]
    [NotMapped]
    public virtual SlideChannel? Channel { get; set; }


    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrResumeLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrResumeLines")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrResumeLines")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("LineTypeId")]
    //[InverseProperty("HrResumeLines")]
    [NotMapped]
    public virtual HrResumeLineType? LineType { get; set; }

    [ForeignKey("SurveyId")]
    //[InverseProperty("HrResumeLines")]
    [NotMapped]
    public virtual SurveySurvey? Survey { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrResumeLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
