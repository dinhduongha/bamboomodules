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

//[Table("ir_sequence")]
public partial class IrSequence
{
    // [One2many]
    // [One2many] [ForeignKey("SecureSequenceId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("SecureSequence")] // One2many
    public virtual ICollection<AccountJournal> AccountJournal { get; set; }
}
