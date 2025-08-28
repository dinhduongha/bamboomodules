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

[Table("maintenance_equipment")]
//[Index("SerialNo", Name = "maintenance_equipment_serial_no", IsUnique = true)]
public partial class MaintenanceEquipment: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("maintenance_team_id")]
    public Guid? MaintenanceTeamId { get; set; }

    [Column("technician_user_id")]
    public Guid? TechnicianUserId { get; set; }

    [Column("maintenance_count")]
    public long? MaintenanceCount { get; set; }

    [Column("maintenance_open_count")]
    public long? MaintenanceOpenCount { get; set; }

    [Column("expected_mtbf")]
    public long? ExpectedMtbf { get; set; }

    [Column("owner_user_id")]
    public Guid? OwnerUserId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("partner_ref")]
    public string? PartnerRef { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("serial_no")]
    public string? SerialNo { get; set; }

    [Column("effective_date")]
    public DateTime? EffectiveDate { get; set; }

    [Column("assign_date")]
    public DateTime? AssignDate { get; set; }

    [Column("warranty_date")]
    public DateTime? WarrantyDate { get; set; }

    [Column("scrap_date")]
    public DateTime? ScrapDate { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("equipment_properties", TypeName = "jsonb")]
    public string? EquipmentProperties { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("cost")]
    public double? Cost { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("equipment_assign_to")]
    public string? EquipmentAssignTo { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    public virtual MaintenanceEquipmentCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("EquipmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Equipment")] // One2many
    public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }

    // [Many2one]
    [ForeignKey("MaintenanceTeamId")]
    public virtual MaintenanceTeam? MaintenanceTeam { get; set; }

    // [Many2one]
    [ForeignKey("OwnerUserId")]
    public virtual ResUsers? OwnerUser { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("TechnicianUserId")]
    public virtual ResUsers? TechnicianUser { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
