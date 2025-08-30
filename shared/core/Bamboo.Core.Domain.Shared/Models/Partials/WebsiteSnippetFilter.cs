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

//[Table("website_snippet_filter")]
//[Index("IsPublished", Name = "website_snippet_filter__is_published_index")]
//[Index("WebsiteId", Name = "website_snippet_filter__website_id_index")]
public partial class WebsiteSnippetFilter
{

}
