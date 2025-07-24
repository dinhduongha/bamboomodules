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

[Table("data_recycle_record")]
//[Index("ResId", Name = "data_recycle_record__res_id_index")]
public partial class DataRecycleRecord: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("recycle_model_id")]
    public Guid? RecycleModelId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("res_model_name")]
    public string? ResModelName { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("DataRecycleRecords")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("DataRecycleRecordCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("RecycleModelId")]
    //[InverseProperty("DataRecycleRecords")]
    [NotMapped]
    public virtual DataRecycleModel? RecycleModel { get; set; }

    [ForeignKey("ResModelId")]
    //[InverseProperty("DataRecycleRecords")]
    [NotMapped]
    public virtual IrModel? ResModel { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("DataRecycleRecordWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
