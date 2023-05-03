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

[Table("base_import_tests_models_m2o_required")]
public partial class BaseImportTestsModelsM2oRequired: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("value")]
    public Guid? Value { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BaseImportTestsModelsM2oRequiredCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("Value")]
    //[InverseProperty("BaseImportTestsModelsM2oRequireds")]
    [NotMapped]
    public virtual BaseImportTestsModelsM2oRequiredRelated? ValueNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BaseImportTestsModelsM2oRequiredWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
