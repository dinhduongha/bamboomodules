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

//[Table("account_group")]
//[Index("ParentId", Name = "account_group__parent_id_index")]
//[Index("ParentPath", Name = "account_group_parent_path_index")]
public partial class AccountGroup
{
    [Column("parent_path")]
    public string? ParentPath { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("GroupId")]
    [NotMapped] // One2many // Peer relationship (AccountAccount) is commented out
    // [InverseProperty("Group")] // One2many
    public virtual ICollection<AccountAccount> AccountAccount { get; set; }
}
