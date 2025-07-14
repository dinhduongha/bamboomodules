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

[Table("mail_activity_plan")]
public partial class MailActivityPlan: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("MailActivityPlans")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailActivityPlanCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("MailActivityPlans")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    //[InverseProperty("Plan")]
    [NotMapped]
    public virtual ICollection<MailActivityPlanTemplate> MailActivityPlanTemplates { get; set; } = new List<MailActivityPlanTemplate>();

    //[InverseProperty("Plan")]
    [NotMapped]
    public virtual ICollection<MailActivitySchedule> MailActivitySchedulesNavigation { get; set; } = new List<MailActivitySchedule>();

    [ForeignKey("ResModelId")]
    //[InverseProperty("MailActivityPlans")]
    [NotMapped]
    public virtual IrModel? ResModelNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailActivityPlanWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("MailActivityPlanId")]
    //[InverseProperty("MailActivityPlans")]
    [NotMapped]
    public virtual ICollection<MailActivitySchedule> MailActivitySchedules { get; set; } = new List<MailActivitySchedule>();
}
