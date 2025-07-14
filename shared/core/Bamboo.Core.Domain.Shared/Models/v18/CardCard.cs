using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("card_card")]
//[Index("CampaignId", "ResId", Name = "card_card_campaign_record_unique", IsUnique = true)]
public partial class CardCard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("share_status")]
    public string? ShareStatus { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("requires_sync")]
    public bool? RequiresSync { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CampaignId")]
    //[InverseProperty("CardCards")]
    [NotMapped]
    public virtual CardCampaign? Campaign { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CardCardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CardCardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
