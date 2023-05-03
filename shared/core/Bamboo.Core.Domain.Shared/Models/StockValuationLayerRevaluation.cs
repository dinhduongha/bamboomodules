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

[Table("stock_valuation_layer_revaluation")]
public partial class StockValuationLayerRevaluation: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("account_journal_id")]
    public Guid? AccountJournalId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("reason")]
    public string? Reason { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("added_value")]
    public decimal? AddedValue { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("StockValuationLayerRevaluations")]
    [NotMapped]
    public virtual AccountAccount? Account { get; set; }

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("StockValuationLayerRevaluations")]
    [NotMapped]
    public virtual AccountJournal? AccountJournal { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockValuationLayerRevaluations")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockValuationLayerRevaluationCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockValuationLayerRevaluations")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockValuationLayerRevaluationWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
