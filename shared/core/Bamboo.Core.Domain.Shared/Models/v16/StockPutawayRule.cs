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
//[Index("CompanyId", Name = "stock_putaway_rule__company_id_index")]
//[Index("LocationInId", Name = "stock_putaway_rule__location_in_id_index")]
public partial class StockPutawayRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("location_in_id")]
    public Guid? LocationInId { get; set; }

    [Column("location_out_id")]
    public Guid? LocationOutId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("storage_category_id")]
    public Guid? StorageCategoryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("sublocation")]
    public string? Sublocation { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("StockPutawayRule")] //Many2one
    public virtual ProductCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockPutawayRule")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockPutawayRuleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationInId")]
    // [InverseProperty("StockPutawayRuleLocationIn")] //Many2one
    public virtual StockLocation? LocationIn { get; set; }

    // [Many2one]
    [ForeignKey("LocationOutId")]
    // [InverseProperty("StockPutawayRuleLocationOut")] //Many2one
    public virtual StockLocation? LocationOut { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockPutawayRule")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("StorageCategoryId")]
    // [InverseProperty("StockPutawayRule")] //Many2one
    public virtual StockStorageCategory? StorageCategory { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockPutawayRuleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("StockPutawayRuleId")] //Many2many
    // [InverseProperty("StockPutawayRule")] //Many2many
    public virtual ICollection<StockPackageType> StockPackageType { get; set; }
}
