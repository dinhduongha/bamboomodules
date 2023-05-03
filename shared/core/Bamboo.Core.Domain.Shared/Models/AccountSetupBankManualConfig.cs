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

[Table("account_setup_bank_manual_config")]
public partial class AccountSetupBankManualConfig: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("res_partner_bank_id")]
    public Guid? ResPartnerBankId { get; set; }

    [Column("num_journals_without_account")]
    public long? NumJournalsWithoutAccount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("new_journal_name")]
    public string? NewJournalName { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountSetupBankManualConfigCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ResPartnerBankId")]
    //[InverseProperty("AccountSetupBankManualConfigs")]
    [NotMapped]
    public virtual ResPartnerBank? ResPartnerBank { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountSetupBankManualConfigWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
