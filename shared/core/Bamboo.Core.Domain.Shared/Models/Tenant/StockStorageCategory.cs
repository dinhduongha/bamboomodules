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

[Table("stock_storage_category")]
public partial class StockStorageCategory: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
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

    [Column("allow_new_product")]
    public string? AllowNewProduct { get; set; }

    [Column("max_weight")]
    public decimal? MaxWeight { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockStorageCategories")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockStorageCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockStorageCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("StorageCategory")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocations { get; } = new List<StockLocation>();

    //[InverseProperty("StorageCategory")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; } = new List<StockPutawayRule>();

    //[InverseProperty("StorageCategory")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; } = new List<StockQuant>();

    //[InverseProperty("StorageCategory")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacities { get; } = new List<StockStorageCategoryCapacity>();
}
