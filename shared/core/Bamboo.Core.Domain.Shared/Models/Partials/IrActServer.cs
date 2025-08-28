using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("ir_act_server")]
//[Index("ModelId", Name = "ir_act_server__model_id_index")]
public partial class IrActServer
{
    // [One2many]
    // [One2many] [ForeignKey("ActionServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ActionServer")] // One2many
    // public virtual ICollection<BaseAutomation> BaseAutomation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ServerId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Server")] // One2many
    public virtual ICollection<IrServerObjectLines> IrServerObjectLines { get; set; }
}
