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

[Table("stock_putaway_rule")]
//[Index("TenantId", Name = "stock_putaway_rule_company_id_index")]
//[Index("LocationInId", Name = "stock_putaway_rule_location_in_id_index")]
public partial class StockPutawayRule: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("category_id")]
    public long? CategoryId { get; set; }

    [Column("location_in_id")]
    public Guid? LocationInId { get; set; }

    [Column("location_out_id")]
    public Guid? LocationOutId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("storage_category_id")]
    public Guid? StorageCategoryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("StockPutawayRules")]
    [NotMapped]
    public virtual ProductCategory? Category { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockPutawayRules")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockPutawayRuleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationInId")]
    //[InverseProperty("StockPutawayRuleLocationIns")]
    [NotMapped]
    public virtual StockLocation? LocationIn { get; set; }

    [ForeignKey("LocationOutId")]
    //[InverseProperty("StockPutawayRuleLocationOuts")]
    [NotMapped]
    public virtual StockLocation? LocationOut { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockPutawayRules")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("StorageCategoryId")]
    //[InverseProperty("StockPutawayRules")]
    [NotMapped]
    public virtual StockStorageCategory? StorageCategory { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockPutawayRuleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("StockPutawayRuleId")]
    //[InverseProperty("StockPutawayRules")]
    [NotMapped]
    public virtual ICollection<StockPackageType> StockPackageTypes { get; } = new List<StockPackageType>();
}
