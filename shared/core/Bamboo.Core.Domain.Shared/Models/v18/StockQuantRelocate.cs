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

[Table("stock_quant_relocate")]
public partial class StockQuantRelocate: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("dest_location_id")]
    public Guid? DestLocationId { get; set; }

    [Column("dest_package_id")]
    public Guid? DestPackageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("message")]
    public string? Message { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockQuantRelocateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DestLocationId")]
    //[InverseProperty("StockQuantRelocates")]
    [NotMapped]
    public virtual StockLocation? DestLocation { get; set; }

    [ForeignKey("DestPackageId")]
    //[InverseProperty("StockQuantRelocates")]
    [NotMapped]
    public virtual StockQuantPackage? DestPackage { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockQuantRelocateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("StockQuantRelocateId")]
    //[InverseProperty("StockQuantRelocates")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; set; } = new List<StockQuant>();
}
