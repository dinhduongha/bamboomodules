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

[Table("res_bank")]
//[Index("Bic", Name = "res_bank_bic_index")]
public partial class ResBank: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("state")]
    public long? State { get; set; }

    [Column("country")]
    public long? Country { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("street")]
    public string? Street { get; set; }

    [Column("street2")]
    public string? Street2 { get; set; }

    [Column("zip")]
    public string? Zip { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("bic")]
    public string? Bic { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("Country")]
    //[InverseProperty("ResBanks")]
    [NotMapped]
    public virtual ResCountry? CountryNavigation { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResBankCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("State")]
    //[InverseProperty("ResBanks")]
    [NotMapped]
    public virtual ResCountryState? StateNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResBankWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Bank")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; } = new List<ResPartnerBank>();

}
