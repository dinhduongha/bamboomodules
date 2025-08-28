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

//[Table("maintenance_equipment")]
//[Index("SerialNo", Name = "maintenance_equipment_serial_no", IsUnique = true)]
public partial class MaintenanceEquipment
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("period")]
    public long? Period { get; set; }

    // [Column("maintenance_team_id")]
    // public Guid? MaintenanceTeamId { get; set; }

    [Column("next_action_date")]
    public DateTime? NextActionDate { get; set; }

    [Column("maintenance_duration")]
    public double? MaintenanceDuration { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
