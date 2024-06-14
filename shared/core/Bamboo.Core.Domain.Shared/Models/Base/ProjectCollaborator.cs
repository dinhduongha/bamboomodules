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

[Table("project_collaborator")]
//[Index("ProjectId", "PartnerId", Name = "project_collaborator_unique_collaborator", IsUnique = true)]
public partial class ProjectCollaborator: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProjectCollaboratorCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ProjectCollaborators")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("ProjectId")]
    //[InverseProperty("ProjectCollaborators")]
    [NotMapped]
    public virtual ProjectProject? Project { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProjectCollaboratorWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
