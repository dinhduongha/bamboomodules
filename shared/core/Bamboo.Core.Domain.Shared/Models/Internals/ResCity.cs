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

[Table("res_city")]
public partial class ResCity: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("state_id")]
    public Guid? StateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("zipcode")]
    public string? Zipcode { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("ResCities")] //Many2One
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResCityCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [NotMapped]//Many2many
    //[InverseProperty("CityNavigation") //Many2many
    public virtual ICollection<ResPartner> ResPartners { get; set; } = null;

    [ForeignKey("StateId")]
    //[InverseProperty("ResCities")] //Many2One
    public virtual ResCountryState? State { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResCityWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
