using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("mail_guest")]
public partial class MailGuest
{

    // v16-Compat
    // [One2many]
    // [One2many] [ForeignKey("GuestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Guest")] // One2many
    // public virtual ICollection<MailChannelMember> MailChannelMember { get; set; }

}
