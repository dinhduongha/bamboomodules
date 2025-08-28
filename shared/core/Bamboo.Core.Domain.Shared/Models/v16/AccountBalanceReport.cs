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

[Table("account_balance_report")]
public partial class AccountBalanceReport: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("target_move")]
    public string? TargetMove { get; set; }

    [Column("display_account")]
    public string? DisplayAccount { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (AccountAccount) is commented out
    // [ForeignKey("AccountBalanceReportId")] // Many2many // Normal
    // [InverseProperty("AccountBalanceReport")] // Many2many // Normal
    public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountBalanceReportId")] // Many2many // Normal
    // [InverseProperty("AccountBalanceReport")] // Many2many // Normal
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountId")] // Many2many // Normal
    // [InverseProperty("Account")] // Many2many // Normal
    public virtual ICollection<AccountJournal> Journal { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("AccountBalanceReportId")] // Many2many // Normal
    // [InverseProperty("AccountBalanceReport")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartner { get; set; }
}
