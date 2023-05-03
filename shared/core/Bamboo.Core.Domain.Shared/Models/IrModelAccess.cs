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

[Table("ir_model_access")]
//[Index("GroupId", Name = "ir_model_access_group_id_index")]
//[Index("ModelId", Name = "ir_model_access_model_id_index")]
//[Index("Name", Name = "ir_model_access_name_index")]
public partial class IrModelAccess: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("perm_read")]
    public bool? PermRead { get; set; }

    [Column("perm_write")]
    public bool? PermWrite { get; set; }

    [Column("perm_create")]
    public bool? PermCreate { get; set; }

    [Column("perm_unlink")]
    public bool? PermUnlink { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrModelAccessCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GroupId")]
    //[InverseProperty("IrModelAccesses")]
    [NotMapped]
    public virtual ResGroup? Group { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("IrModelAccesses")]
    [NotMapped]
    public virtual IrModel? Model { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrModelAccessWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
