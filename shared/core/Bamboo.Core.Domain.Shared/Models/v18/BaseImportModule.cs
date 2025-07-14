using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("base_import_module")]
public partial class BaseImportModule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("import_message")]
    public string? ImportMessage { get; set; }

    [Column("modules_dependencies")]
    public string? ModulesDependencies { get; set; }

    [Column("force")]
    public bool? Force { get; set; }

    [Column("with_demo")]
    public bool? WithDemo { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("module_file")]
    public byte[]? ModuleFile { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BaseImportModuleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BaseImportModuleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
