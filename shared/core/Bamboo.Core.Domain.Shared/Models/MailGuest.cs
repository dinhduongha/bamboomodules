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

[Table("mail_guest")]
public partial class MailGuest: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("timezone")]
    public string? Timezone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    //[InverseProperty("Guest")]
    [NotMapped]
    public virtual BusPresence? BusPresence { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("MailGuests")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailGuestCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailGuestWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Guest")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMembers { get; } = new List<MailChannelMember>();

    //[InverseProperty("Guest")]
    [NotMapped]
    public virtual ICollection<MailMessageReaction> MailMessageReactions { get; } = new List<MailMessageReaction>();

    //[InverseProperty("AuthorGuest")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages { get; } = new List<MailMessage>();

}
