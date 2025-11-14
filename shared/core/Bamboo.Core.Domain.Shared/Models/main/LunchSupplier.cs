using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CronId")]
    public virtual IrCron? Cron { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SupplierId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Supplier")] // One2many
    public virtual ICollection<LunchOrder> LunchOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SupplierId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Supplier")] // One2many
    public virtual ICollection<LunchProduct> LunchProduct { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SupplierId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Supplier")] // One2many
    public virtual ICollection<LunchTopping> LunchTopping { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResponsibleId")]
    public virtual ResUsers? Responsible { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("LunchSupplierId")] // Many2many // Normal
    // [InverseProperty("LunchSupplier")] // Many2many // Normal
    public virtual ICollection<LunchLocation> LunchLocation { get; set; }
}
