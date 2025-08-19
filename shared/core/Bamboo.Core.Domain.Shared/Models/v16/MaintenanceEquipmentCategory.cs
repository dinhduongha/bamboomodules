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

[Table("maintenance_equipment_category")]
public partial class MaintenanceEquipmentCategory: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("technician_user_id")]
    public Guid? TechnicianUserId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("note", TypeName = "jsonb")]
    public string? Note { get; set; }

    [JsonField]
    [Column("equipment_properties_definition", TypeName = "jsonb")]
    public string? EquipmentPropertiesDefinition { get; set; }

    [Column("fold")]
    public bool? Fold { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AliasId")]
    // [InverseProperty("MaintenanceEquipmentCategory")] //Many2one
    public virtual MailAlias? Alias { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("MaintenanceEquipmentCategory")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MaintenanceEquipmentCategoryCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("CategoryId")]
    [InverseProperty("Category")]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many]
    [ForeignKey("CategoryId")]
    [InverseProperty("Category")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MaintenanceEquipmentCategory")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("TechnicianUserId")]
    // [InverseProperty("MaintenanceEquipmentCategoryTechnicianUser")] //Many2one
    public virtual ResUsers? TechnicianUser { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MaintenanceEquipmentCategoryWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
