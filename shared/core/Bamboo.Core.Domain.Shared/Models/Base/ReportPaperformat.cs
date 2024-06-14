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
public partial class ReportPaperformat: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("page_height")]
    public long? PageHeight { get; set; }

    [Column("page_width")]
    public long? PageWidth { get; set; }

    [Column("header_spacing")]
    public long? HeaderSpacing { get; set; }

    [Column("dpi")]
    public long? Dpi { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("margin_top")]
    public double? MarginTop { get; set; }

    [Column("margin_bottom")]
    public double? MarginBottom { get; set; }

    [Column("margin_left")]
    public double? MarginLeft { get; set; }

    [Column("margin_right")]
    public double? MarginRight { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ReportPaperformatCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ReportPaperformatWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Paperformat")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> IrActReportXmls { get; } = new List<IrActReportXml>();

    //[InverseProperty("Paperformat")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

}
