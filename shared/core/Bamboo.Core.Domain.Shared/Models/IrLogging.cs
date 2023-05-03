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

[Table("ir_logging")]
//[Index("Dbname", Name = "ir_logging_dbname_index")]
//[Index("Level", Name = "ir_logging_level_index")]
//[Index("Type", Name = "ir_logging_type_index")]
public partial class IrLogging: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("dbname")]
    public string? Dbname { get; set; }

    [Column("level")]
    public string? Level { get; set; }

    [Column("path")]
    public string? Path { get; set; }

    [Column("func")]
    public string? Func { get; set; }

    [Column("line")]
    public string? Line { get; set; }

    [Column("message")]
    public string? Message { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }
}
