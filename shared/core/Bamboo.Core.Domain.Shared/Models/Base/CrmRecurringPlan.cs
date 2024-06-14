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

[Table("crm_recurring_plan")]
public partial class CrmRecurringPlan: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("number_of_months")]
    public long? NumberOfMonths { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmRecurringPlanCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmRecurringPlanWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("RecurringPlanNavigation")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();

}
