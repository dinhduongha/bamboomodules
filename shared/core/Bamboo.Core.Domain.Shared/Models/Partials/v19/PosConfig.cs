using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class PosConfig
{
    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("order_seq_id")]
    public Guid? OrderSeqId { get; set; }

    [Column("order_backend_seq_id")]
    public Guid? OrderBackendSeqId { get; set; }

    [Column("order_line_seq_id")]
    public Guid? OrderLineSeqId { get; set; }

    [Column("device_seq_id")]
    public Guid? DeviceSeqId { get; set; }

    [Column("default_preset_id")]
    public Guid? DefaultPresetId { get; set; }

    [Column("fallback_nomenclature_id")]
    public Guid? FallbackNomenclatureId { get; set; }

    [Column("iface_group_by_categ")]
    public bool? IfaceGroupByCateg { get; set; }

    [Column("use_presets")]
    public bool? UsePresets { get; set; }

    [Column("module_pos_appointment")]
    public bool? ModulePosAppointment { get; set; }

    [Column("use_fast_payment")]
    public bool? UseFastPayment { get; set; }

    [Column("last_data_change", TypeName = "timestamp without time zone")]
    public DateTime? LastDataChange { get; set; }

    [Column("default_screen")]
    public string? DefaultScreen { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultPresetId")]
    public virtual PosPreset? DefaultPreset { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DeviceSeqId")]
    public virtual IrSequence? DeviceSeq { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FallbackNomenclatureId")]
    public virtual BarcodeNomenclature? FallbackNomenclature { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrderBackendSeqId")]
    public virtual IrSequence? OrderBackendSeq { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrderLineSeqId")]
    public virtual IrSequence? OrderLineSeq { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrderSeqId")]
    public virtual IrSequence? OrderSeq { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PosConfigId")] // Many2many // Normal
    // [InverseProperty("PosConfig1")] // Many2many // Normal
    public virtual ICollection<HrEmployee> HrEmployee1 { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("PosConfigId")] // Many2many // Normal
    // [InverseProperty("PosConfigNavigation")] // Many2many // Normal
    public virtual ICollection<IrAttachment> IrAttachmentNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PosConfigId")] // Many2many // Normal
    // [InverseProperty("PosConfig1")] // Many2many // Normal
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PosConfigId")] // Many2many // Normal
    // [InverseProperty("PosConfigNavigation")] // Many2many // Normal
    public virtual ICollection<PosPreset> PosPreset { get; set; }

    // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("ConfigId")] //Many2many // Hidden
    // // [InverseProperty("Config")] //Many2many // Hidden
    // public virtual ICollection<PosPrinter> Printer { get; set; }

}