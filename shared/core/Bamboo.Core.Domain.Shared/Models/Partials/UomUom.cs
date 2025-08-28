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

//[Table("uom_uom")]
public partial class UomUom
{
    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUom")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUomNavigation")] // One2many // Peer relationship (RepairFee) is commented out
    // public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUom")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUomNavigation")] // One2many // Peer relationship (RepairLine) is commented out
    // public virtual ICollection<RepairLine> RepairLine { get; set; }
}
