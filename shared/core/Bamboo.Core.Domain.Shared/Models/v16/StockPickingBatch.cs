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

[Table("stock_picking_batch")]
//[Index("CompanyId", Name = "stock_picking_batch_company_id_index")]
//[Index("PickingTypeId", Name = "stock_picking_batch_picking_type_id_index")]
//[Index("State", Name = "stock_picking_batch_state_index")]
public partial class StockPickingBatch: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("is_wave")]
    public bool? IsWave { get; set; }

    [Column("scheduled_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduledDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockPickingBatch")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockPickingBatchCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("StockPickingBatch")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("StockPickingBatch")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [One2many]
    [ForeignKey("WaveId")]
    [InverseProperty("Wave")]
    public virtual ICollection<StockAddToWave> StockAddToWave { get; set; }

    // [One2many]
    [ForeignKey("BatchId")]
    [InverseProperty("Batch")]
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [ForeignKey("BatchId")]
    [InverseProperty("Batch")]
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many]
    [ForeignKey("BatchId")]
    [InverseProperty("Batch")]
    public virtual ICollection<StockPickingToBatch> StockPickingToBatch { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("StockPickingBatchUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockPickingBatchWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
