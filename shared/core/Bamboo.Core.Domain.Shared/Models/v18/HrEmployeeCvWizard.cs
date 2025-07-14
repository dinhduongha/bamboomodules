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

[Table("hr_employee_cv_wizard")]
public partial class HrEmployeeCvWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("color_primary")]
    public string? ColorPrimary { get; set; }

    [Column("color_secondary")]
    public string? ColorSecondary { get; set; }

    [Column("show_skills")]
    public bool? ShowSkills { get; set; }

    [Column("show_contact")]
    public bool? ShowContact { get; set; }

    [Column("show_others")]
    public bool? ShowOthers { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrEmployeeCvWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrEmployeeCvWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("HrEmployeeCvWizardId")]
    //[InverseProperty("HrEmployeeCvWizards")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } = new List<HrEmployee>();
}
