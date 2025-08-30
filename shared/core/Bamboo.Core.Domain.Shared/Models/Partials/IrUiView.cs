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

//[Table("ir_ui_view")]
//[Index("InheritId", Name = "ir_ui_view__inherit_id_index")]
//[Index("Model", Name = "ir_ui_view__model_index")]
//[Index("Model", "InheritId", Name = "ir_ui_view_model_type_inherit_id")]
public partial class IrUiView
{
    [Column("field_parent")]
    public string? FieldParent { get; set; }
}
