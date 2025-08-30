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

//[Table("crm_lead")]
//[Index("CompanyId", Name = "crm_lead__company_id_index")]
//[Index("DateLastStageUpdate", Name = "crm_lead__date_last_stage_update_index")]
//[Index("LostReasonId", Name = "crm_lead__lost_reason_id_index")]
//[Index("PartnerId", Name = "crm_lead__partner_id_index")]
//[Index("Priority", Name = "crm_lead__priority_index")]
//[Index("StageId", Name = "crm_lead__stage_id_index")]
//[Index("TeamId", Name = "crm_lead__team_id_index")]
//[Index("Type", Name = "crm_lead__type_index")]
//[Index("UserId", Name = "crm_lead__user_id_index")]
//[Index("CreateDate", "TeamId", Name = "crm_lead_create_date_team_id_idx")]
//[Index("UserId", "TeamId", "Type", Name = "crm_lead_user_id_team_id_type_index")]
public partial class CrmLead
{

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("date_action_last", TypeName = "timestamp without time zone")]
    public DateTime? DateActionLast { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

}
