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

[Table("crm_tag")]
//[Index("Name", Name = "crm_tag_name_uniq", IsUnique = true)]
public partial class CrmTag: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmTagCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmTagWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("CrmTagId")]
    //[InverseProperty("CrmTags")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequests { get; } = new List<CrmIapLeadMiningRequest>();

    [ForeignKey("TagId")]
    //[InverseProperty("Tags")]
    [NotMapped]
    public virtual ICollection<CrmLead> Leads { get; } = new List<CrmLead>();

    [ForeignKey("TagId")]
    //[InverseProperty("Tags")]
    [NotMapped]
    public virtual ICollection<SaleOrder> Orders { get; } = new List<SaleOrder>();
}
