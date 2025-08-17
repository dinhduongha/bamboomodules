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

[Table("base_language_export")]
public partial class BaseLanguageExport: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("format")]
    public string? Format { get; set; }

    [Column("export_type")]
    public string? ExportType { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("data")]
    public byte[]? Data { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("BaseLanguageExportCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("BaseLanguageExport")] //Many2one
    public virtual IrModel? Model { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("BaseLanguageExportWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("WizId")] //Many2many
    // [InverseProperty("Wiz")] //Many2many
    public virtual ICollection<IrModuleModule> Module { get; set; }
}
