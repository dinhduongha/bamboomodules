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

[Table("lunch_supplier")]
public partial class LunchSupplier: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("responsible_id")]
    public Guid? ResponsibleId { get; set; }

    [Column("cron_id")]
    public Guid? CronId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("send_by")]
    public string? SendBy { get; set; }

    [Column("tz")]
    public string? Tz { get; set; }

    [Column("moment")]
    public string? Moment { get; set; }

    [Column("delivery")]
    public string? Delivery { get; set; }

    [Column("topping_label_1")]
    public string? ToppingLabel1 { get; set; }

    [Column("topping_label_2")]
    public string? ToppingLabel2 { get; set; }

    [Column("topping_label_3")]
    public string? ToppingLabel3 { get; set; }

    [Column("topping_quantity_1")]
    public string? ToppingQuantity1 { get; set; }

    [Column("topping_quantity_2")]
    public string? ToppingQuantity2 { get; set; }

    [Column("topping_quantity_3")]
    public string? ToppingQuantity3 { get; set; }

    [Column("recurrency_end_date")]
    public DateTime? RecurrencyEndDate { get; set; }

    [Column("mon")]
    public bool? Mon { get; set; }

    [Column("tue")]
    public bool? Tue { get; set; }

    [Column("wed")]
    public bool? Wed { get; set; }

    [Column("thu")]
    public bool? Thu { get; set; }

    [Column("fri")]
    public bool? Fri { get; set; }

    [Column("sat")]
    public bool? Sat { get; set; }

    [Column("sun")]
    public bool? Sun { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("automatic_email_time")]
    public double? AutomaticEmailTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("LunchSuppliers")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("LunchSupplierCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CronId")]
    //[InverseProperty("LunchSuppliers")]
    [NotMapped]
    public virtual IrCron? Cron { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("LunchSuppliers")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("LunchSuppliers")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("ResponsibleId")]
    //[InverseProperty("LunchSupplierResponsibles")]
    [NotMapped]
    public virtual ResUser? Responsible { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LunchSupplierWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Supplier")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrders { get; } = new List<LunchOrder>();

    //[InverseProperty("Supplier")]
    [NotMapped]
    public virtual ICollection<LunchProduct> LunchProducts { get; } = new List<LunchProduct>();

    //[InverseProperty("Supplier")]
    [NotMapped]
    public virtual ICollection<LunchTopping> LunchToppings { get; } = new List<LunchTopping>();

    [ForeignKey("LunchSupplierId")]
    //[InverseProperty("LunchSuppliers")]
    [NotMapped]
    public virtual ICollection<LunchLocation> LunchLocations { get; } = new List<LunchLocation>();
}
