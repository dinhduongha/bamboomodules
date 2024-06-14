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

[Table("base_import_tests_models_float")]
public partial class BaseImportTestsModelsFloat: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("value2")]
    public decimal? Value2 { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("value")]
    public double? Value { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BaseImportTestsModelsFloatCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("BaseImportTestsModelsFloats")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BaseImportTestsModelsFloatWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
