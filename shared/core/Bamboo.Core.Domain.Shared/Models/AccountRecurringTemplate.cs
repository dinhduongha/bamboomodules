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

[Table("account_recurring_template")]
public partial class AccountRecurringTemplate: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("recurring_interval")]
    public long? RecurringInterval { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("recurring_period")]
    public string? RecurringPeriod { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("journal_state")]
    public string? JournalState { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountRecurringTemplates")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountRecurringTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("AccountRecurringTemplates")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountRecurringTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPayments { get; } = new List<RecurringPayment>();

}
