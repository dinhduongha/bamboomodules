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

//[Table("mail_activity")]
//[Index("DateDeadline", Name = "mail_activity__date_deadline_index")]
//[Index("ResId", Name = "mail_activity__res_id_index")]
//[Index("ResModelId", Name = "mail_activity__res_model_id_index")]
//[Index("ResModel", Name = "mail_activity__res_model_index")]
//[Index("UserId", Name = "mail_activity__user_id_index")]
public partial class MailActivity
{
    [Column("note_id")]
    public Guid? NoteId { get; set; }

    // [Many2one]
    [ForeignKey("NoteId")]
    public virtual NoteNote? NoteNavigation { get; set; }
}
