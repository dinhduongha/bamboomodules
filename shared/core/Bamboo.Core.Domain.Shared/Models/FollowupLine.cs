using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("followup_line")]
//[Index("FollowupId", "Delay", Name = "followup_line_days_uniq", IsUnique = true)]
public partial class FollowupLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("followup_id")]
    public Guid? FollowupId { get; set; }

    [Column("delay")]
    public long? Delay { get; set; }

    [Column("manual_action_responsible_id")]
    public Guid? ManualActionResponsibleId { get; set; }

    [Column("email_template_id")]
    public Guid? EmailTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("manual_action_note")]
    public string? ManualActionNote { get; set; }

    [Column("send_email")]
    public bool? SendEmail { get; set; }

    [Column("send_letter")]
    public bool? SendLetter { get; set; }

    [Column("manual_action")]
    public bool? ManualAction { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FollowupLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmailTemplateId")]
    //[InverseProperty("FollowupLines")]
    [NotMapped]
    public virtual MailTemplate? EmailTemplate { get; set; }

    [ForeignKey("FollowupId")]
    //[InverseProperty("FollowupLines")]
    [NotMapped]
    public virtual FollowupFollowup? Followup { get; set; }

    [ForeignKey("ManualActionResponsibleId")]
    //[InverseProperty("FollowupLineManualActionResponsibles")]
    [NotMapped]
    public virtual ResUser? ManualActionResponsible { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FollowupLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("FollowupLine")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("LatestFollowupLevelIdWithoutLitNavigation")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

}
