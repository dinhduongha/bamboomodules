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

[Table("report_paperformat")]
public partial class ReportPaperformat: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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
    [ForeignKey("CreatorId")]
    // [InverseProperty("ReportPaperformatCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("PaperformatId")]
    [InverseProperty("Paperformat")]
    public virtual ICollection<IrActReportXml> IrActReportXml { get; set; }

    // [One2many]
    [ForeignKey("PaperformatId")]
    [InverseProperty("Paperformat")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ReportPaperformatWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
