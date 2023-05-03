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

[Table("fleet_vehicle_log_contract")]
//[Index("UserId", Name = "fleet_vehicle_log_contract_user_id_index")]
public partial class FleetVehicleLogContract: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [Column("cost_subtype_id")]
    public long? CostSubtypeId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("insurer_id")]
    public Guid? InsurerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("ins_ref")]
    public string? InsRef { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("cost_frequency")]
    public string? CostFrequency { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("start_date")]
    public DateTime? StartDate { get; set; }

    [Column("expiration_date")]
    public DateTime? ExpirationDate { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("cost_generated")]
    public decimal? CostGenerated { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("FleetVehicleLogContracts")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CostSubtypeId")]
    //[InverseProperty("FleetVehicleLogContractsNavigation")]
    [NotMapped]
    public virtual FleetServiceType? CostSubtype { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FleetVehicleLogContractCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("InsurerId")]
    //[InverseProperty("FleetVehicleLogContracts")]
    [NotMapped]
    public virtual ResPartner? Insurer { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("FleetVehicleLogContracts")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("FleetVehicleLogContractUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("VehicleId")]
    //[InverseProperty("FleetVehicleLogContracts")]
    [NotMapped]
    public virtual FleetVehicle? Vehicle { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FleetVehicleLogContractWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("FleetVehicleLogContractId")]
    //[InverseProperty("FleetVehicleLogContracts")]
    [NotMapped]
    public virtual ICollection<FleetServiceType> FleetServiceTypes { get; } = new List<FleetServiceType>();
}
