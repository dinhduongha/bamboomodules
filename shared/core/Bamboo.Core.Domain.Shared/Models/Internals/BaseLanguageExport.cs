using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Module("base")]
[Table("base_language_export")]
public partial class BaseLanguageExport: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    //[Column("company_id")]
    //public Guid? TenantId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("data")]
    public byte[]? Data { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BaseLanguageExportCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("BaseLanguageExports")]
    [NotMapped]
    public virtual IrModel? Model { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BaseLanguageExportWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("WizId")]
    //[InverseProperty("Wizs")]
    [NotMapped]
    public virtual ICollection<IrModuleModule> Modules { get; set; } 
}
