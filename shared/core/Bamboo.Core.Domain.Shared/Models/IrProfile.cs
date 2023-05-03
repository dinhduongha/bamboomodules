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

[Table("ir_profile")]
//[Index("Session", Name = "ir_profile_session_index")]
public partial class IrProfile: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sql_count")]
    public long? SqlCount { get; set; }

    [Column("entry_count")]
    public long? EntryCount { get; set; }

    [Column("session")]
    public string? Session { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("init_stack_trace")]
    public string? InitStackTrace { get; set; }

    [Column("sql")]
    public string? Sql { get; set; }

    [Column("traces_async")]
    public string? TracesAsync { get; set; }

    [Column("traces_sync")]
    public string? TracesSync { get; set; }

    [Column("qweb")]
    public string? Qweb { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }
}
