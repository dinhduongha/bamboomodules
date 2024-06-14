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
public partial class AccountBalanceReport: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("target_move")]
    public string? TargetMove { get; set; }

    [Column("display_account")]
    public string? DisplayAccount { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountBalanceReports")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountBalanceReportCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountBalanceReportWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountBalanceReportId")]
    //[InverseProperty("AccountBalanceReports")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; } = new List<AccountAccount>();

    [ForeignKey("AccountBalanceReportId")]
    //[InverseProperty("AccountBalanceReports")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; } = new List<AccountAnalyticAccount>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountJournal> Journals { get; } = new List<AccountJournal>();

    [ForeignKey("AccountBalanceReportId")]
    //[InverseProperty("AccountBalanceReports")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();
}
