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

[Module("base")]
[Table("web_tour_tour")]
//[Index("Name", Name = "web_tour_tour_uniq_name", IsUnique = true)]
public partial class WebTourTour: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    //v16-Compat
    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [JsonField]
    [Column("rainbow_man_message", TypeName = "jsonb")]
    public string? RainbowManMessage { get; set; }

    [Column("custom")]
    public bool? Custom { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebTourTourCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Tour")]
    [NotMapped]
    public virtual ICollection<WebTourTourStep> WebTourTourSteps { get; set; } 

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebTourTourWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //v16-Compat
    [ForeignKey("UserId")]
    //[InverseProperty("WebTourTours")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    //v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("WebTourTourId")]
    //[InverseProperty("WebTourTours")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } 
}
