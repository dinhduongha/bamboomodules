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

[Table("rating_rating")]
//[Index("MessageId", Name = "rating_rating_message_id_index")]
//[Index("ParentResId", Name = "rating_rating_parent_res_id_index")]
//[Index("ParentResModelId", Name = "rating_rating_parent_res_model_id_index")]
//[Index("ParentResModel", Name = "rating_rating_parent_res_model_index")]
//[Index("ResId", Name = "rating_rating_res_id_index")]
//[Index("ResModelId", Name = "rating_rating_res_model_id_index")]
//[Index("ResModel", Name = "rating_rating_res_model_index")]
public partial class RatingRating: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("parent_res_model_id")]
    public Guid? ParentResModelId { get; set; }

    [Column("parent_res_id")]
    public Guid? ParentResId { get; set; }

    [Column("rated_partner_id")]
    public Guid? RatedPartnerId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("res_name")]
    public string? ResName { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("parent_res_name")]
    public string? ParentResName { get; set; }

    [Column("parent_res_model")]
    public string? ParentResModel { get; set; }

    [Column("rating_text")]
    public string? RatingText { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("feedback")]
    public string? Feedback { get; set; }

    [Column("is_internal")]
    public bool? IsInternal { get; set; }

    [Column("consumed")]
    public bool? Consumed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("rating")]
    public double? Rating { get; set; }

    [Column("publisher_id")]
    public Guid? PublisherId { get; set; }

    [Column("publisher_comment")]
    public string? PublisherComment { get; set; }

    [Column("publisher_datetime", TypeName = "timestamp without time zone")]
    public DateTime? PublisherDatetime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("RatingRatingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageId")]
    //[InverseProperty("RatingRatings")]
    [NotMapped]
    public virtual MailMessage? Message { get; set; }

    [ForeignKey("ParentResModelId")]
    //[InverseProperty("RatingRatingParentResModelNavigations")]
    [NotMapped]
    public virtual IrModel? ParentResModelNavigation { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("RatingRatingPartners")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PublisherId")]
    //[InverseProperty("RatingRatingPublishers")]
    [NotMapped]
    public virtual ResPartner? Publisher { get; set; }

    [ForeignKey("RatedPartnerId")]
    //[InverseProperty("RatingRatingRatedPartners")]
    [NotMapped]
    public virtual ResPartner? RatedPartner { get; set; }

    [ForeignKey("ResModelId")]
    //[InverseProperty("RatingRatingResModelNavigations")]
    [NotMapped]
    public virtual IrModel? ResModelNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("RatingRatingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
