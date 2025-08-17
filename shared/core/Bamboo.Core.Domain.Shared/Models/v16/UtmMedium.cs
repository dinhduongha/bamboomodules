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

[Table("utm_medium")]
//[Index("Name", Name = "utm_medium_unique_name", IsUnique = true)]
public partial class UtmMedium: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("MediumId")]
    [InverseProperty("Medium")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("UtmMediumCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("MediumId")]
    [InverseProperty("Medium")]
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [ForeignKey("UtmMediumId")]
    [InverseProperty("UtmMedium")]
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many]
    [ForeignKey("MediumId")]
    [InverseProperty("Medium")]
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [ForeignKey("MediumId")]
    [InverseProperty("Medium")]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSource { get; set; }

    // [One2many]
    [ForeignKey("MediumId")]
    [InverseProperty("Medium")]
    public virtual ICollection<LinkTracker> LinkTracker { get; set; }

    // [One2many]
    [ForeignKey("MediumId")]
    [InverseProperty("Medium")]
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [One2many]
    [ForeignKey("MediumId")]
    [InverseProperty("Medium")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("UtmMediumWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
