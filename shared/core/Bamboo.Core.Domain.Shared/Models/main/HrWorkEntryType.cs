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

[Table("hr_work_entry_type")]
public partial class HrWorkEntryType: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("external_code")]
    public string? ExternalCode { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("is_leave")]
    public bool? IsLeave { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkEntryTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WorkEntryType")] // One2many
    public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkEntryTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WorkEntryType")] // One2many
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkEntryTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WorkEntryType")] // One2many
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendance { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkEntryTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WorkEntryType")] // One2many
    public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
