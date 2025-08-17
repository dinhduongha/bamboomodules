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
public partial class LunchSupplier: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("responsible_id")]
    public Guid? ResponsibleId { get; set; }

    [Column("cron_id")]
    public Guid? CronId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("automatic_email_time")]
    public double? AutomaticEmailTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("LunchSupplier")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LunchSupplierCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CronId")]
    // [InverseProperty("LunchSupplier")] //Many2one
    public virtual IrCron? Cron { get; set; }

    // [One2many]
    [ForeignKey("SupplierId")]
    [InverseProperty("Supplier")]
    public virtual ICollection<LunchOrder> LunchOrder { get; set; }

    // [One2many]
    [ForeignKey("SupplierId")]
    [InverseProperty("Supplier")]
    public virtual ICollection<LunchProduct> LunchProduct { get; set; }

    // [One2many]
    [ForeignKey("SupplierId")]
    [InverseProperty("Supplier")]
    public virtual ICollection<LunchTopping> LunchTopping { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("LunchSupplier")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("LunchSupplier")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("ResponsibleId")]
    // [InverseProperty("LunchSupplierResponsible")] //Many2one
    public virtual ResUsers? Responsible { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LunchSupplierWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("LunchSupplierId")] //Many2many
    // [InverseProperty("LunchSupplier")] //Many2many
    public virtual ICollection<LunchLocation> LunchLocation { get; set; }
}
