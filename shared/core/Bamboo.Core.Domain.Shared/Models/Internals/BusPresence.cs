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
[Table("bus_presence")]
public partial class BusPresence : FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
    
    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("status")]
    public string? Status { get; set; }

    [Column("last_poll", TypeName = "timestamp without time zone")]
    public DateTime? LastPoll { get; set; }

    [Column("last_presence", TypeName = "timestamp without time zone")]
    public DateTime? LastPresence { get; set; }

    [Column("guest_id")]
    public Guid? GuestId { get; set; }

    [ForeignKey("GuestId")]
    //[InverseProperty("BusPresence")]
    [NotMapped]
    public virtual MailGuest? Guest { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("BusPresence")]
    [NotMapped]
    public virtual ResUser? User { get; set; }
}
