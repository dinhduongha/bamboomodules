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

//[Table("hr_contract_type")]
public partial class HrContractTypeIAuditedObject
{
    // [One2many]
    // [One2many] [ForeignKey("ContractTypeId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("ContractType")] // One2many
    public virtual ICollection<HrContract> HrContract { get; set; }
}
