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

public partial class AccountAccountTag
{

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")] //Many2many // Hidden
    // [InverseProperty("AccountAccountTag")] //Many2many // Hidden
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplate { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")] //Many2many // Hidden
    // [InverseProperty("AccountAccountTag")] //Many2many // Hidden
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplate { get; set; }

}
