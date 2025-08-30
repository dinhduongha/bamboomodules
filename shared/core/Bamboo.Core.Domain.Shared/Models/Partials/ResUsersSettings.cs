using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("res_users_settings")]
//[Index("UserId", Name = "res_users_settings_unique_user_id", IsUnique = true)]
public partial class ResUsersSettings
{
    [Column("is_discuss_sidebar_category_livechat_open")]
    public bool? IsDiscussSidebarCategoryLivechatOpen { get; set; }
}
