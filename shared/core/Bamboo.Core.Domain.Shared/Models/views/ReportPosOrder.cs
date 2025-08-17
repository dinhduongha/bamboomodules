using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class ReportPosOrder
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("nbr_lines")]
    public long? NbrLines { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("price_sub_total")]
    public decimal? PriceSubTotal { get; set; }

    [Column("price_total")]
    public decimal? PriceTotal { get; set; }

    [Column("total_discount")]
    public decimal? TotalDiscount { get; set; }

    [Column("average_price")]
    public decimal? AveragePrice { get; set; }

    [Column("delay_validation")]
    public long? DelayValidation { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("company_id")]
    public Guid? CompanyId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_categ_id")]
    public Guid? ProductCategId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("config_id")]
    public Guid? ConfigId { get; set; }

    [Column("pos_categ_id")]
    public Guid? PosCategId { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("session_id")]
    public Guid? SessionId { get; set; }

    [Column("invoiced")]
    public bool? Invoiced { get; set; }

    [Column("margin")]
    public decimal? Margin { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }
}
