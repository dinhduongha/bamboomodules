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

[Table("followup_followup")]
//[Index("TenantId", Name = "followup_followup_company_uniq", IsUnique = true)]
public partial class FollowupFollowup: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
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

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("FollowupFollowup")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FollowupFollowupCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FollowupFollowupWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
    
    //[InverseProperty("Followup")]
    [NotMapped]
    public virtual ICollection<FollowupLine> FollowupLines { get; } = new List<FollowupLine>();

    //[InverseProperty("Followup")]
    [NotMapped]
    public virtual ICollection<FollowupPrint> FollowupPrints { get; } = new List<FollowupPrint>();

}
