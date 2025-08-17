using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class VendorDelayReport
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("purchase_line_id")]
    public Guid? PurchaseLineId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("qty_total")]
    public decimal? QtyTotal { get; set; }

    [Column("qty_on_time")]
    public decimal? QtyOnTime { get; set; }
}
