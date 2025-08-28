using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_department")]
//[Index("CompanyId", Name = "hr_department__company_id_index")]
//[Index("ParentId", Name = "hr_department__parent_id_index")]
//[Index("ParentPath", Name = "hr_department__parent_path_index")]
public partial class HrDepartment
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // v16-Compat
    //[Column("name")]
    //public string? Name { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("DepartmentId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrPlan> HrPlan { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrDepartmentId")] //Many2many // Hidden
    // [InverseProperty("HrDepartment")] //Many2many // Hidden
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDay { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrDepartmentId")] //Many2many // Hidden
    // [InverseProperty("HrDepartment")] //Many2many // Hidden
    public virtual ICollection<MailChannel> MailChannel { get; set; }
}
