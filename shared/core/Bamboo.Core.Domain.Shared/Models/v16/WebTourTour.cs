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

[Table("web_tour_tour")]
public partial class WebTourTour: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
    
    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("WebTourTours")]
    [NotMapped]
    public virtual ResUser? User { get; set; }
}
