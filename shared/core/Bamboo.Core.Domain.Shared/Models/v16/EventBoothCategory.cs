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

[Table("event_booth_category")]
public partial class EventBoothCategory: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("sponsor_type_id")]
    public Guid? SponsorTypeId { get; set; }

    [Column("exhibitor_type")]
    public string? ExhibitorType { get; set; }

    [Column("use_sponsor")]
    public bool? UseSponsor { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("EventBoothCategoryCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("BoothCategoryId")]
    [InverseProperty("BoothCategory")]
    public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many]
    [ForeignKey("EventBoothCategoryId")]
    [InverseProperty("EventBoothCategory")]
    public virtual ICollection<EventBoothConfigurator> EventBoothConfigurator { get; set; }

    // [One2many]
    [ForeignKey("BoothCategoryId")]
    [InverseProperty("BoothCategory")]
    public virtual ICollection<EventTypeBooth> EventTypeBooth { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("EventBoothCategory")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    [ForeignKey("EventBoothCategoryId")]
    [InverseProperty("EventBoothCategory")]
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("SponsorTypeId")]
    // [InverseProperty("EventBoothCategory")] //Many2one
    public virtual EventSponsorType? SponsorType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("EventBoothCategoryWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
