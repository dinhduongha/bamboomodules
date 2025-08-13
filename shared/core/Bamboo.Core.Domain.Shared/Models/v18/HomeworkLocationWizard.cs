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

[Table("homework_location_wizard")]
public partial class HomeworkLocationWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("work_location_id")]
    public Guid? WorkLocationId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("weekly")]
    public bool? Weekly { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HomeworkLocationWizardCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HomeworkLocationWizards")] //Many2One
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("WorkLocationId")]
    //[InverseProperty("HomeworkLocationWizards")] //Many2One
    public virtual HrWorkLocation? WorkLocation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HomeworkLocationWizardWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
