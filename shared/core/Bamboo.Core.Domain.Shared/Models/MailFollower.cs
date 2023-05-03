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

[Table("mail_followers")]
//[Index("ResModel", "ResId", "PartnerId", Name = "mail_followers_mail_followers_res_partner_res_model_id_uniq", IsUnique = true)]
//[Index("PartnerId", Name = "mail_followers_partner_id_index")]
//[Index("ResId", Name = "mail_followers_res_id_index")]
//[Index("ResModel", Name = "mail_followers_res_model_index")]
public partial class MailFollower: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("MailFollowers")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("MailFollowersId")]
    //[InverseProperty("MailFollowers")]
    [NotMapped]
    public virtual ICollection<MailMessageSubtype> MailMessageSubtypes { get; } = new List<MailMessageSubtype>();
}
