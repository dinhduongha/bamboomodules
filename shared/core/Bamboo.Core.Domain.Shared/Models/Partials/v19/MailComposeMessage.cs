using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class MailComposeMessage
{

    [Column("composition_comment_option")]
    public string? CompositionCommentOption { get; set; }

    [Column("notify_author")]
    public bool? NotifyAuthor { get; set; }

    [Column("notify_author_mention")]
    public bool? NotifyAuthorMention { get; set; }

    [Column("notify_skip_followers")]
    public bool? NotifySkipFollowers { get; set; }

}