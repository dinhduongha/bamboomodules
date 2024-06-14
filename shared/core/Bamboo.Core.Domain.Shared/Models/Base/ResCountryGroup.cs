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
public partial class ResCountryGroup: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResCountryGroupCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResCountryGroupWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
    /// TODO: DISABLE INVERSE

    //[InverseProperty("CountryGroup")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplates { get; } = new List<AccountFiscalPositionTemplate>();

    //[InverseProperty("CountryGroup")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; } = new List<AccountFiscalPosition>();

    [ForeignKey("ResCountryGroupId")]
    //[InverseProperty("ResCountryGroups")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> Pricelists { get; } = new List<ProductPricelist>();

    [ForeignKey("ResCountryGroupId")]
    //[InverseProperty("ResCountryGroups")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountries { get; } = new List<ResCountry>();

}
