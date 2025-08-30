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

//[Table("website_menu")]
//[Index("ParentId", Name = "website_menu__parent_id_index")]
//[Index("ParentPath", Name = "website_menu__parent_path_index")]
public partial class WebsiteMenu
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MenuId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Menu")] // One2many
    public virtual ICollection<ForumForum> ForumForum { get; set; }
}
