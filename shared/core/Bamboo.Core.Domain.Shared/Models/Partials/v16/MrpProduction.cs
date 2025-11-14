using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("mrp_production")]
//[Index("CompanyId", Name = "mrp_production__company_id_index")]
//[Index("DatePlannedStart", Name = "mrp_production_date_planned_start_index")]
//[Index("PickingTypeId", Name = "mrp_production__picking_type_id_index")]
//[Index("ReservationState", Name = "mrp_production__reservation_state_index")]
//[Index("State", Name = "mrp_production__state_index")]
//[Index("Name", "CompanyId", Name = "mrp_production_name_uniq", IsUnique = true)]
public partial class MrpProduction
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("date_planned_start", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedStart { get; set; }

    [Column("date_planned_finished", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedFinished { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<StockAssignSerial> StockAssignSerial { get; set; }

    // [Many2many] // Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    // public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarning { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<MrpImmediateProduction> MrpImmediateProduction { get; set; }
}
