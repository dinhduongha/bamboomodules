using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteForum", Category = "Website", Depends = new[] { "auth_signup", "website_mail", "website_profile" })]
    public partial class ForumPostAppService : GenericAppService<ForumPost>, IForumPostAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public ForumPostAppService(IRepository<ForumPost, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<ForumPost> CloseAsync(ForumPostCloseRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: close) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ForumPost> ConvertAnswerToCommentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: convert_answer_to_comment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ForumPost> ConvertCommentToAnswerAsync(ForumPostConvertCommentToAnswerRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: convert_comment_to_answer) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ForumPost> GoToWebsiteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: go_to_website) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ForumPost> MarkAsOffensiveBatchAsync(ForumPostMarkAsOffensiveBatchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: mark_as_offensive_batch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ForumPost> MessagePostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: message_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ForumPost> ReopenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: reopen) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ForumPost> UnlinkCommentAsync(ForumPostUnlinkCommentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: unlink_comment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ForumPost> ValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ForumPost> VoteAsync(ForumPostVoteRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: vote) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}