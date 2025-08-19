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
public partial class HrDepartureWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("departure_reason_id")]
    public Guid? DepartureReasonId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("departure_date")]
    public DateTime? DepartureDate { get; set; }

    [Column("departure_description")]
    public string? DepartureDescription { get; set; }

    [Column("archive_private_address")]
    public bool? ArchivePrivateAddress { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("set_date_end")]
    public bool? SetDateEnd { get; set; }

    [Column("cancel_leaves")]
    public bool? CancelLeaves { get; set; }

    [Column("archive_allocation")]
    public bool? ArchiveAllocation { get; set; }

    [Column("release_campany_car")]
    public bool? ReleaseCampanyCar { get; set; }

    [Column("unassign_equipment")]
    public bool? UnassignEquipment { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrDepartureWizardCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartureReasonId")]
    // [InverseProperty("HrDepartureWizard")] //Many2one
    public virtual HrDepartureReason? DepartureReason { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrDepartureWizard")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrDepartureWizardWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
