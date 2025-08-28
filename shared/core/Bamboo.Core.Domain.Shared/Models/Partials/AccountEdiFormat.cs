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

//[Table("account_edi_format")]
//[Index("Code", Name = "account_edi_format_unique_code", IsUnique = true)]
public partial class AccountEdiFormat
{
    // [One2many]
    // [One2many] [ForeignKey("EdiFormatId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("EdiFormat")] // One2many
    public virtual ICollection<AccountEdiProxyClientUser> AccountEdiProxyClientUser { get; set; }
}
