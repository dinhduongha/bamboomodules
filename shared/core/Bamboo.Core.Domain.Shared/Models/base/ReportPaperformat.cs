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

[Table("report_paperformat")]
public partial class ReportPaperformat: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("page_height")]
    public long? PageHeight { get; set; }

    [Column("page_width")]
    public long? PageWidth { get; set; }

    [Column("header_spacing")]
    public long? HeaderSpacing { get; set; }

    [Column("dpi")]
    public long? Dpi { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("format")]
    public string? Format { get; set; }

    [Column("orientation")]
    public string? Orientation { get; set; }

    [Column("default")]
    public bool? Default { get; set; }

    [Column("header_line")]
    public bool? HeaderLine { get; set; }

    [Column("disable_shrinking")]
    public bool? DisableShrinking { get; set; }

    [Column("css_margins")]
    public bool? CssMargins { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("margin_top")]
    public double? MarginTop { get; set; }

    [Column("margin_bottom")]
    public double? MarginBottom { get; set; }

    [Column("margin_left")]
    public double? MarginLeft { get; set; }

    [Column("margin_right")]
    public double? MarginRight { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaperformatId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Paperformat")] // One2many
    public virtual ICollection<IrActReportXml> IrActReportXml { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaperformatId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("Paperformat")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
