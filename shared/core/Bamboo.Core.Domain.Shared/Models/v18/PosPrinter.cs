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

[Table("pos_printer")]
public partial class PosPrinter: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("printer_type")]
    public string? PrinterType { get; set; }

    [Column("proxy_ip")]
    public string? ProxyIp { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("epson_printer_ip")]
    public string? EpsonPrinterIp { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("PosPrinters")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosPrinterCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosPrinterWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("PrinterId")]
    //[InverseProperty("Printers")]
    [NotMapped]
    public virtual ICollection<PosCategory> Categories { get; set; } = new List<PosCategory>();

    [ForeignKey("PrinterId")]
    //[InverseProperty("Printers")]
    [NotMapped]
    public virtual ICollection<PosConfig> Configs { get; set; } = new List<PosConfig>();
}
