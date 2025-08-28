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

//[Table("ir_model_fields")]
//[Index("CompleteName", Name = "ir_model_fields__complete_name_index")]
//[Index("ModelId", Name = "ir_model_fields__model_id_index")]
//[Index("Model", Name = "ir_model_fields__model_index")]
//[Index("Name", Name = "ir_model_fields__name_index")]
//[Index("State", Name = "ir_model_fields__state_index")]
//[Index("WebsiteFormBlacklisted", Name = "ir_model_fields__website_form_blacklisted_index")]
//[Index("Model", "Name", Name = "ir_model_fields_name_unique", IsUnique = true)]
public partial class IrModelFields
{

    // [One2many]
    // [One2many] [ForeignKey("LinkFieldId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("LinkField")] // One2many
    public virtual ICollection<IrActServer> IrActServer { get; set; }


    // [One2many]
    // [One2many] [ForeignKey("FieldsId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Fields")] // One2many
    public virtual ICollection<IrProperty> IrProperty { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("Col1")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Col1Navigation")] // One2many
    public virtual ICollection<IrServerObjectLines> IrServerObjectLines { get; set; }

    // v16-Compat
    // [One2many]
    // [One2many] [ForeignKey("Field")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FieldNavigation")] // One2many
    // public virtual ICollection<MailTrackingValue> MailTrackingValue { get; set; }
}
