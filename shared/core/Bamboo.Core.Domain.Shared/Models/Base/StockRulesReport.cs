using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("stock_rules_report")]
public partial class StockRulesReport: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("product_has_variants")]
    public bool? ProductHasVariants { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockRulesReportCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockRulesReports")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("StockRulesReports")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockRulesReportWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("StockRulesReportId")]
    //[InverseProperty("StockRulesReports")]
    [NotMapped]
    public virtual ICollection<StockRoute> StockRoutes { get; } = new List<StockRoute>();

    [ForeignKey("StockRulesReportId")]
    //[InverseProperty("StockRulesReports")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouses { get; } = new List<StockWarehouse>();
}
