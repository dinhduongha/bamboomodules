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

//[Table("survey_invite")]
//[Index("AuthorId", Name = "survey_invite__author_id_index")]
public partial class SurveyInvite
{
    [Column("email_from")]
    public string? EmailFrom { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("WizardId")] // Many2many // Normal
    // [InverseProperty("WizardNavigation")] // Many2many // Normal
    //public virtual ICollection<IrAttachment> Attachment { get; set; }
}
