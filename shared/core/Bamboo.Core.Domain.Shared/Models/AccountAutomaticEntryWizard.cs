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

[Table("account_automatic_entry_wizard")]
public partial class AccountAutomaticEntryWizard: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("destination_account_id")]
    public Guid? DestinationAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("action")]
    public string? Action { get; set; }

    [Column("account_type")]
    public string? AccountType { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("total_amount")]
    public decimal? TotalAmount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("percentage")]
    public double? Percentage { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAutomaticEntryWizards")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAutomaticEntryWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DestinationAccountId")]
    //[InverseProperty("AccountAutomaticEntryWizards")]
    [NotMapped]
    public virtual AccountAccount? DestinationAccount { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAutomaticEntryWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountAutomaticEntryWizardId")]
    //[InverseProperty("AccountAutomaticEntryWizards")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();
}
