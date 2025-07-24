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
public partial class MaintenanceEquipmentCategory: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("technician_user_id")]
    public Guid? TechnicianUserId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("note", TypeName = "jsonb")]
    public string? Note { get; set; }

    [JsonField]
    [Column("equipment_properties_definition", TypeName = "jsonb")]
    public string? EquipmentPropertiesDefinition { get; set; }

    [Column("fold")]
    public bool? Fold { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("AliasId")]
    //[InverseProperty("MaintenanceEquipmentCategories")]
    [NotMapped]
    public virtual MailAlias? Alias { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("MaintenanceEquipmentCategories")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MaintenanceEquipmentCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("MaintenanceEquipmentCategories")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("TechnicianUserId")]
    //[InverseProperty("MaintenanceEquipmentCategoryTechnicianUsers")]
    [NotMapped]
    public virtual ResUser? TechnicianUser { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MaintenanceEquipmentCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; set; } = new List<MaintenanceEquipment>();

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();


}
