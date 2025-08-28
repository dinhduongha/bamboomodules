using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("mail_alias")]
//[Index("AliasName", Name = "mail_alias_alias_unique", IsUnique = true)]
public partial class MailAlias
{
    [Column("alias_user_id")]
    public Guid? AliasUserId { get; set; }

    // [Many2one]
    [ForeignKey("AliasUserId")]
    public virtual ResUsers? AliasUser { get; set; }
}
