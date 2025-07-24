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

[Table("utm_source")]
//[Index("Name", Name = "utm_source_unique_name", IsUnique = true)]
public partial class UtmSource: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("UtmSourceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("UtmSourceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Source")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    //[InverseProperty("Source")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } = new List<CrmLead>();

    //[InverseProperty("Source")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } = new List<HrApplicant>();

    //[InverseProperty("Source")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSources { get; set; } = new List<HrRecruitmentSource>();

    //[InverseProperty("Source")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

}
