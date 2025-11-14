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

//[Table("res_partner")]
//[Index("CommercialPartnerId", Name = "res_partner__commercial_partner_id_index")]
//[Index("CompanyId", Name = "res_partner__company_id_index")]
//[Index("Date", Name = "res_partner_date_index")]
//[Index("DisplayName", Name = "res_partner_display_name_index")]
//[Index("IsPublished", Name = "res_partner__is_published_index")]
//[Index("Name", Name = "res_partner__name_index")]
//[Index("ParentId", Name = "res_partner__parent_id_index")]
//[Index("Ref", Name = "res_partner__ref_index")]
//[Index("Vat", Name = "res_partner__vat_index")]
//[Index("WebsiteId", Name = "res_partner__website_id_index")]
public partial class ResPartner
{

    [Column("display_name")]
    public string? DisplayName { get; set; }


    [Column("date")]
    public DateTime? Date { get; set; }


    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }


    [Column("signup_expiration", TypeName = "timestamp without time zone")]
    public DateTime? SignupExpiration { get; set; }

    [Column("signup_token")]
    public string? SignupToken { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }


    [Column("last_time_entries_checked", TypeName = "timestamp without time zone")]
    public DateTime? LastTimeEntriesChecked { get; set; }


    [Column("latest_followup_level_id_without_lit")]
    public Guid? LatestFollowupLevelIdWithoutLit { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (HrApplicant) is commented out
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AddressHomeId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AddressHome")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployeeAddressHome { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Address")] // One2many // Peer relationship (HrExpenseSheet) is commented out
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }


    // [Many2one]
    [ForeignKey("LatestFollowupLevelIdWithoutLit")]
    public virtual FollowupLine? LatestFollowupLevelIdWithoutLitNavigation { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("LivechatOperatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("LivechatOperator")] // One2many // Peer relationship (MailChannel) is commented out
    // public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (MailChannelMember) is commented out
    // public virtual ICollection<MailChannelMember> MailChannelMember { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (MailResendPartner) is commented out
    // public virtual ICollection<MailResendPartner> MailResendPartner { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProjectCreateSaleOrder) is commented out
    // public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrder { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Address")] // One2many // Peer relationship (RepairOrder) is commented out
    // public virtual ICollection<RepairOrder> RepairOrderAddress { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (RepairOrder) is commented out
    // public virtual ICollection<RepairOrder> RepairOrderPartner { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerInvoiceId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerInvoice")] // One2many // Peer relationship (RepairOrder) is commented out
    // public virtual ICollection<RepairOrder> RepairOrderPartnerInvoice { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("VendorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Vendor")] // One2many // Peer relationship (StockWarehouseOrderpoint) is commented out
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [ForeignKey("TeamId")]
    public virtual CrmTeam? Team { get; set; }


    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplate { get; set; }
}
