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

[Table("web_editor_converter_test")]
public partial class WebEditorConverterTest: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("integer")]
    public long? Integer { get; set; }

    [Column("many2one")]
    public Guid? Many2one { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("char")]
    public string? Char { get; set; }

    [Column("selection_str")]
    public string? SelectionStr { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("html")]
    public string? Html { get; set; }

    [Column("text")]
    public string? Text { get; set; }

    [Column("numeric")]
    public decimal? Numeric { get; set; }

    [Column("datetime", TypeName = "timestamp without time zone")]
    public DateTime? Datetime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("float")]
    public double? Float { get; set; }

    [Column("binary")]
    public byte[]? Binary { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebEditorConverterTestCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("Many2one")]
    //[InverseProperty("WebEditorConverterTests")]
    [NotMapped]
    public virtual WebEditorConverterTestSub? Many2oneNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebEditorConverterTestWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
