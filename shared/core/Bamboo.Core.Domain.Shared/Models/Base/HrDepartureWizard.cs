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

[Table("hr_departure_wizard")]
public partial class HrDepartureWizard: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("departure_reason_id")]
    public long? DepartureReasonId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("departure_date")]
    public DateTime? DepartureDate { get; set; }

    [Column("departure_description")]
    public string? DepartureDescription { get; set; }

    [Column("archive_private_address")]
    public bool? ArchivePrivateAddress { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("set_date_end")]
    public bool? SetDateEnd { get; set; }

    [Column("cancel_leaves")]
    public bool? CancelLeaves { get; set; }

    [Column("archive_allocation")]
    public bool? ArchiveAllocation { get; set; }

    [Column("release_campany_car")]
    public bool? ReleaseCampanyCar { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrDepartureWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartureReasonId")]
    //[InverseProperty("HrDepartureWizards")]
    [NotMapped]
    public virtual HrDepartureReason? DepartureReason { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrDepartureWizards")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrDepartureWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
