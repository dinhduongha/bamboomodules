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

[Table("website_event_menu")]
public partial class WebsiteEventMenu: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("menu_id")]
    public Guid? MenuId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("view_id")]
    public Guid? ViewId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("menu_type")]
    public string? MenuType { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsiteEventMenuCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EventId")]
    //[InverseProperty("WebsiteEventMenus")]
    [NotMapped]
    public virtual EventEvent? Event { get; set; }

    [ForeignKey("MenuId")]
    //[InverseProperty("WebsiteEventMenus")]
    [NotMapped]
    public virtual WebsiteMenu? Menu { get; set; }

    [ForeignKey("ViewId")]
    //[InverseProperty("WebsiteEventMenus")]
    [NotMapped]
    public virtual IrUiView? View { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsiteEventMenuWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
