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

[Table("card_template")]
public partial class CardTemplate: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("primary_color")]
    public string? PrimaryColor { get; set; }

    [Column("secondary_color")]
    public string? SecondaryColor { get; set; }

    [Column("primary_text_color")]
    public string? PrimaryTextColor { get; set; }

    [Column("secondary_text_color")]
    public string? SecondaryTextColor { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    //[InverseProperty("CardTemplate")]
    [NotMapped]
    public virtual ICollection<CardCampaign> CardCampaigns { get; set; } 

    [ForeignKey("CreatorId")]
    //[InverseProperty("CardTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CardTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
