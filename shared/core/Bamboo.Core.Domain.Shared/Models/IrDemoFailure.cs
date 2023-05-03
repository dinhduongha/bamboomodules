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

[Table("ir_demo_failure")]
public partial class IrDemoFailure: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("module_id")]
    public Guid? ModuleId { get; set; }

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("error")]
    public string? Error { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrDemoFailureCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ModuleId")]
    //[InverseProperty("IrDemoFailures")]
    [NotMapped]
    public virtual IrModuleModule? Module { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("IrDemoFailures")]
    [NotMapped]
    public virtual IrDemoFailureWizard? Wizard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrDemoFailureWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
