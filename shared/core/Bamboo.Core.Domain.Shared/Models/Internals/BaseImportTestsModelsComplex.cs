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

[Table("base_import_tests_models_complex")]
public partial class BaseImportTestsModelsComplex: Entity<Guid>, IEntityDto<Guid>
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

    [Column("c")]
    public string? C { get; set; }

    [Column("d")]
    public DateTime? D { get; set; }

    [Column("m")]
    public decimal? M { get; set; }

    [Column("dt", TypeName = "timestamp without time zone")]
    public DateTime? Dt { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("f")]
    public double? F { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BaseImportTestsModelsComplexCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("BaseImportTestsModelsComplexes")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BaseImportTestsModelsComplexWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
