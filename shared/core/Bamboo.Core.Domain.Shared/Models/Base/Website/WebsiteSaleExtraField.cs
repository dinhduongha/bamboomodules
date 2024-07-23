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

[Table("website_sale_extra_field")]
public partial class WebsiteSaleExtraField: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("field_id")]
    public Guid? FieldId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsiteSaleExtraFieldCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("FieldId")]
    //[InverseProperty("WebsiteSaleExtraFields")]
    [NotMapped]
    public virtual IrModelField? Field { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("WebsiteSaleExtraFields")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsiteSaleExtraFieldWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
