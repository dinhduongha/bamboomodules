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

[Table("membership_membership_line")]
//[Index("Partner", Name = "membership_membership_line__partner_index")]
public partial class MembershipMembershipLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("partner")]
    public Guid? Partner { get; set; }

    [Column("membership_id")]
    public Guid? MembershipId { get; set; }

    [Column("account_invoice_line")]
    public Guid? AccountInvoiceLine { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("date_cancel")]
    public DateTime? DateCancel { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("member_price")]
    public decimal? MemberPrice { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccountInvoiceLine")]
    // [InverseProperty("MembershipMembershipLine")] //Many2one
    public virtual AccountMoveLine? AccountInvoiceLineNavigation { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("MembershipMembershipLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MembershipMembershipLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MembershipId")]
    // [InverseProperty("MembershipMembershipLine")] //Many2one
    public virtual ProductProduct? Membership { get; set; }

    // [Many2one]
    [ForeignKey("Partner")]
    // [InverseProperty("MembershipMembershipLine")] //Many2one
    public virtual ResPartner? PartnerNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MembershipMembershipLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
