using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("res_currency")]
//[Index("Name", Name = "res_currency_unique_name", IsUnique = true)]
public partial class ResCurrency
{

    // v16-Compat
    //[Column("currency_unit_label")]
    //public string? CurrencyUnitLabel { get; set; }

    // v16-Compat
    //[Column("currency_subunit_label")]
    //public string? CurrencySubunitLabel { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountAccountTemplate) is commented out
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplate { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountChartTemplate) is commented out
    // public virtual ICollection<AccountChartTemplate> AccountChartTemplate { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (BaseImportTestsModelsComplex) is commented out
    // public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplex { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (BaseImportTestsModelsFloat) is commented out
    // public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloat { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (ProjectCreateSaleOrderLine) is commented out
    // public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLine { get; set; }
}
