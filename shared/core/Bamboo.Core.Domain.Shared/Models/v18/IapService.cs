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

[Table("iap_service")]
//[Index("TechnicalName", Name = "iap_service_unique_technical_name", IsUnique = true)]
public partial class IapService: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("name")]
    public string? Name { get; set; }

    [Column("technical_name")]
    public string? TechnicalName { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("unit_name", TypeName = "jsonb")]
    public string? UnitName { get; set; }

    [Column("integer_balance")]
    public bool? IntegerBalance { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IapServiceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Service")]
    [NotMapped]
    public virtual ICollection<IapAccount> IapAccounts { get; set; } = new List<IapAccount>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IapServiceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
