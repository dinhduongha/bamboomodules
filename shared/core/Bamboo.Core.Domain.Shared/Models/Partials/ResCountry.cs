using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("res_country")]
//[Index("Code", Name = "res_country_code_uniq", IsUnique = true)]
//[Index("Name", Name = "res_country_name_uniq", IsUnique = true)]
public partial class ResCountry
{
    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (AccountChartTemplate) is commented out
    // public virtual ICollection<AccountChartTemplate> AccountChartTemplate { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (AccountFiscalPositionTemplate) is commented out
    // public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplate { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (MailChannel) is commented out
    // public virtual ICollection<MailChannel> MailChannel { get; set; }
}
