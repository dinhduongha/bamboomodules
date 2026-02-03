using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IForumPostAppService : IGenericAppService<ForumPost>
    {
        Task<ForumPost> CloseAsync(ForumPostCloseRequestDto input);
        Task<ForumPost> ConvertAnswerToCommentAsync(Guid[] ids);
        Task<ForumPost> ConvertCommentToAnswerAsync(ForumPostConvertCommentToAnswerRequestDto input);
        Task<ForumPost> GoToWebsiteAsync(Guid[] ids);
        Task<ForumPost> MarkAsOffensiveBatchAsync(ForumPostMarkAsOffensiveBatchRequestDto input);
        Task<ForumPost> MessagePostAsync(Guid[] ids);
        Task<ForumPost> ReopenAsync(Guid[] ids);
        Task<ForumPost> UnlinkCommentAsync(ForumPostUnlinkCommentRequestDto input);
        Task<ForumPost> ValidateAsync(Guid[] ids);
        Task<ForumPost> VoteAsync(ForumPostVoteRequestDto input);
    }
}