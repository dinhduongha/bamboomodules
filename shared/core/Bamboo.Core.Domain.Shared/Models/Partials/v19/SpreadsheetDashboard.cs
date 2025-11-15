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

public partial class SpreadsheetDashboard
{
    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCompany) is commented out
    // [ForeignKey("SpreadsheetDashboardId")] // Many2many // Normal
    // [InverseProperty("SpreadsheetDashboard")] // Many2many // Normal
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("SpreadsheetDashboardId")] // Many2many // Normal
    // [InverseProperty("SpreadsheetDashboard")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }

}