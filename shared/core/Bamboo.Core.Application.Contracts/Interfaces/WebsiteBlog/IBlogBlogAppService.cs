using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IBlogBlogAppService : IGenericApplicationService<BlogBlog>
    {
        Task<BlogBlog> AllTagsAsync(Guid id, BlogBlogAllTagsRequestDto input);
        Task<BlogBlog> MessagePostAsync(Guid id);
    }
}