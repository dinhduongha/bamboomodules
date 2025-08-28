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

[Table("ir_module_module_dependency")]
//[Index("Name", Name = "ir_module_module_dependency__name_index")]
public partial class IrModuleModuleDependency: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("module_id")]
    public Guid? ModuleId { get; set; }

    [Column("auto_install_required")]
    public bool? AutoInstallRequired { get; set; }

    // [Many2one]
    [ForeignKey("ModuleId")]
    public virtual IrModuleModule? Module { get; set; }
}
