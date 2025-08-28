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

//[Table("stock_return_picking")]
public partial class StockReturnPicking
{
    [Column("original_location_id")]
    public Guid? OriginalLocationId { get; set; }

    [Column("parent_location_id")]
    public Guid? ParentLocationId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("move_dest_exists")]
    public bool? MoveDestExists { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("OriginalLocationId")]
    public virtual StockLocation? OriginalLocation { get; set; }

    // [Many2one]
    [ForeignKey("ParentLocationId")]
    public virtual StockLocation? ParentLocation { get; set; }
}
