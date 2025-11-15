using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class ResUsers
{
    [Column("totp_last_counter")]
    public long? TotpLastCounter { get; set; }

    [Column("manual_im_status")]
    public string? ManualImStatus { get; set; }

    [Column("out_of_office_message")]
    public string? OutOfOfficeMessage { get; set; }

    [Column("out_of_office_from", TypeName = "timestamp without time zone")]
    public DateTime? OutOfOfficeFrom { get; set; }

    [Column("out_of_office_to", TypeName = "timestamp without time zone")]
    public DateTime? OutOfOfficeTo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountAnalyticLineCalendarEmployee) is commented out
    // public virtual ICollection<AccountAnalyticLineCalendarEmployee> AccountAnalyticLineCalendarEmployeeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("UserId")]
    // [NotMapped] // One2many 
    // [InverseProperty("User")] // One2many // Peer relationship (AccountAnalyticLineCalendarEmployee) is commented out
    // public virtual ICollection<AccountAnalyticLineCalendarEmployee> AccountAnalyticLineCalendarEmployeeUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountAnalyticLineCalendarEmployee) is commented out
    // public virtual ICollection<AccountAnalyticLineCalendarEmployee> AccountAnalyticLineCalendarEmployeeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountPaymentWithholdingLine) is commented out
    // public virtual ICollection<AccountPaymentWithholdingLine> AccountPaymentWithholdingLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountPaymentWithholdingLine) is commented out
    // public virtual ICollection<AccountPaymentWithholdingLine> AccountPaymentWithholdingLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (DiscussCallHistory) is commented out
    // public virtual ICollection<DiscussCallHistory> DiscussCallHistoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (DiscussCallHistory) is commented out
    // public virtual ICollection<DiscussCallHistory> DiscussCallHistoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (EventMailSlot) is commented out
    // public virtual ICollection<EventMailSlot> EventMailSlotCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (EventMailSlot) is commented out
    // public virtual ICollection<EventMailSlot> EventMailSlotWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (EventMail) is commented out
    // public virtual ICollection<EventMail> EventMailWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (EventSlot) is commented out
    // public virtual ICollection<EventSlot> EventSlotCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (EventSlot) is commented out
    // public virtual ICollection<EventSlot> EventSlotWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (HrApplicantSkill) is commented out
    // public virtual ICollection<HrApplicantSkill> HrApplicantSkillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (HrApplicantSkill) is commented out
    // public virtual ICollection<HrApplicantSkill> HrApplicantSkillWriteU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual IrMailServer? IrMailServerOwnerUser { get; set; }


    // // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [NotMapped] // Many2many // Normal
    // // [ForeignKey("UserId")] // Many2many // Normal
    // // [InverseProperty("User")] // Many2many // Normal
    // public virtual ICollection<ImLivechatChannel> Channel { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")] //Many2many // Hidden
    // [InverseProperty("ResUsers")] //Many2many // Hidden
    public virtual ICollection<IrFilters> IrFilters { get; set; }


    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")] //Many2many // Hidden
    // [InverseProperty("ResUsers")] //Many2many // Hidden
    public virtual ICollection<ProjectTemplateRoleToUsersMap> ProjectTemplateRoleToUsersMap { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")] //Many2many // Hidden
    // [InverseProperty("ResUsers")] //Many2many // Hidden
    public virtual ICollection<ResRole> ResRole { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")] //Many2many // Hidden
    // [InverseProperty("ResUsers")] //Many2many // Hidden
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboard { get; set; }

}