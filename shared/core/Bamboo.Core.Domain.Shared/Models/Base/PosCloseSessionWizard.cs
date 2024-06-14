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

[Table("pos_close_session_wizard")]
public partial class PosCloseSessionWizard: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("message")]
    public string? Message { get; set; }

    [Column("account_readonly")]
    public bool? AccountReadonly { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("amount_to_balance")]
    public double? AmountToBalance { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("PosCloseSessionWizards")]
    [NotMapped]
    public virtual AccountAccount? Account { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosCloseSessionWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosCloseSessionWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
