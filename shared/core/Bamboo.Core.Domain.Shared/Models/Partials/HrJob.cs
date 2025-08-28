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

//[Table("hr_job")]
//[Index("IsPublished", Name = "hr_job__is_published_index")]
//[Index("WebsiteId", Name = "hr_job__website_id_index")]
//[Index("Name", "CompanyId", "DepartmentId", Name = "hr_job_name_company_uniq", IsUnique = true)]
public partial class HrJob
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // v16-Compat
    //[Column("description")]
    //public string? Description { get; set; }

    //[Column("no_of_hired_employee")]
    //public long? NoOfHiredEmployee { get; set; }

    [Column("hr_responsible_id")]
    public Guid? HrResponsibleId { get; set; }

    // [Many2one]
    [ForeignKey("HrResponsibleId")]
    public virtual ResUsers? HrResponsible { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
