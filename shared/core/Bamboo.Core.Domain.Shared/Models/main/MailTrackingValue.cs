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

[Table("mail_tracking_value")]
//[Index("FieldId", Name = "mail_tracking_value__field_id_index")]
//[Index("MailMessageId", Name = "mail_tracking_value__mail_message_id_index")]
public partial class MailTrackingValue : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("field_id")]
    public Guid? FieldId { get; set; }

    [Column("old_value_integer")]
    public long? OldValueInteger { get; set; }

    [Column("new_value_integer")]
    public long? NewValueInteger { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("old_value_char")]
    public string? OldValueChar { get; set; }

    [Column("new_value_char")]
    public string? NewValueChar { get; set; }

    [JsonField] // FieldInfo
    [Column("field_info", TypeName = "jsonb")]
    public JsonElement? FieldInfo { get; set; }

    [Column("old_value_text")]
    public string? OldValueText { get; set; }

    [Column("new_value_text")]
    public string? NewValueText { get; set; }

    [Column("old_value_datetime", TypeName = "timestamp without time zone")]
    public DateTime? OldValueDatetime { get; set; }

    [Column("new_value_datetime", TypeName = "timestamp without time zone")]
    public DateTime? NewValueDatetime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("old_value_float")]
    public double? OldValueFloat { get; set; }

    [Column("new_value_float")]
    public double? NewValueFloat { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FieldId")]
    public virtual IrModelFields? Field { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MailMessageId")]
    public virtual MailMessage? MailMessage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
