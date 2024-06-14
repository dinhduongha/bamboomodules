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

[Table("accounting_report")]
public partial class AccountingReport: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
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

    [Column("account_report_id")]
    public Guid? AccountReportId { get; set; }

    [Column("target_move")]
    public string? TargetMove { get; set; }

    [Column("label_filter")]
    public string? LabelFilter { get; set; }

    [Column("filter_cmp")]
    public string? FilterCmp { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("date_from_cmp")]
    public DateTime? DateFromCmp { get; set; }

    [Column("date_to_cmp")]
    public DateTime? DateToCmp { get; set; }

    [Column("enable_filter")]
    public bool? EnableFilter { get; set; }

    [Column("debit_credit")]
    public bool? DebitCredit { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AccountReportId")]
    //[InverseProperty("AccountingReports")]
    [NotMapped]
    public virtual AccountFinancialReport? AccountReport { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountingReports")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountingReportCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountingReportWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountingReportId")]
    //[InverseProperty("AccountingReports")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();
}
