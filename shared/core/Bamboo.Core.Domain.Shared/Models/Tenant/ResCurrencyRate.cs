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

[Table("res_currency_rate")]
//[Index("Name", Name = "res_currency_rate_name_index")]
//[Index("Name", "CurrencyId", "TenantId", Name = "res_currency_rate_unique_name_per_day", IsUnique = true)]
public partial class ResCurrencyRate: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public DateTime? Name { get; set; }

    [Column("rate")]
    public decimal? Rate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ResCurrencyRates")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResCurrencyRateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("ResCurrencyRates")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResCurrencyRateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
