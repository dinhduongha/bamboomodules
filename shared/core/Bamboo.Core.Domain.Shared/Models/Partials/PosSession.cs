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

//[Table("pos_session")]
//[Index("ConfigId", Name = "pos_session__config_id_index")]
//[Index("MoveId", Name = "pos_session__move_id_index")]
//[Index("State", Name = "pos_session__state_index")]
//[Index("UserId", Name = "pos_session__user_id_index")]
//[Index("Name", Name = "pos_session_uniq_name", IsUnique = true)]
public partial class PosSession
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
