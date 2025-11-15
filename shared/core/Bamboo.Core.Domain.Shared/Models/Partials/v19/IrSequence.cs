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

public partial class IrSequence
{
    //CONFLICK
    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("CheckSequenceId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("CheckSequence")] // One2many
    // public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WithholdingSequenceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WithholdingSequence")] // One2many
    public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SequenceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SequenceNavigation")] // One2many
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DeviceSeqId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DeviceSeq")] // One2many
    public virtual ICollection<PosConfig> PosConfigDeviceSeq { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderBackendSeqId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OrderBackendSeq")] // One2many
    public virtual ICollection<PosConfig> PosConfigOrderBackendSeq { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderLineSeqId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OrderLineSeq")] // One2many
    public virtual ICollection<PosConfig> PosConfigOrderLineSeq { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderSeqId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OrderSeq")] // One2many
    public virtual ICollection<PosConfig> PosConfigOrderSeq { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotSequenceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LotSequence")] // One2many
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SequenceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SequenceNavigation")] // One2many
    public virtual ICollection<StockPackageType> StockPackageType { get; set; }

}