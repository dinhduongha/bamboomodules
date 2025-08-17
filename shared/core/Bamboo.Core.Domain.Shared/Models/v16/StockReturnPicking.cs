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

[Table("stock_return_picking")]
public partial class StockReturnPicking: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("original_location_id")]
    public Guid? OriginalLocationId { get; set; }

    [Column("parent_location_id")]
    public Guid? ParentLocationId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("move_dest_exists")]
    public bool? MoveDestExists { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockReturnPickingCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("StockReturnPickingLocation")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("OriginalLocationId")]
    // [InverseProperty("StockReturnPickingOriginalLocation")] //Many2one
    public virtual StockLocation? OriginalLocation { get; set; }

    // [Many2one]
    [ForeignKey("ParentLocationId")]
    // [InverseProperty("StockReturnPickingParentLocation")] //Many2one
    public virtual StockLocation? ParentLocation { get; set; }

    // [Many2one]
    [ForeignKey("PickingId")]
    // [InverseProperty("StockReturnPicking")] //Many2one
    public virtual StockPicking? Picking { get; set; }

    // [One2many]
    [ForeignKey("WizardId")]
    [InverseProperty("Wizard")]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockReturnPickingWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
