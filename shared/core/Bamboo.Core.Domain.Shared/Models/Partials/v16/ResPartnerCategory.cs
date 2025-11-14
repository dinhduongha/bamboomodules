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

//[Table("res_partner_category")]
//[Index("ParentId", Name = "res_partner_category_parent_id_index")]
//[Index("ParentPath", Name = "res_partner_category_parent_path_index")]
public partial class ResPartnerCategory
{

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerCategoryId")] //Many2many // Hidden
    // [InverseProperty("ResPartnerCategory")] //Many2many // Hidden
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplate { get; set; }

}
