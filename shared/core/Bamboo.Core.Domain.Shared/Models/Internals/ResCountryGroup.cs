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

[Table("res_country_group")]
public partial class ResCountryGroup: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("CountryGroupId")]
    [InverseProperty("CountryGroup")]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [One2many]
    [ForeignKey("CountryGroupId")]
    [InverseProperty("CountryGroup")]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResCountryGroupCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResCountryGroupWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryGroupId")]
    // [InverseProperty("ResCountryGroup")]
    // public virtual ICollection<ProductPricelist> Pricelist { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryGroupId")]
    // [InverseProperty("ResCountryGroup")]
    // public virtual ICollection<ResCountry> ResCountry { get; set; }
}
