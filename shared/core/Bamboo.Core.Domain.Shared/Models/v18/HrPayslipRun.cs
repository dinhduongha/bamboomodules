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

[Table("hr_payslip_run")]
//[Index("State", Name = "hr_payslip_run__state_index")]
public partial class HrPayslipRun: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("date_end")]
    public DateTime? DateEnd { get; set; }

    [Column("credit_note")]
    public bool? CreditNote { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrPayslipRunCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [NotMapped]//Many2many
    //[InverseProperty("PayslipRun") //Many2many
    public virtual ICollection<HrPayslip> HrPayslips { get; set; } = null;

    [ForeignKey("JournalId")]
    //[InverseProperty("HrPayslipRuns")] //Many2One
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrPayslipRunWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
